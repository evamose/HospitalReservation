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
            this.btnDeleteVisit = new System.Windows.Forms.Button();
            this.btnAddVisit = new System.Windows.Forms.Button();
            this.dgvVisit = new System.Windows.Forms.DataGridView();
            this.dtpVisitDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiseaseCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDoctorId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDept = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisit)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteVisit
            // 
            this.btnDeleteVisit.Location = new System.Drawing.Point(399, 513);
            this.btnDeleteVisit.Name = "btnDeleteVisit";
            this.btnDeleteVisit.Size = new System.Drawing.Size(178, 44);
            this.btnDeleteVisit.TabIndex = 95;
            this.btnDeleteVisit.Text = "삭제";
            this.btnDeleteVisit.UseVisualStyleBackColor = true;
            this.btnDeleteVisit.Click += new System.EventHandler(this.btnDeleteVisit_Click);
            // 
            // btnAddVisit
            // 
            this.btnAddVisit.Location = new System.Drawing.Point(191, 513);
            this.btnAddVisit.Name = "btnAddVisit";
            this.btnAddVisit.Size = new System.Drawing.Size(178, 44);
            this.btnAddVisit.TabIndex = 94;
            this.btnAddVisit.Text = "추가";
            this.btnAddVisit.UseVisualStyleBackColor = true;
            this.btnAddVisit.Click += new System.EventHandler(this.btnAddVisit_Click);
            // 
            // dgvVisit
            // 
            this.dgvVisit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisit.Location = new System.Drawing.Point(43, 25);
            this.dgvVisit.Name = "dgvVisit";
            this.dgvVisit.RowHeadersWidth = 82;
            this.dgvVisit.RowTemplate.Height = 37;
            this.dgvVisit.Size = new System.Drawing.Size(657, 286);
            this.dgvVisit.TabIndex = 93;
            // 
            // dtpVisitDate
            // 
            this.dtpVisitDate.Location = new System.Drawing.Point(154, 388);
            this.dtpVisitDate.Name = "dtpVisitDate";
            this.dtpVisitDate.Size = new System.Drawing.Size(200, 35);
            this.dtpVisitDate.TabIndex = 92;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 439);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 24);
            this.label6.TabIndex = 91;
            this.label6.Text = "진단 내용";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Location = new System.Drawing.Point(159, 439);
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.Size = new System.Drawing.Size(537, 35);
            this.txtDiagnosis.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 24);
            this.label3.TabIndex = 89;
            this.label3.Text = "질병 코드";
            // 
            // txtDiseaseCode
            // 
            this.txtDiseaseCode.Location = new System.Drawing.Point(494, 392);
            this.txtDiseaseCode.Name = "txtDiseaseCode";
            this.txtDiseaseCode.Size = new System.Drawing.Size(202, 35);
            this.txtDiseaseCode.TabIndex = 88;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 24);
            this.label4.TabIndex = 87;
            this.label4.Text = "진료 일자";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 86;
            this.label1.Text = "담당의";
            // 
            // txtDoctorId
            // 
            this.txtDoctorId.Location = new System.Drawing.Point(494, 344);
            this.txtDoctorId.Name = "txtDoctorId";
            this.txtDoctorId.Size = new System.Drawing.Size(202, 35);
            this.txtDoctorId.TabIndex = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 84;
            this.label2.Text = "진료과";
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(152, 344);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(202, 35);
            this.txtDept.TabIndex = 83;
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

        private System.Windows.Forms.Button btnDeleteVisit;
        private System.Windows.Forms.Button btnAddVisit;
        private System.Windows.Forms.DataGridView dgvVisit;
        private System.Windows.Forms.DateTimePicker dtpVisitDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiseaseCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDoctorId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDept;
    }
}