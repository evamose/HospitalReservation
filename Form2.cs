using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace HospitalReservation
{
    public partial class Form2 : Form
    {
        int selectedVisitId = -1;
        int patientId;   // Form1 에서 전달받을 환자 ID

       
        public Form2(int id)
        {
            InitializeComponent();
            patientId = id;      // 전달된 환자 번호 저장

            //form 크기 고정 코드
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // 환자의 전체 예약을 자동으로 불러오고싶다면 여기에 LoadReservationList() 추가 가능
        }

        private void dgvReservation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedVisitId =
                Convert.ToInt32(dgvReservation.Rows[e.RowIndex].Cells["VISIT_ID"].Value);

            txtVisitDate.Text =
                dgvReservation.Rows[e.RowIndex].Cells["VISIT_DATE"].Value.ToString();

            txtSymptom.Text =
                dgvReservation.Rows[e.RowIndex].Cells["SYMPTOM"].Value.ToString();
        }

        // -----------------------------
        // 예약 번호(순번)으로 조회 + PATIENT_ID 조건 추가됨
        // -----------------------------
        private void LoadReservationById(int reservationId)
        {
            try
            {
                string connectionString =
                "User Id=HOSPITAL_USER;" +
                "Password=1234;" +
                "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));";

                string query = @"
                    SELECT visit_ID, VISIT_DATE, symptom
                    FROM visit
                    WHERE visit_ID = :vid
                      AND PATIENT_ID = :pid
                ";

                OracleDataAdapter da = new OracleDataAdapter(query, connectionString);
                da.SelectCommand.Parameters.Add(new OracleParameter(":vid", reservationId));
                da.SelectCommand.Parameters.Add(new OracleParameter(":pid", patientId));

                DataSet ds = new DataSet();
                da.Fill(ds, "visit");

                if (ds.Tables["visit"].Rows.Count == 0)
                {
                    MessageBox.Show("해당 순번의 예약이 없거나 다른 환자의 예약입니다.");
                    return;
                }

                dgvReservation.DataSource = ds.Tables["visit"];

                txtVisitDate.Text = ds.Tables["visit"].Rows[0]["VISIT_DATE"].ToString();
                txtSymptom.Text = ds.Tables["visit"].Rows[0]["symptom"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("예약 조회 오류: " + ex.Message);
            }
        }

        // 예약 확인 버튼
        private void btnCheckReservation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReservationNumber.Text))
            {
                MessageBox.Show("순번(예약 번호)을 입력하세요.");
                return;
            }

            selectedVisitId = int.Parse(txtReservationNumber.Text);
            LoadReservationById(selectedVisitId);
        }

        // 예약 변경 버튼
        private void btnChangeReservation_Click(object sender, EventArgs e)
        {
            if (selectedVisitId == -1)
            {
                MessageBox.Show("먼저 예약을 조회해주세요.");
                return;
            }

            try
            {
                string connectionString =
                "User Id=HOSPITAL_USER;" +
                "Password=1234;" +
                "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));";

                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE visit
                        SET VISIT_DATE = :date,
                            symptom = :symptom
                        WHERE  VISIT_ID = :vid
                          AND PATIENT_ID = :pid
                    ";

                    OracleCommand cmd = new OracleCommand(query, conn);

                    cmd.Parameters.Add(new OracleParameter(":date", DateTime.Parse(txtVisitDate.Text)));
                    cmd.Parameters.Add(new OracleParameter(":symptom", txtSymptom.Text));
                    cmd.Parameters.Add(new OracleParameter(":vid", selectedVisitId));
                    cmd.Parameters.Add(new OracleParameter(":pid", patientId));

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                        MessageBox.Show("예약이 성공적으로 변경되었습니다.");
                    else
                        MessageBox.Show("예약 변경 실패!");
                }

                LoadReservationById(selectedVisitId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("예약 변경 오류: " + ex.Message);
            }
        }
    }
}
