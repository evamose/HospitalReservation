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
    public enum DoctorFormMode
    {
        Create,
        Edit
    }

    public partial class DoctorDetailForm : Form
    {
        public DoctorFormMode Mode { get; set; } = DoctorFormMode.Create;

        // DB 연결 문자열
        private readonly string connectionString =
            "User Id=HOSPITAL_USER;" +
            "Password=1234;" +
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));";

        // 폼 외부에서 읽어갈 수 있는 속성들
        public int? DoctorId
        {
            get
            {
                if (int.TryParse(txtDoctorId.Text, out int id)) return id;
                return null;
            }
            set
            {
                txtDoctorId.Text = value?.ToString() ?? "";
            }
        }

        public string DoctorName => txtName.Text;
        public string Department => cmbDept.SelectedItem?.ToString();
        public string Phone => mtxtPhone.Text;
        public string Email => txtEmail.Text;
        public string Room => txtRoom.Text;
        public string LicenseNumber => txtLicense.Text;
        public string Note => txtNote.Text;

        public DoctorDetailForm()
        {
            InitializeComponent();
        }

        // 폼 로드시 제목/기본값 설정 (디자이너에서 Load 이벤트에 연결해야 함)
        private void DoctorDetailForm_Load(object sender, EventArgs e)
        {
            if (Mode == DoctorFormMode.Create)
            {
                this.Text = "의사 등록";

                // 새 의사 ID 미리 생성해서 텍스트박스에 보여주기
                int newId = GenerateNewDoctorId();
                DoctorId = newId;              // 프로퍼티라서 txtDoctorId.Text 도 같이 세팅됨

                // 진료과 기본 선택
                if (cmbDept.Items.Count > 0 && cmbDept.SelectedIndex < 0)
                    cmbDept.SelectedIndex = 0;
            }
            else
            {
                this.Text = "의사 정보 수정";
            }
        }

        /// <summary>
        /// 새 의사 ID를 MAX(DOCTOR_ID)+1 방식으로 자동 발급
        /// </summary>
        /// <returns></returns>
        private int GenerateNewDoctorId()
        {
            using (var conn = new OracleConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT NVL(MAX(DOCTOR_ID), 0) + 1 AS NEW_ID FROM DOCTOR";

                using (var cmd = new OracleCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        /// <summary>
        /// 외부(예: Form4)에서 호출해서 의사 정보를 폼에 채우는 함수
        /// </summary>
        public void LoadDoctor(int doctorId)
        {
            try
            {
                using (var conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                        SELECT DOCTOR_ID,
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
                        WHERE DOCTOR_ID = :id";

                    using (var cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add(":id", doctorId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Mode = DoctorFormMode.Edit;

                                DoctorId = Convert.ToInt32(reader["DOCTOR_ID"]);
                                txtName.Text = reader["NAME"].ToString();

                                if (reader["BIRTH"] != DBNull.Value)
                                    dtpBirth.Value = Convert.ToDateTime(reader["BIRTH"]);

                                mtxtPhone.Text = reader["PHONE"]?.ToString();
                                txtEmail.Text = reader["EMAIL"]?.ToString();

                                string address = reader["ADDRESS"]?.ToString();
                                txtAddress.Text = address;
                                txtAddress2.Text = "";  // 상세 주소 분리 안 했다면 비워두기

                                txtLicense.Text = reader["LICENSE_NO"]?.ToString();

                                string dept = reader["DEPT"]?.ToString();
                                if (!string.IsNullOrEmpty(dept) &&
                                    cmbDept.Items.Contains(dept))
                                {
                                    cmbDept.SelectedItem = dept;
                                }

                                txtRoom.Text = reader["ROOM"]?.ToString();
                                txtNote.Text = reader["NOTE"]?.ToString();
                            }
                            else
                            {
                                MessageBox.Show("해당 의사 정보를 찾을 수 없습니다.");
                            }
                        }
                    }
                }

                // 수정모드로 표시
                this.Text = "의사 정보 수정";
            }
            catch (Exception ex)
            {
                MessageBox.Show("의사 정보 불러오기 오류: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. 기본 유효성 검사 (필요시 더 추가 가능)
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("의사 이름을 입력해주세요.");
                txtName.Focus();
                return;
            }

            if (cmbDept.SelectedIndex < 0)
            {
                MessageBox.Show("진료과를 선택해주세요.");
                cmbDept.DroppedDown = true;
                return;
            }

            // 마스크 문자 제거 후 공백 체크
            string phoneDigits = mtxtPhone.Text.Replace("_", "").Replace("-", "").Trim();
            if (string.IsNullOrWhiteSpace(phoneDigits))
            {
                MessageBox.Show("연락처를 입력해주세요.");
                mtxtPhone.Focus();
                return;
            }

            // 2. 공통 데이터 준비
            int doctorId;
            if (Mode == DoctorFormMode.Create)
            {
                // 새 ID 발급
                doctorId = GenerateNewDoctorId();
                DoctorId = doctorId;           // 프로퍼티 & 텍스트박스에 반영
            }
            else
            {
                if (DoctorId == null)
                {
                    MessageBox.Show("수정 모드인데 의사 ID가 없습니다.");
                    return;
                }
                doctorId = DoctorId.Value;
            }

            DateTime birth = dtpBirth.Value;
            string fullAddress = (txtAddress.Text + " " + txtAddress2.Text).Trim();

            // 3. DB INSERT / UPDATE
            try
            {
                using (var conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    string sql;

                    if (Mode == DoctorFormMode.Create)
                    {
                        sql = @"
                            INSERT INTO DOCTOR
                                (DOCTOR_ID, NAME, BIRTH, PHONE, EMAIL,
                                 ADDRESS, LICENSE_NO, DEPT, ROOM, NOTE)
                            VALUES
                                (:id, :name, :birth, :phone, :email,
                                 :address, :license, :dept, :room, :note)";
                    }
                    else
                    {
                        sql = @"
                            UPDATE DOCTOR
                            SET NAME       = :name,
                                BIRTH      = :birth,
                                PHONE      = :phone,
                                EMAIL      = :email,
                                ADDRESS    = :address,
                                LICENSE_NO = :license,
                                DEPT       = :dept,
                                ROOM       = :room,
                                NOTE       = :note
                            WHERE DOCTOR_ID = :id";
                    }

                    using (var cmd = new OracleCommand(sql, conn))
                    {
                        // 파라미터 순서 = SQL에 적힌 순서와 맞추기
                        cmd.Parameters.Add(":id", doctorId);
                        cmd.Parameters.Add(":name", txtName.Text);
                        cmd.Parameters.Add(":birth", birth);
                        cmd.Parameters.Add(":phone", mtxtPhone.Text);
                        cmd.Parameters.Add(":email", (object)txtEmail.Text ?? DBNull.Value);
                        cmd.Parameters.Add(":address", (object)fullAddress ?? DBNull.Value);
                        cmd.Parameters.Add(":license", (object)txtLicense.Text ?? DBNull.Value);
                        cmd.Parameters.Add(":dept", cmbDept.SelectedItem.ToString());
                        cmd.Parameters.Add(":room", (object)txtRoom.Text ?? DBNull.Value);
                        cmd.Parameters.Add(":note", (object)txtNote.Text ?? DBNull.Value);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            // 성공 → 부모(Form4)에서 DialogResult.OK 보고 메시지/리스트 갱신
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("의사 정보 저장에 실패했습니다.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("의사 정보 저장 중 오류 발생: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnWorkSchedule_Click(object sender, EventArgs e)
        {
            if (DoctorId == null)
            {
                MessageBox.Show("먼저 의사 정보를 저장한 후 근무 스케줄을 설정해주세요.");
                return;
            }

            using (var dlg = new Form6(DoctorId.Value))
            {
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.ShowDialog(this);
            }
        }
    }
}
