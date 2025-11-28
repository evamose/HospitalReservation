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
    public partial class Form3 : Form
    {
        DataSet ds = new DataSet();      // patient 테이블 저장용
        OracleDataAdapter da;            // DBAdapter

        string connectionString =
            "User Id=HOSPITAL_USER;" +
            "Password=1234;" +
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));";

        public Form3()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }
         private void LoadPatientList()
        {
            try
            {
                string query = @"
                    SELECT 
                        PATIENT_ID,
                        NAME,
                        BIRTH,
                        VISIT_REASON,
                        DOCTOR_NO
                    FROM PATIENT
                    ORDER BY PATIENT_ID
                ";

                da = new OracleDataAdapter(query, connectionString);
                ds.Clear();
                da.Fill(ds, "patient");

                dgvPatient.DataSource = ds.Tables["patient"];
                dgvPatient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("환자 목록 불러오기 오류: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 등록 모달창 띄우기
            using (var dlg = new PatientDetailForm())
            {
                // 필요하면 모드 전달 (선택사항)
                // dlg.Mode = FormMode.Create;

                var result = dlg.ShowDialog();

                // PatientDetailForm에서 DB INSERT까지 성공했을 때만 OK로 닫히게 만들 거야
                if (result == DialogResult.OK)
                {
                    MessageBox.Show("환자가 성공적으로 등록되었습니다.");
                    LoadPatientList();   // 목록 새로고침
                }
                // else 쪽은 "취소" or "실패" 케이스
                else
                {
                    MessageBox.Show("환자 등록이 취소되었거나 실패했습니다.");
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadPatientList();
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtPatientId.Text =
                dgvPatient.Rows[e.RowIndex].Cells["PATIENT_ID"].Value.ToString();

            txtName.Text =
                dgvPatient.Rows[e.RowIndex].Cells["NAME"].Value.ToString();

            txtBirth.Text =
                dgvPatient.Rows[e.RowIndex].Cells["BIRTH"].Value.ToString();

            txtReason.Text =
                dgvPatient.Rows[e.RowIndex].Cells["VISIT_REASON"].Value.ToString();

            txtDoctorNo.Text =
                dgvPatient.Rows[e.RowIndex].Cells["DOCTOR_NO"].Value.ToString();
        }

        
        private void EditSelectedPatient()
        {
            // 1) 선택된 행이 있는지 확인
            if (dgvPatient.CurrentRow == null)
            {
                MessageBox.Show("수정할 환자를 선택해주세요.");
                return;
            }

            // 2) 선택된 행에서 환자 ID 읽기
            object idValue = dgvPatient.CurrentRow.Cells["PATIENT_ID"].Value;

            if (idValue == null || idValue == DBNull.Value)
            {
                MessageBox.Show("선택한 환자 ID를 가져올 수 없습니다.");
                return;
            }

            int patientId;
            if (!int.TryParse(idValue.ToString(), out patientId))
            {
                MessageBox.Show("선택한 환자 ID가 올바르지 않습니다.");
                return;
            }

            // 3) 환자 상세 모달 띄우기
            using (var dlg = new PatientDetailForm())
            {
                dlg.Mode = FormMode.Edit;

                // DB에서 해당 환자 정보 읽어서 폼에 채우기
                dlg.LoadPatient(patientId);

                // 사용자가 저장 누른 경우만 처리
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("환자 정보가 수정되었습니다.");
                    LoadPatientList();   // 목록 새로고침 (기존에 쓰던 함수)
                }
            }
        }

        // 환자 더블클릭시 정보 수정
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EditSelectedPatient();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatientId.Text))
            {
                MessageBox.Show("삭제할 환자를 먼저 선택해주세요.");
                return;
            }

            int patientId = int.Parse(txtPatientId.Text);

            DialogResult result = MessageBox.Show(
                "정말로 이 환자를 삭제하시겠습니까?",
                "삭제 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        DELETE FROM PATIENT
                        WHERE PATIENT_ID = :id
                    ";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(new OracleParameter(":id", patientId));

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        MessageBox.Show("환자 정보가 성공적으로 삭제되었습니다.");
                    else
                        MessageBox.Show("삭제 실패: 해당 환자가 존재하지 않습니다.");
                }

                // 삭제 후 목록 새로고침
                LoadPatientList();

                // 입력창 초기화
                txtPatientId.Clear();
                txtName.Clear();
                txtBirth.Clear();
                txtReason.Clear();
                txtDoctorNo.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("환자 삭제 오류: " + ex.Message);
            }
        }

        // 환자 정보 수정
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatientId.Text))
            {
                MessageBox.Show("수정할 환자를 먼저 선택해주세요.");
                return;
            }

            EditSelectedPatient();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }

}
