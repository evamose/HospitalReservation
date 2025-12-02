using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace HospitalReservation
{
    public partial class Form6 : Form
    {
        // DoctorDetailForm과 동일하게 맞춰줘
        private readonly string connectionString =
            "User Id=HOSPITAL_USER;" +
            "Password=1234;" +
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));";

        // 의사 상세 폼에서 넘어온 의사 ID (초기 표시용)
        private int doctorId;

        // 현재 그리드에서 선택된 스케줄의 PK
        private int? currentScheduleId = null;

        public Form6(int id)
        {
            InitializeComponent();

            doctorId = id;

            // 그리드: 조회 전용으로 설정
            dgvSchedule.ReadOnly = true;
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.AllowUserToDeleteRows = false;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.MultiSelect = false;
            dgvSchedule.DataError += dgvSchedule_DataError;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // 넘어온 의사 ID를 기본값으로만 보여줌 (수정 가능)
            txtDoctorId.Text = doctorId.ToString();

            // 폼 처음 열릴 때, 현재 날짜 기준 스케줄 조회
            LoadScheduleList(mcWorkDate.SelectionStart.Date);
        }

        /// <summary>
        /// 특정 날짜의 전체 의사 스케줄 조회
        /// </summary>
        private void LoadScheduleList(DateTime workDate)
        {
            string query = @"
                SELECT 
                    WORK_SCHED_ID,
                    DOCTOR_ID,
                    WORK_DATE,
                    WORK_STATUS,
                    WORK_TIME
                FROM WORK_SCHEDULE
                WHERE TRUNC(WORK_DATE) = :wdate
                ORDER BY DOCTOR_ID, WORK_DATE, WORK_SCHED_ID
            ";


            using (var da = new OracleDataAdapter(query, connectionString))
            {
                da.SelectCommand.Parameters.Add(":wdate", workDate);

                var ds = new DataSet();
                da.Fill(ds, "schedule");

                dgvSchedule.DataSource = ds.Tables["schedule"];
            }

            // 날짜 바꿀 때마다 선택 스케줄 초기화
            currentScheduleId = null;
        }

        /// <summary>
        /// 날짜 변경 → 해당 날짜 스케줄 재조회
        /// </summary>
        private void mcWorkDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadScheduleList(e.Start.Date);
        }

        /// <summary>
        /// 그리드에서 행 선택 → 컨트롤에 값 채우기
        /// </summary>
        private void dgvSchedule_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSchedule.CurrentRow == null) return;

            var row = dgvSchedule.CurrentRow;
            var drv = row.DataBoundItem as DataRowView;
            if (drv == null) return;

            // PK
            if (drv["WORK_SCHED_ID"] != DBNull.Value)
                currentScheduleId = Convert.ToInt32(drv["WORK_SCHED_ID"]);
            else
                currentScheduleId = null;

            // 날짜
            if (drv["WORK_DATE"] != DBNull.Value)
            {
                DateTime dt = Convert.ToDateTime(drv["WORK_DATE"]);
                mcWorkDate.SelectionStart = dt;           // MonthCalendar면 mcWorkDate.SetDate(dt);
            }

            // 의사 ID
            if (drv["DOCTOR_ID"] != DBNull.Value)
                txtDoctorId.Text = drv["DOCTOR_ID"].ToString();

            // 근무 상태
            string status = drv["WORK_STATUS"] == DBNull.Value ? null : drv["WORK_STATUS"].ToString();
            if (!string.IsNullOrEmpty(status))
                cmbStatus.SelectedItem = status;
            else
                cmbStatus.SelectedIndex = -1;

            // 근무 시간대
            string shift = drv["WORK_TIME"] == DBNull.Value ? null : drv["WORK_TIME"].ToString();
            if (string.IsNullOrEmpty(shift))
            {
                cmbShift.SelectedIndex = -1;
                cmbShift.Enabled = (status == "WORK");
            }
            else
            {
                if (cmbShift.Items.Contains(shift))
                    cmbShift.SelectedItem = shift;
                else
                    cmbShift.Text = shift;       // 혹시 콤보박스 항목에 없는 값이면 텍스트로만

                cmbShift.Enabled = true;
            }
        }

        /// <summary>
        /// 근무 상태에 따라 근무 시간대 활성/비활성
        /// </summary>
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem == null)
            {
                cmbShift.Enabled = false;
                cmbShift.SelectedIndex = -1;
                return;
            }

            string status = cmbStatus.SelectedItem.ToString();
            if (status == "OFF")
            {
                cmbShift.Enabled = false;
                cmbShift.SelectedIndex = -1;
            }
            else
            {
                cmbShift.Enabled = true;
            }
        }

        /// <summary>
        /// 스케줄 등록
        /// - mcWorkDate 날짜
        /// - txtDoctorId 의사 ID
        /// - cmbStatus / cmbShift 값 사용
        /// </summary>
        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDoctorId.Text.Trim(), out int targetDoctorId))
            {
                MessageBox.Show("유효한 의사 ID를 입력하세요.");
                txtDoctorId.Focus();
                return;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("근무 상태를 선택하세요.");
                cmbStatus.DroppedDown = true;
                return;
            }

            string status = cmbStatus.SelectedItem.ToString();
            string shift = null;

            if (status == "WORK")
            {
                if (cmbShift.SelectedItem == null)
                {
                    MessageBox.Show("WORK 상태일 때는 근무 시간대를 선택해야 합니다.");
                    cmbShift.DroppedDown = true;
                    return;
                }
                shift = cmbShift.SelectedItem.ToString();
            }

            DateTime workDate = mcWorkDate.SelectionStart.Date;

            try
            {
                using (var conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    // 같은 의사 + 같은 날짜에 기존 스케줄 있는지 체크 (경고만)
                    string checkSql = @"
                        SELECT COUNT(*)
                        FROM WORK_SCHEDULE
                        WHERE DOCTOR_ID = :did
                          AND TRUNC(WORK_DATE) = :wdate
                    ";

                    using (var cmdCheck = new OracleCommand(checkSql, conn))
                    {
                        cmdCheck.Parameters.Add(":did", targetDoctorId);
                        cmdCheck.Parameters.Add(":wdate", workDate);
                        int cnt = Convert.ToInt32(cmdCheck.ExecuteScalar());

                        if (cnt > 0)
                        {
                            var result = MessageBox.Show(
                                "이 의사의 해당 날짜 스케줄이 이미 있습니다.\n그래도 추가하시겠습니까?",
                                "중복 스케줄",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (result == DialogResult.No)
                                return;
                        }
                    }

                    // 새 PK 생성
                    int newId;
                    using (var cmdId = new OracleCommand("SELECT NVL(MAX(WORK_SCHED_ID),0)+1 FROM WORK_SCHEDULE", conn))
                    {
                        newId = Convert.ToInt32(cmdId.ExecuteScalar());
                    }

                    string insertSql = @"
                        INSERT INTO WORK_SCHEDULE
                            (WORK_SCHED_ID, DOCTOR_ID, WORK_DATE, WORK_STATUS, WORK_TIME)
                        VALUES
                            (:sid, :did, :wdate, :status, :workTime)
                    ";

                    using (var cmdInsert = new OracleCommand(insertSql, conn))
                    {
                        cmdInsert.Parameters.Add(":sid", newId);
                        cmdInsert.Parameters.Add(":did", targetDoctorId);
                        cmdInsert.Parameters.Add(":wdate", workDate);
                        cmdInsert.Parameters.Add(":status", status);
                        cmdInsert.Parameters.Add(":workTime", (object)shift ?? DBNull.Value); // shift 변수 = 근무시간대
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("스케줄이 등록되었습니다.");
                LoadScheduleList(workDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("스케줄 등록 중 오류: " + ex.Message);
            }
        }

        /// <summary>
        /// 스케줄 수정
        /// - 먼저 그리드에서 한 행을 선택해야 함
        /// </summary>
        private void btnUpdateSchedule_Click(object sender, EventArgs e)
        {
            if (!currentScheduleId.HasValue)
            {
                MessageBox.Show("수정할 스케줄을 먼저 선택하세요.");
                return;
            }

            if (!int.TryParse(txtDoctorId.Text.Trim(), out int targetDoctorId))
            {
                MessageBox.Show("유효한 의사 ID를 입력하세요.");
                txtDoctorId.Focus();
                return;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("근무 상태를 선택하세요.");
                cmbStatus.DroppedDown = true;
                return;
            }

            string status = cmbStatus.SelectedItem.ToString();
            string shift = null;

            if (status == "WORK")
            {
                if (cmbShift.SelectedItem == null)
                {
                    MessageBox.Show("WORK 상태일 때는 근무 시간대를 선택해야 합니다.");
                    cmbShift.DroppedDown = true;
                    return;
                }
                shift = cmbShift.SelectedItem.ToString();
            }

            DateTime workDate = mcWorkDate.SelectionStart.Date;

            try
            {
                using (var conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string updateSql = @"
                        UPDATE WORK_SCHEDULE
                        SET DOCTOR_ID   = :did,
                            WORK_DATE   = :wdate,
                            WORK_STATUS = :status,
                            WORK_TIME   = :workTime
                        WHERE WORK_SCHED_ID = :sid
                    ";

                    using (var cmd = new OracleCommand(updateSql, conn))
                    {
                        cmd.Parameters.Add(":did", targetDoctorId);
                        cmd.Parameters.Add(":wdate", workDate);
                        cmd.Parameters.Add(":status", status);
                        cmd.Parameters.Add(":workTime", (object)shift ?? DBNull.Value);
                        cmd.Parameters.Add(":sid", currentScheduleId.Value);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                            MessageBox.Show("스케줄이 수정되었습니다.");
                        else
                            MessageBox.Show("수정할 스케줄을 찾지 못했습니다.");
                    }
                }

                LoadScheduleList(workDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("스케줄 수정 중 오류: " + ex.Message);
            }
        }

        /// <summary>
        /// 스케줄 삭제
        /// </summary>
        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            if (!currentScheduleId.HasValue)
            {
                MessageBox.Show("삭제할 스케줄을 먼저 선택하세요.");
                return;
            }

            var confirm = MessageBox.Show(
                "선택한 스케줄을 삭제하시겠습니까?",
                "삭제 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            DateTime workDate = mcWorkDate.SelectionStart.Date;

            try
            {
                using (var conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string sql = "DELETE FROM WORK_SCHEDULE WHERE WORK_SCHED_ID = :sid";

                    using (var cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(":sid", currentScheduleId.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("스케줄이 삭제되었습니다.");
                LoadScheduleList(workDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("스케줄 삭제 중 오류: " + ex.Message);
            }
        }

        // 그리드 바인딩 중 에러가 나도 기본 팝업이 튀지 않게 처리
        private void dgvSchedule_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }

    }
}