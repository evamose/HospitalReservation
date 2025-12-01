using HospitalReservation;
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
    public enum FormMode
    {
        Create,
        Edit
    }
    public partial class PatientDetailForm : Form
    {
        public FormMode Mode { get; set; } = FormMode.Create;

        // Form3에서 썼던 것과 동일한 연결 문자열
        private string connectionString =
            "User Id=HOSPITAL_USER;" +
            "Password=1234;" +
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));";

        private void LoadDoctorList()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT DOCTOR_ID, NAME
                        FROM DOCTOR
                        ORDER BY DOCTOR_ID
                    ";

                    OracleDataAdapter da = new OracleDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbDoctor.DisplayMember = "NAME";       // 화면에 보이는 값
                    cmbDoctor.ValueMember = "DOCTOR_ID";    // 실제 저장할 값
                    cmbDoctor.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("의사 목록 불러오기 오류: " + ex.Message);
            }
        }

        private void GenerateNewPatientId()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    // 현재 PATIENT_ID 중 최대값 + 1 을 새 ID로 사용
                    string sql = @"SELECT NVL(MAX(PATIENT_ID), 0) + 1 AS NEW_ID FROM PATIENT";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        txtPatientId.Text = Convert.ToString(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("새 환자 ID 생성 중 오류: " + ex.Message);
            }
        }


        // 외부에서 읽을 수 있는 속성들 (저장 버튼 누른 후에 사용)
        public int? PatientId
        {
            get
            {
                if (int.TryParse(txtPatientId.Text, out int id))
                    return id;
                return null;
            }
            set
            {
                txtPatientId.Text = value?.ToString() ?? "";
            }
        }

        public string PatientName => txtName.Text;
        public DateTime BirthDate => dtpBirth.Value;
        public string Gender => cmbGender.SelectedItem?.ToString();
        public string Phone => mtxtPhone.Text;
        public string Address => txtAddress2.Text;                 
        public string VisitReason => txtVisitReason.Text;
        public object SelectedDoctorId => cmbDoctor.SelectedValue; // 나중에 DOCTOR_ID 바인딩 예정

        public PatientDetailForm()
        {
            InitializeComponent();
        }

        // PatientDetailForm.cs 안에 추가
        public void LoadPatient(int patientId)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                        SELECT PATIENT_ID, NAME, BIRTH, GENDER, PHONE, ADDRESS, 
                               VISIT_REASON, DOCTOR_NO
                        FROM PATIENT
                        WHERE PATIENT_ID = :id
                    ";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(":id", patientId);

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 수정 모드로 변경
                                Mode = FormMode.Edit;

                                PatientId = Convert.ToInt32(reader["PATIENT_ID"]);

                                txtName.Text = reader["NAME"].ToString();

                                if (!(reader["BIRTH"] is DBNull))
                                    dtpBirth.Value = (DateTime)reader["BIRTH"];

                                // 성별
                                string gender = reader["GENDER"]?.ToString();
                                if (!string.IsNullOrEmpty(gender))
                                    cmbGender.SelectedItem = gender;

                                // 연락처 / 주소
                                mtxtPhone.Text = reader["PHONE"]?.ToString();
                                txtAddress.Text = reader["ADDRESS"].ToString();
                                txtAddress2.Text = "";   // 세부 주소 따로 쓸 거면 여기에

                                // 방문 사유
                                txtVisitReason.Text = reader["VISIT_REASON"]?.ToString();

                                // 담당 의사 콤보 채우기 + 선택
                                LoadDoctorList();   // 먼저 목록 채우고

                                if (!(reader["DOCTOR_NO"] is DBNull))
                                {
                                    int doctorNo = Convert.ToInt32(reader["DOCTOR_NO"]);
                                    cmbDoctor.SelectedValue = doctorNo;
                                }
                            }
                            else
                            {
                                MessageBox.Show("해당 환자를 찾을 수 없습니다.");
                            }
                        }
                    }
                }

                // 제목/ID 표시 조정
                this.Text = "환자 정보 수정";
                txtPatientId.ReadOnly = true;
                txtPatientId.Visible = true;
                lblPatientId.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("환자 정보 불러오기 오류: " + ex.Message);
            }
        }

        private void PatientDetailForm_Load(object sender, EventArgs e)
        {
            if (Mode == FormMode.Create)
            {
                // 신규 환자일 때만 여기서 의사 목록 로드
                LoadDoctorList();

                this.Text = "환자 등록";
                txtPatientId.ReadOnly = true;
                txtPatientId.Visible = true;
                lblPatientId.Visible = true;

                GenerateNewPatientId();
            }
            else
            {
                this.Text = "환자 정보 수정";
                txtPatientId.ReadOnly = true;
                txtPatientId.Visible = true;
                lblPatientId.Visible = true;
                // 수정 모드에서는 LoadPatient()에서 LoadDoctorList()를 이미 호출함
            }

            if (cmbGender.Items.Count > 0 && cmbGender.SelectedIndex < 0)
                cmbGender.SelectedIndex = 0;

            // 오른쪽 패널에 기본으로 진료 탭 띄우기
            panelDetail.Controls.Clear();
            panelDetail.Controls.Add(visitControl);
            visitControl.Dock = DockStyle.Fill;

            // 아직 환자 ID가 없는 신규 등록 모드일 경우
            if (Mode == FormMode.Create)
            {
                visitControl.PatientId = null;
                prescControl.PatientId = null;

                // 필요하다면 버튼 비활성화
                btnVisitTab.Enabled = false;
                btnPrescTab.Enabled = false;
            }
            else
            {
                // 수정 모드일 경우 PatientId는 LoadPatient()에서 세팅됨
                btnVisitTab.Enabled = true;
                btnPrescTab.Enabled = true;

                visitControl.PatientId = PatientId;
                prescControl.PatientId = PatientId;

                visitControl.LoadVisits();
            }

        }


        /// <summary>
        /// 저장 버튼 클릭: 이 안에서 DB INSERT/UPDATE 실행
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. 기본 유효성 검사
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("이름을 입력해주세요.");
                txtName.Focus();
                return;
            }

            // 생년월일: dtpBirth는 기본값, 미래값 막기
            if (dtpBirth.Value.Date > DateTime.Today)
            {
                MessageBox.Show("생년월일이 올바르지 않습니다.");
                dtpBirth.Focus();
                return;
            }

            // 성별: 콤보박스 선택 여부 확인
            if (cmbGender.SelectedIndex < 0)
            {
                MessageBox.Show("성별을 선택해주세요.");
                cmbGender.DroppedDown = true;
                return;
            }

            // 전화번호: 마스크 박스가 "   -    -    " 이런 빈값인지 체크
            string phone = mtxtPhone.Text.Replace("_", "").Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("전화번호를 입력해주세요.");
                mtxtPhone.Focus();
                return;
            }

            // 주소 (txtAddress or txtAddress2 중 어떤 걸 메인으로 쓸지 선택)
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("주소를 입력해주세요.");
                txtAddress.Focus();
                return;
            }

            // 여기서 환자 ID가 숫자인지만 한 번 확인 (자동 생성된 값이니까 입력 요구 X)
            if (!int.TryParse(txtPatientId.Text, out int patientId))
            {
                MessageBox.Show("환자 ID 생성에 오류가 발생했습니다.");
                return;
            }

            // 담당 의사 선택 여부는 선택적으로만 체크
            if (cmbDoctor.SelectedIndex < 0)
            {
                var result = MessageBox.Show(
                    "담당 의사를 선택하지 않았습니다. 그대로 저장할까요?",
                    "확인",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;
            }

            // 2. DB 저장 (INSERT 또는 UPDATE)
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string query;

                    if (Mode == FormMode.Create)
                    {
                        // INSERT
                        query = @"
                            INSERT INTO PATIENT
                                (PATIENT_ID, NAME, BIRTH, GENDER, PHONE, ADDRESS, VISIT_REASON, DOCTOR_NO)
                            VALUES
                                (:id, :name, :birth, :gender, :phone, :address, :reason, :doctor)
                        ";
                    }
                    else
                    {
                        // EDIT 모드: UPDATE
                        if (PatientId == null)
                        {
                            MessageBox.Show("수정 모드인데 환자 ID가 없습니다.");
                            return;
                        }

                        query = @"
                            UPDATE PATIENT
                            SET NAME        = :name,
                                BIRTH       = :birth,
                                GENDER      = :gender,
                                PHONE       = :phone,
                                ADDRESS     = :address,
                                VISIT_REASON= :reason,
                                DOCTOR_NO   = :doctor
                            WHERE PATIENT_ID = :id
                        ";
                    }

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // 공통 파라미터
                        cmd.Parameters.Add(":name", txtName.Text);
                        cmd.Parameters.Add(":birth", dtpBirth.Value);
                        cmd.Parameters.Add(":gender", cmbGender.SelectedItem.ToString());
                        cmd.Parameters.Add(":phone", mtxtPhone.Text);
                        cmd.Parameters.Add(":address", txtAddress.Text);
                        cmd.Parameters.Add(":reason", txtVisitReason.Text);
                        cmd.Parameters.Add(":doctor", SelectedDoctorId ?? (object)DBNull.Value);
                        cmd.Parameters.Add(":id", patientId);
                        
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            // DB 저장 성공
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("환자 정보 저장에 실패했습니다.");
                            // DialogResult를 변경하지 않으면 폼은 그대로 유지됨
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("환자 정보 저장 중 오류 발생: " + ex.Message);
                // 오류가 나면 폼을 닫지 않고 그대로 유지 (사용자가 수정 가능)
            }
        }

        // 취소 버튼
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Panel부분
        private VisitControl visitControl = new VisitControl();
        private PrescriptionControl prescControl = new PrescriptionControl();

        private void btnVisitTab_Click(object sender, EventArgs e)
        {
            if (PatientId == null)
            {
                MessageBox.Show("먼저 환자 정보를 저장한 후 진료 내역을 사용할 수 있습니다.");
                return;
            }

            panelDetail.Controls.Clear();
            panelDetail.Controls.Add(visitControl);
            visitControl.Dock = DockStyle.Fill;

            visitControl.PatientId = PatientId;
            visitControl.LoadVisits();

            HighlightTabButton(btnVisitTab);
        }

        private void btnPrescTab_Click(object sender, EventArgs e)
        {
            if (PatientId == null)
            {
                MessageBox.Show("먼저 환자 정보를 저장한 후 처방 내역을 사용할 수 있습니다.");
                return;
            }

            panelDetail.Controls.Clear();
            panelDetail.Controls.Add(prescControl);
            prescControl.Dock = DockStyle.Fill;

            prescControl.PatientId = PatientId;
            prescControl.LoadPrescriptions();

            HighlightTabButton(btnPrescTab);
        }

        private void HighlightTabButton(Button active)
        {
            foreach (var btn in new[] { btnVisitTab, btnPrescTab })
            {
                btn.BackColor = (btn == active) ? Color.White : Color.Gainsboro;
                btn.FlatAppearance.BorderColor = (btn == active) ? Color.DodgerBlue : Color.Silver;
            }
        }

    }

}
