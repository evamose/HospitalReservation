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
    public partial class Form9 : Form
    {
        private readonly string connectionString =
            "User Id=HOSPITAL_USER;Password=1234;" +
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));";

        int myPatientId = -1;     // 로그인(본인확인)된 환자 ID
        int selectedVisitId = -1; // 수정/삭제할 예약 번호

        public Form9()
        {
            InitializeComponent();
            cboDept.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            LoadDepartments();
        }

        private bool CheckMyIdentity()
        {
            // 1. 빈칸 체크 (txtPhone은 전화번호 입력칸)
            if (string.IsNullOrWhiteSpace(txtPatientName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("이름과 전화번호를 모두 입력해주세요.");
                return false;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    // 이름과 전화번호가 일치하는지 확인
                    string query = "SELECT PATIENT_ID FROM PATIENT WHERE NAME = :pname AND PHONE = :phone";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add(new OracleParameter("pname", txtPatientName.Text.Trim()));
                    cmd.Parameters.Add(new OracleParameter("phone", txtPhone.Text.Trim()));

                    object result = cmd.ExecuteScalar();

                    // [재진] 정보가 있음 -> 내 ID 저장하고 True 반환
                    if (result != null)
                    {
                        myPatientId = Convert.ToInt32(result);
                        return true;
                    }
                    // [초진] 정보가 없음 -> PatientReservationForm (등록 폼) 열기
                    else
                    {
                        if (MessageBox.Show("환자 정보가 없습니다. 환자 등록을 하시겠습니까?", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            // ★ 여기가 환자 등록 폼(PatientReservationForm)으로 이동하는 부분
                            Form10 f = new Form10();
                            f.Show();
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류: " + ex.Message);
                return false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 본인 확인 통과 시에만 조회 실행
            if (CheckMyIdentity())
            {
                LoadMyReservations();
                MessageBox.Show($"{txtPatientName.Text}님, 안녕하세요.");
            }
        }
        private void LoadMyReservations()
        {
            if (myPatientId == -1) return;

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    // ★ 내 ID(myPatientId)로만 조회
                    string query = @"
                        SELECT V.VISIT_ID, V.VISIT_DATE, V.SYMPTOM, D.NAME AS DOCTOR_NAME, V.DEPT, V.DOCTOR_ID
                        FROM VISIT V
                        JOIN DOCTOR D ON V.DOCTOR_ID = D.DOCTOR_ID
                        WHERE V.PATIENT_ID = :pid
                        ORDER BY V.VISIT_DATE DESC";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add(new OracleParameter("pid", myPatientId));

                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "visit");

                    dgvReservation.DataSource = ds.Tables["visit"];

                    // 헤더 설정 등은 필요시 추가
                    if (dgvReservation.Columns.Count > 0)
                    {
                        dgvReservation.Columns["VISIT_ID"].HeaderText = "예약번호";
                        dgvReservation.Columns["VISIT_DATE"].HeaderText = "예약시간";
                        dgvReservation.Columns["SYMPTOM"].HeaderText = "증상";
                        dgvReservation.Columns["DOCTOR_NAME"].HeaderText = "담당의사";
                        dgvReservation.Columns["DEPT"].HeaderText = "진료과";
                        dgvReservation.Columns["DOCTOR_ID"].Visible = false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("조회 실패: " + ex.Message); }
        }

        private void btnCheckReservation_Click(object sender, EventArgs e)
        {
            // 1. 인증 안 됐으면 인증부터 (없으면 등록폼 뜸)
            if (myPatientId == -1)
            {
                if (!CheckMyIdentity()) return;
            }

            // 2. 입력값 확인
            if (string.IsNullOrWhiteSpace(txtVisitDate.Text) || cboDoctor.SelectedValue == null)
            {
                MessageBox.Show("예약 시간과 의사를 선택해주세요.");
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO VISIT (VISIT_ID, PATIENT_ID, VISIT_DATE, SYMPTOM, DOCTOR_ID, DEPT)
                        VALUES ( (SELECT NVL(MAX(VISIT_ID), 0) + 1 FROM VISIT), :pid, :vdate, :symptom, :docId, :deptName )";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add(new OracleParameter("pid", myPatientId));
                    cmd.Parameters.Add(new OracleParameter("vdate", DateTime.Parse(txtVisitDate.Text)));
                    cmd.Parameters.Add(new OracleParameter("symptom", txtSymptom.Text));
                    cmd.Parameters.Add(new OracleParameter("docId", cboDoctor.SelectedValue));
                    cmd.Parameters.Add(new OracleParameter("deptName", cboDept.Text));

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("예약되었습니다.");
                        LoadMyReservations();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("예약 오류: " + ex.Message); }
        }

        private void btnChangeReservation_Click(object sender, EventArgs e)
        {
            if (selectedVisitId == -1) return;

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    // 내 ID(:pid) 조건 필수
                    string query = @"UPDATE VISIT SET VISIT_DATE=:vdate, SYMPTOM=:sym, DOCTOR_ID=:docId, DEPT=:dept 
                                     WHERE VISIT_ID=:vid AND PATIENT_ID=:pid";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add(new OracleParameter("vdate", DateTime.Parse(txtVisitDate.Text)));
                    cmd.Parameters.Add(new OracleParameter("sym", txtSymptom.Text));
                    cmd.Parameters.Add(new OracleParameter("docId", cboDoctor.SelectedValue));
                    cmd.Parameters.Add(new OracleParameter("dept", cboDept.Text));
                    cmd.Parameters.Add(new OracleParameter("vid", selectedVisitId));
                    cmd.Parameters.Add(new OracleParameter("pid", myPatientId));

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("변경되었습니다.");
                        LoadMyReservations();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            if (selectedVisitId == -1) return;
            if (MessageBox.Show("취소하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No) return;

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM VISIT WHERE VISIT_ID=:vid AND PATIENT_ID=:pid";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add(new OracleParameter("vid", selectedVisitId));
                    cmd.Parameters.Add(new OracleParameter("pid", myPatientId));

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("취소되었습니다.");
                        LoadMyReservations();
                        selectedVisitId = -1;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
            catch { }
        }

        private void cboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDept.SelectedIndex == -1 || cboDept.SelectedValue == null) return;
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DOCTOR_ID, NAME FROM DOCTOR WHERE DEPT = :deptName";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add(new OracleParameter("deptName", cboDept.SelectedValue.ToString()));
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
            catch { }
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
                    txtVisitDate.Text = row.Cells["VISIT_DATE"].Value.ToString();
                    txtSymptom.Text = row.Cells["SYMPTOM"].Value.ToString();
                    cboDept.SelectedValue = row.Cells["DEPT"].Value.ToString();
                    cboDoctor.SelectedValue = row.Cells["DOCTOR_ID"].Value;
                }
            }
            catch { }
        }
    }
}
