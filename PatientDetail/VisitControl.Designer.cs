namespace HospitalReservation
{
    partial class VisitControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDoctorId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiseaseCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.dtpVisitDate = new System.Windows.Forms.DateTimePicker();
            this.dgvVisit = new System.Windows.Forms.DataGridView();
            this.btnAddVisit = new System.Windows.Forms.Button();
            this.btnDeleteVisit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisit)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 38;
            this.label2.Text = "진료과";
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(147, 347);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(202, 35);
            this.txtDept.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(376, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 40;
            this.label1.Text = "담당의";
            // 
            // txtDoctorId
            // 
            this.txtDoctorId.Location = new System.Drawing.Point(489, 347);
            this.txtDoctorId.Name = "txtDoctorId";
            this.txtDoctorId.Size = new System.Drawing.Size(202, 35);
            this.txtDoctorId.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 398);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 24);
            this.label3.TabIndex = 44;
            this.label3.Text = "질병 코드";
            // 
            // txtDiseaseCode
            // 
            this.txtDiseaseCode.Location = new System.Drawing.Point(489, 395);
            this.txtDiseaseCode.Name = "txtDiseaseCode";
            this.txtDiseaseCode.Size = new System.Drawing.Size(202, 35);
            this.txtDiseaseCode.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 24);
            this.label4.TabIndex = 42;
            this.label4.Text = "진료 일자";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 442);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 24);
            this.label6.TabIndex = 46;
            this.label6.Text = "진단 내용";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Location = new System.Drawing.Point(154, 442);
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.Size = new System.Drawing.Size(537, 35);
            this.txtDiagnosis.TabIndex = 45;
            // 
            // dtpVisitDate
            // 
            this.dtpVisitDate.Location = new System.Drawing.Point(149, 391);
            this.dtpVisitDate.Name = "dtpVisitDate";
            this.dtpVisitDate.Size = new System.Drawing.Size(200, 35);
            this.dtpVisitDate.TabIndex = 47;
            // 
            // dgvVisit
            // 
            this.dgvVisit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisit.Location = new System.Drawing.Point(38, 28);
            this.dgvVisit.Name = "dgvVisit";
            this.dgvVisit.RowHeadersWidth = 82;
            this.dgvVisit.RowTemplate.Height = 37;
            this.dgvVisit.Size = new System.Drawing.Size(657, 286);
            this.dgvVisit.TabIndex = 67;
            // 
            // btnAddVisit
            // 
            this.btnAddVisit.Location = new System.Drawing.Point(186, 516);
            this.btnAddVisit.Name = "btnAddVisit";
            this.btnAddVisit.Size = new System.Drawing.Size(178, 44);
            this.btnAddVisit.TabIndex = 68;
            this.btnAddVisit.Text = "추가";
            this.btnAddVisit.UseVisualStyleBackColor = true;
            // 
            // btnDeleteVisit
            // 
            this.btnDeleteVisit.Location = new System.Drawing.Point(394, 516);
            this.btnDeleteVisit.Name = "btnDeleteVisit";
            this.btnDeleteVisit.Size = new System.Drawing.Size(178, 44);
            this.btnDeleteVisit.TabIndex = 69;
            this.btnDeleteVisit.Text = "삭제";
            this.btnDeleteVisit.UseVisualStyleBackColor = true;
            // 
            // VisitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteVisit);
            this.Controls.Add(this.btnAddVisit);
            this.Controls.Add(this.dgvVisit);
            this.Controls.Add(this.dtpVisitDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDiagnosis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDiseaseCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDoctorId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDept);
            this.Name = "VisitControl";
            this.Size = new System.Drawing.Size(734, 582);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDoctorId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiseaseCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.DateTimePicker dtpVisitDate;
        private System.Windows.Forms.DataGridView dgvVisit;
        private System.Windows.Forms.Button btnAddVisit;
        private System.Windows.Forms.Button btnDeleteVisit;
    }
}
