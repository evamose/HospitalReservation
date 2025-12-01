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
    public partial class VisitControl : UserControl
    {
        public int? PatientId { get; set; }   // PatientDetailForm에서 넘겨줄 환자 ID

        private string connectionString =
            "User Id=HOSPITAL_USER;" +
            "Password=1234;" +
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));";

        public VisitControl()
        {
            InitializeComponent();
        }

        public void LoadVisits()
        {
            if (PatientId == null)
            {
                dgvVisit.DataSource = null;
                return;
            }

            try
            {
                using (var conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                        SELECT 
                            VISIT_ID,
                            VISIT_DATE,
                            DEPT,
                            DOCTOR_ID,
                            DISEASE_CODE,
                            DIAGNOSIS
                        FROM VISIT
                        WHERE PATIENT_ID = :pid
                        ORDER BY VISIT_DATE DESC
                    ";

                    var da = new OracleDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.Add(":pid", PatientId);

                    var dt = new DataTable();
                    da.Fill(dt);

                    dgvVisit.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("진료 내역 불러오기 오류: " + ex.Message);
            }
        }


        // 진료 추가 버튼
        private void btnAddVisit_Click(object sender, EventArgs e)
        {
            if (PatientId == null)
            {
                MessageBox.Show("먼저 환자 정보를 저장한 후 진료를 등록해주세요.");
                return;
            }

            // 간단한 유효성 검사
            if (string.IsNullOrWhiteSpace(txtDept.Text))
            {
                MessageBox.Show("진료과를 입력해주세요.");
                txtDept.Focus();
                return;
            }

            if (!int.TryParse(txtDoctorId.Text, out int doctorId))
            {
                MessageBox.Show("담당의 ID는 숫자로 입력해주세요.");
                txtDoctorId.Focus();
                return;
            }

            try
            {
                using (var conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    // 새 VISIT_ID 생성 (MAX+1 방식)
                    string getIdSql = "SELECT NVL(MAX(VISIT_ID),0) + 1 FROM VISIT";
                    int newId;

                    using (var cmdId = new OracleCommand(getIdSql, conn))
                    {
                        newId = Convert.ToInt32(cmdId.ExecuteScalar());
                    }

                    string sql = @"
                        INSERT INTO VISIT
                            (VISIT_ID, PATIENT_ID, DOCTOR_ID, VISIT_DATE,
                             DEPT, SYMPTOM, DISEASE_CODE, DIAGNOSIS)
                        VALUES
                            (:vid, :pid, :did, :vdate,
                             :dept, :symptom, :dcode, :diag)
                    ";

                    using (var cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(":vid", newId);
                        cmd.Parameters.Add(":pid", PatientId.Value);
                        cmd.Parameters.Add(":did", doctorId);
                        cmd.Parameters.Add(":vdate", dtpVisitDate.Value);
                        cmd.Parameters.Add(":dept", txtDept.Text);
                        cmd.Parameters.Add(":symptom", DBNull.Value);  // 증상 텍스트박스 만들면 여기 연결
                        cmd.Parameters.Add(":dcode", (object)(txtDiseaseCode.Text ?? (string)null) ?? DBNull.Value);
                        cmd.Parameters.Add(":diag", (object)(txtDiagnosis.Text ?? (string)null) ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("진료가 등록되었습니다.");
                LoadVisits();
            }
            catch (Exception ex)
            {
                MessageBox.Show("진료 등록 중 오류: " + ex.Message);
            }
        }

        // 진료 삭제 버튼
        private void btnDeleteVisit_Click(object sender, EventArgs e)
        {
            if (dgvVisit.CurrentRow == null)
            {
                MessageBox.Show("삭제할 진료를 선택해주세요.");
                return;
            }

            object idValue = dgvVisit.CurrentRow.Cells["VISIT_ID"].Value;
            if (idValue == null || !int.TryParse(idValue.ToString(), out int visitId))
            {
                MessageBox.Show("선택한 진료의 ID를 가져올 수 없습니다.");
                return;
            }

            var confirm = MessageBox.Show(
                "선택한 진료를 삭제하시겠습니까?",
                "삭제 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string sql = "DELETE FROM VISIT WHERE VISIT_ID = :vid";

                    using (var cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(":vid", visitId);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                            MessageBox.Show("진료가 삭제되었습니다.");
                        else
                            MessageBox.Show("삭제할 진료를 찾지 못했습니다.");
                    }
                }

                LoadVisits();
            }
            catch (Exception ex)
            {
                MessageBox.Show("진료 삭제 중 오류: " + ex.Message);
            }
        }
    }
}