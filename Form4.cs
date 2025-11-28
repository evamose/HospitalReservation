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


    public partial class Form4 : Form
    {
        DataSet ds = new DataSet();
        OracleDataAdapter da;

        string connectionString =
            "User Id=HOSPITAL_USER;" +
            "Password=1234;" +
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));";

        public Form4()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private void LoadDoctorList()
        {
            try
            {
                string query = @"
                    SELECT 
                        DOCTOR_ID, 
                        NAME, 
                        BIRTH, 
                        PHONE, 
                        EMAIL,
                        ADDRESS, 
                        LICENSE_NO, 
                        DEPT, 
                        ROOM, 
                        NOTE
                    FROM DOCTOR
                    ORDER BY DOCTOR_ID
                ";

                da = new OracleDataAdapter(query, connectionString);
                ds.Clear();
                da.Fill(ds, "doctor");

                dgvDoctor.DataSource = ds.Tables["doctor"];
                dgvDoctor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("의사 목록 불러오기 오류: " + ex.Message);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadDoctorList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtDoctorId.Text =
                dgvDoctor.Rows[e.RowIndex].Cells["DOCTOR_ID"].Value.ToString();

            txtDoctorName.Text =
                dgvDoctor.Rows[e.RowIndex].Cells["NAME"].Value.ToString();

            txtDepartment.Text =
                dgvDoctor.Rows[e.RowIndex].Cells["DEPT"].Value.ToString();
        }

        private void EditSelectedDoctor()
        {
            // 1) 선택된 행 있는지 확인
            if (dgvDoctor.CurrentRow == null)
            {
                MessageBox.Show("수정할 의사를 선택해주세요.");
                return;
            }

            // 2) 현재 행에서 DOCTOR_ID 값 꺼내기
            object idValue = dgvDoctor.CurrentRow.Cells["DOCTOR_ID"].Value;
            // ※ 만약 컬럼명이 다르면 실제 컬럼명으로 바꿔줘야 해요.
            //    (예: "Doctor_ID", "ID" 등)

            if (idValue == null || idValue == DBNull.Value)
            {
                MessageBox.Show("선택한 의사의 ID를 가져올 수 없습니다.");
                return;
            }

            if (!int.TryParse(idValue.ToString(), out int doctorId))
            {
                MessageBox.Show("선택한 의사 ID가 숫자가 아닙니다.");
                return;
            }

            // 3) 의사 상세 모달 띄우기
            using (var dlg = new DoctorDetailForm())
            {
                dlg.Mode = DoctorFormMode.Edit;  // 수정 모드
                dlg.LoadDoctor(doctorId);       // DB에서 정보 읽어와서 폼에 채우기

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("의사 정보가 저장되었습니다.");
                    LoadDoctorList();           // 의사 목록 다시 불러오기 (이미 있는 함수일 거야)
                }
            }
        }


        // 등록 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            using (var dlg = new DoctorDetailForm())
            {
                dlg.Mode = DoctorFormMode.Create;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // 저장 성공 후 목록 새로고침 + 메시지
                    MessageBox.Show("의사 정보가 저장되었습니다.");
                    LoadDoctorList();
                }
            }
        }

        // 수정 버튼
        private void button3_Click(object sender, EventArgs e)
        {

            if (dgvDoctor.CurrentRow == null)
            {
                MessageBox.Show("수정할 의사를 선택해주세요.");
                return;
            }

            using (var dlg = new DoctorDetailForm())
            {
                 EditSelectedDoctor();
            }
        }

        private void dgvDoctor_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedDoctor();
        }

        // 삭제 버튼
        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDoctorId.Text))
            {
                MessageBox.Show("삭제할 의사를 선택해주세요.");
                return;
            }

            if (!int.TryParse(txtDoctorId.Text, out int doctorId))
            {
                MessageBox.Show("의사 ID는 숫자로 입력해야 합니다.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "정말로 이 의사를 삭제하시겠습니까?\n연결된 스케줄이나 예약이 있을 경우 삭제할 수 없습니다.",
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
                DELETE FROM DOCTOR
                WHERE DOCTOR_ID = :id
            ";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(new OracleParameter(":id", doctorId));

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        MessageBox.Show("의사 정보가 성공적으로 삭제되었습니다.");
                    else
                        MessageBox.Show("삭제 실패: 해당 의사가 존재하지 않습니다.");
                }

                // 삭제 후 목록 새로고침
                LoadDoctorList();

                // 입력창 초기화
                txtDoctorId.Clear();
                txtDoctorName.Clear();
                txtDepartment.Clear();
            }
            catch (OracleException ex)
            {
                if (ex.Number == 2292)  // ORA-02292: child record found
                {
                    MessageBox.Show("해당 의사는 스케줄 또는 예약에 연결되어 있어 삭제할 수 없습니다.");
                }
                else
                {
                    MessageBox.Show("삭제 오류: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("삭제 오류: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDoctorId.Text))
            {
                MessageBox.Show("근무 스케줄을 볼 의사를 먼저 선택해주세요.");
                return;
            }

            if (!int.TryParse(txtDoctorId.Text, out int id))
            {
                MessageBox.Show("의사 ID는 숫자로만 구성되어야 합니다.");
                return;
            }

            Form6 f = new Form6(id);   
            f.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
