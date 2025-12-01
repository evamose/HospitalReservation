using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace HospitalReservation
{
    public partial class Form2 : Form
    {

        private readonly string connectionString =
            "User Id=HOSPITAL_USER;Password=1234;" +
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));";

        int selectedVisitId = -1;
        int patientId;   // Form1 에서 전달받을 환자 ID

       
        public Form2(int id)
        {
            InitializeComponent();
            patientId = id;      // 전달된 환자 번호 저장

            cboDept.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDoctor.DropDownStyle = ComboBoxStyle.DropDownList;

            //form 크기 고정 코드
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadDepartments();      // 1. 진료과 불러오기
            LoadReservationList();  // 2. 예약 목록 불러오기
        }

        private void dgvReservation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvReservation.Rows[e.RowIndex];

                if (row.Cells["VISIT_ID"].Value != null)
                {
                    selectedVisitId = Convert.ToInt32(row.Cells["VISIT_ID"].Value);
                    txtReservationNumber.Text = selectedVisitId.ToString();
                }

                if (row.Cells["VISIT_DATE"].Value != null)
                {
                    txtVisitDate.Text = row.Cells["VISIT_DATE"].Value.ToString();
                }

                if (row.Cells["SYMPTOM"].Value != null)
                {
                    txtSymptom.Text = row.Cells["SYMPTOM"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터 선택 오류: " + ex.Message);
            }
        }

        // 예약 확인 버튼
        private void btnCheckReservation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatientName.Text) ||
        string.IsNullOrWhiteSpace(txtVisitDate.Text) ||
        cboDoctor.SelectedValue == null)
            {
                MessageBox.Show("정보를 모두 입력해주세요.");
                return;
            }

            string inputName = txtPatientName.Text.Trim();
            int foundPatientId = -1;

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string checkQuery = "SELECT PATIENT_ID FROM PATIENT WHERE NAME = :pname";

                    using (OracleCommand cmdCheck = new OracleCommand(checkQuery, conn))
                    {
                        cmdCheck.BindByName = true;

                        cmdCheck.Parameters.Add(new OracleParameter("pname", inputName));

                        object result = cmdCheck.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show($"'{inputName}' 환자를 찾을 수 없습니다.\n정확한 이름을 입력하거나 환자 등록을 해주세요.");
                            return;
                        }

                        foundPatientId = Convert.ToInt32(result);

                    }

                    string insertQuery = @"
                INSERT INTO VISIT (VISIT_ID, PATIENT_ID, VISIT_DATE, SYMPTOM, DOCTOR_ID, DEPT)
                VALUES (
                   (SELECT NVL(MAX(VISIT_ID), 0) + 1 FROM VISIT), 
                   :pid, 
                   :vdate, 
                   :symptom, 
                   :docId, 
                   :deptName
                )";

                    using (OracleCommand cmdInsert = new OracleCommand(insertQuery, conn))
                    {
                        cmdInsert.BindByName = true;

                        cmdInsert.Parameters.Add(new OracleParameter("pid", foundPatientId));
                        cmdInsert.Parameters.Add(new OracleParameter("vdate", DateTime.Parse(txtVisitDate.Text)));
                        cmdInsert.Parameters.Add(new OracleParameter("symptom", txtSymptom.Text));
                        cmdInsert.Parameters.Add(new OracleParameter("docId", cboDoctor.SelectedValue));
                        cmdInsert.Parameters.Add(new OracleParameter("deptName", cboDept.Text));

                        if (cmdInsert.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show($"'{inputName}'님 예약이 완료되었습니다");
                            LoadReservationList(inputName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message);
            }
        }

        // 예약 변경 버튼
        private void btnChangeReservation_Click(object sender, EventArgs e)
        {
            if (selectedVisitId == -1)
            {
                MessageBox.Show("변경할 예약을 목록에서 선택해주세요.");
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                    INSERT INTO VISIT (VISIT_ID, PATIENT_ID, VISIT_DATE, SYMPTOM)
                    VALUES (
                       (SELECT NVL(MAX(VISIT_ID), 0) + 1 FROM VISIT), 
                       :pid, 
                       :vdate, 
                       :symptom
                    )";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.BindByName = true;

                    cmd.Parameters.Add(new OracleParameter(":vdate", DateTime.Parse(txtVisitDate.Text)));
                    cmd.Parameters.Add(new OracleParameter(":symptom", txtSymptom.Text));
                    cmd.Parameters.Add(new OracleParameter(":vid", selectedVisitId));
                    cmd.Parameters.Add(new OracleParameter(":pid", patientId));

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("예약 내용이 변경되었습니다.");
                        LoadReservationList();
                        ResetInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("예약 변경 오류: " + ex.Message);
            }
        }

        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            if (selectedVisitId == -1)
            {
                MessageBox.Show("삭제할 예약을 선택해주세요.");
                return;
            }

            if (MessageBox.Show("정말 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    // 부모 데이터(예약) 삭제
                    string deleteMainQuery = "DELETE FROM VISIT WHERE VISIT_ID = :vid AND PATIENT_ID = :pid";
                    OracleCommand cmdMain = new OracleCommand(deleteMainQuery, conn);
                    cmdMain.BindByName = true;
                    cmdMain.Parameters.Add(new OracleParameter(":vid", selectedVisitId));
                    cmdMain.Parameters.Add(new OracleParameter(":pid", patientId));

                    if (cmdMain.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("예약이 삭제되었습니다.");
                        LoadReservationList();
                        ResetInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("예약 삭제 오류: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadReservationList(txtPatientName.Text.Trim());
        }
        private void LoadReservationList(string searchName = "")
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    // 1. 기본 쿼리 (전체 데이터 가져오기)
                    string query = @"
                SELECT V.VISIT_ID, 
                       P.NAME AS PATIENT_NAME,
                       V.VISIT_DATE, 
                       V.SYMPTOM, 
                       D.NAME AS DOCTOR_NAME, 
                       V.DEPT,
                       V.DOCTOR_ID
                FROM VISIT V
                JOIN DOCTOR D ON V.DOCTOR_ID = D.DOCTOR_ID
                JOIN PATIENT P ON V.PATIENT_ID = P.PATIENT_ID ";

                    if (!string.IsNullOrWhiteSpace(searchName))
                    {
                        query += " WHERE P.NAME = :pname ";
                    }

                    query += " ORDER BY V.VISIT_ID ASC";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.BindByName = true; 

                    if (!string.IsNullOrWhiteSpace(searchName))
                    {
                        cmd.Parameters.Add(new OracleParameter("pname", searchName));
                    }

                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "visit");

                    dgvReservation.DataSource = ds.Tables["visit"];

                    // 헤더 설정
                    if (dgvReservation.Columns.Count > 0)
                    {
                        dgvReservation.Columns["VISIT_ID"].HeaderText = "순번";
                        dgvReservation.Columns["PATIENT_NAME"].HeaderText = "환자명";
                        dgvReservation.Columns["VISIT_DATE"].HeaderText = "예약시간";
                        dgvReservation.Columns["SYMPTOM"].HeaderText = "증상";
                        dgvReservation.Columns["DOCTOR_NAME"].HeaderText = "담당의사";
                        dgvReservation.Columns["DEPT"].HeaderText = "진료과";
                        dgvReservation.Columns["DOCTOR_ID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("목록 조회 실패: " + ex.Message);
            }
        }
        private void LoadDepartments()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DEPT_NAME FROM MEDICAL_DEPT ORDER BY DEPT_NAME";

                    OracleDataAdapter da = new OracleDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboDept.DisplayMember = "DEPT_NAME";
                    cboDept.ValueMember = "DEPT_NAME";
                    cboDept.DataSource = dt;

                    cboDept.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("진료과 로드 실패: " + ex.Message);
            }
        }
        private void ResetInputs()
        {
            selectedVisitId = -1;
            txtReservationNumber.Text = "";
            txtVisitDate.Text = "";
            txtSymptom.Text = "";
        }

        private void cboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDept.SelectedIndex == -1 || cboDept.SelectedValue == null) return;

            string selectedDeptName = cboDept.SelectedValue.ToString();

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DOCTOR_ID, NAME FROM DOCTOR WHERE DEPT = :deptName";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add(new OracleParameter(":deptName", selectedDeptName));

                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboDoctor.DataSource = null;
                    cboDoctor.DisplayMember = "NAME";
                    cboDoctor.ValueMember = "DOCTOR_ID";
                    cboDoctor.DataSource = dt;

                    cboDoctor.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("의사 목록 로드 실패: " + ex.Message);
            }
        }
    }
}
