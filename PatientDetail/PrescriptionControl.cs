using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalReservation
{
    public partial class PrescriptionControl : UserControl
    {
        public int? PatientId { get; set; }

        public int? DoctorId { get; set; }

        private string connectionString =
            "User Id=HOSPITAL_USER;" +
            "Password=1234;" +
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));";

        public PrescriptionControl()
        {
            InitializeComponent();
        }

        public void LoadPrescriptions()
        {
            if (PatientId == null)
            {
                dgvPrescription.DataSource = null;
                return;
            }

            try
            {
                using (var conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                        SELECT 
                            PRESC_ID,
                            PRESC_DATE,
                            DRUG_NAME,
                            DOSAGE,
                            TIMES_PER_DAY,
                            DAYS,
                            METHOD,
                            DOCTOR_ID
                        FROM PRESCRIPTION
                        WHERE PATIENT_ID = :pid
                        ORDER BY PRESC_DATE DESC
                    ";

                    var da = new OracleDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.Add(":pid", PatientId);

                    var dt = new DataTable();
                    da.Fill(dt);

                    dgvPrescription.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("처방 내역 불러오기 오류: " + ex.Message);
            }
        }

        // 처방 추가 버튼
        private void btnAddPresc_Click(object sender, EventArgs e)
        {
            if (PatientId == null)
            {
                MessageBox.Show("먼저 환자 정보를 저장한 후 처방을 등록해주세요.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDrugName.Text))
            {
                MessageBox.Show("약품명을 입력해주세요.");
                txtDrugName.Focus();
                return;
            }

            if (DoctorId == null)
            {
                MessageBox.Show("환자 담당의 정보가 없습니다. 환자 정보에서 담당의를 먼저 선택해주세요.");
                return;
            }

            int? timesPerDay = null;
            if (int.TryParse(txtTimesPerDay.Text, out int t))
                timesPerDay = t;

            int? days = null;
            if (int.TryParse(txtDays.Text, out int d))
                days = d;

            try
            {
                using (var conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    // 새 PRESC_ID 생성
                    string getIdSql = "SELECT NVL(MAX(PRESC_ID),0) + 1 FROM PRESCRIPTION";
                    int newId;
                    using (var cmdId = new OracleCommand(getIdSql, conn))
                    {
                        newId = Convert.ToInt32(cmdId.ExecuteScalar());
                    }

                    string sql = @"
                        INSERT INTO PRESCRIPTION
                            (PRESC_ID, PATIENT_ID, DOCTOR_ID, VISIT_ID,
                             PRESC_DATE, DRUG_NAME, DOSAGE,
                             TIMES_PER_DAY, DAYS, METHOD)
                        VALUES
                            (:pid_new, :patient_id, :doctor_id, :visit_id,
                             :pdate, :drug, :dosage,
                             :times, :days, :method)
                    ";

                    using (var cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(":pid_new", newId);
                        cmd.Parameters.Add(":patient_id", PatientId.Value);
                        cmd.Parameters.Add(":doctor_id", DoctorId.Value);
                        cmd.Parameters.Add(":visit_id", DBNull.Value); // 나중에 VISIT와 연결하면 변경
                        cmd.Parameters.Add(":pdate", dtpPrescDate.Value); // 없으면 DateTime.Now
                        cmd.Parameters.Add(":drug", txtDrugName.Text);
                        cmd.Parameters.Add(":dosage", txtDosage.Text);
                        cmd.Parameters.Add(":times", (object)timesPerDay ?? DBNull.Value);
                        cmd.Parameters.Add(":days", (object)days ?? DBNull.Value);
                        cmd.Parameters.Add(":method", (object)(txtMethod.Text ?? (string)null) ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("처방이 등록되었습니다.");
                LoadPrescriptions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("처방 등록 중 오류: " + ex.Message);
            }
        }

        // 처방 삭제 버튼
        private void btnDeletePresc_Click(object sender, EventArgs e)
        {
            if (dgvPrescription.CurrentRow == null)
            {
                MessageBox.Show("삭제할 처방을 선택해주세요.");
                return;
            }

            object idValue = dgvPrescription.CurrentRow.Cells["PRESC_ID"].Value;
            if (idValue == null || !int.TryParse(idValue.ToString(), out int prescId))
            {
                MessageBox.Show("선택한 처방의 ID를 가져올 수 없습니다.");
                return;
            }

            var confirm = MessageBox.Show(
                "선택한 처방을 삭제하시겠습니까?",
                "삭제 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string sql = "DELETE FROM PRESCRIPTION WHERE PRESC_ID = :pid";

                    using (var cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(":pid", prescId);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                            MessageBox.Show("처방이 삭제되었습니다.");
                        else
                            MessageBox.Show("삭제할 처방을 찾지 못했습니다.");
                    }
                }

                LoadPrescriptions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("처방 삭제 중 오류: " + ex.Message);
            }
        }
    }
}