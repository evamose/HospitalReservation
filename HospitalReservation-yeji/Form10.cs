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
    public partial class Form10 : Form
    {
        private readonly string connectionString =
            "User Id=HOSPITAL_USER;Password=1234;" +
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));";

        int myPatientId = -1;      // 로그인한 환자 번호를 기억할 변수
        int selectedVisitId = -1;  // 선택한 예약 번호를 기억할 변수
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            cmbGender.Items.Clear();
            cmbGender.Items.Add("남");
            cmbGender.Items.Add("여");
            cmbGender.SelectedIndex = 0; // 기본 선택

            ShowNextPatientId();
        }
        private void ShowNextPatientId()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    // 가장 큰 번호 + 1 가져오기
                    string query = "SELECT NVL(MAX(PATIENT_ID), 0) + 1 FROM PATIENT";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    object result = cmd.ExecuteScalar();

                    txtPatientId.Text = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ID 생성 오류: " + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
        string.IsNullOrWhiteSpace(mtxtPhone.Text) ||
        string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("이름, 연락처, 주소는 필수 입력 사항입니다.");
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    // 2. 트랜잭션 시작 (안전한 저장을 위해)
                    using (OracleTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string query = @"
                        INSERT INTO PATIENT (PATIENT_ID, NAME, BIRTH, GENDER, PHONE, ADDRESS)
                        VALUES (:pid, :pname, :birth, :gender, :phone, :addr)";

                            OracleCommand cmd = new OracleCommand(query, conn);
                            cmd.Transaction = transaction; // 트랜잭션 연결
                            cmd.BindByName = true;

                            // 파라미터 연결 (Trim으로 공백 제거 필수!)
                            cmd.Parameters.Add(new OracleParameter("pid", int.Parse(txtPatientId.Text)));
                            cmd.Parameters.Add(new OracleParameter("pname", txtName.Text.Trim())); // 공백제거
                            cmd.Parameters.Add(new OracleParameter("birth", dtpBirth.Value.Date));
                            cmd.Parameters.Add(new OracleParameter("gender", cmbGender.Text));
                            cmd.Parameters.Add(new OracleParameter("phone", mtxtPhone.Text.Trim())); // 공백제거
                            cmd.Parameters.Add(new OracleParameter("addr", txtAddress.Text.Trim()));

                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                // ★★★ [핵심] DB에 영구 저장 확정 ★★★
                                transaction.Commit();

                                MessageBox.Show("환자 등록이 완료되었습니다!");
                                this.Close(); // 폼 닫고 예약창으로 돌아감
                            }
                        }
                        catch (Exception ex)
                        {
                            // 에러나면 취소
                            transaction.Rollback();
                            MessageBox.Show("저장 중 오류 발생: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB 연결 실패: " + ex.Message);
            }
        }
        private bool CheckMyIdentity()
        {
            // 1. 이름과 전화번호 입력 확인
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(mtxtPhone.Text))
            {
                MessageBox.Show("본인 확인을 위해 이름과 전화번호를 모두 입력해주세요.");
                return false;
            }

            // 입력값의 앞뒤 공백 제거
            string inputName = txtName.Text.Trim();
            string inputPhone = mtxtPhone.Text.Trim();

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();

                    // =========================================================
                    // [수정] SQL 자체에서 TRIM()을 써서 DB 공백 문제 원천 차단
                    // 이름과 전화번호가 정확히 일치해야 함
                    // =========================================================
                    string query = @"
                SELECT PATIENT_ID 
                FROM PATIENT 
                WHERE TRIM(NAME) = :pname 
                  AND TRIM(PHONE) = :phone";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.BindByName = true; // ★ 필수 설정

                    // 파라미터 값 바인딩
                    cmd.Parameters.Add(new OracleParameter("pname", inputName));
                    cmd.Parameters.Add(new OracleParameter("phone", inputPhone));

                    // [디버깅] 이 메시지가 뜨면 내가 입력한 값과 DB 값을 비교해보세요.
                    // 확인 후에는 주석 처리(//) 하세요.
                    // MessageBox.Show($"검색 시도\n이름: [{inputName}]\n전화번호: [{inputPhone}]");

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        // [성공]
                        myPatientId = Convert.ToInt32(result);
                        return true;
                    }
                    else
                    {
                        // [실패] - 원인을 파악하기 위해 잠시 상세 메시지 띄움
                        if (MessageBox.Show($"환자 정보를 찾을 수 없습니다.\n\n" +
                            $"입력한 이름: {inputName}\n" +
                            $"입력한 번호: {inputPhone}\n\n" +
                            $"※ 등록할 때 입력한 전화번호(하이픈 - 포함 여부)와 정확히 일치합니까?\n" +
                            $"환자 등록 화면으로 이동하시겠습니까?",
                            "본인 확인 실패", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Form10 regForm = new Form10();
                            regForm.ShowDialog();
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message);
                return false;
            }
        }
    }
}
