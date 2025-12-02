namespace HospitalReservation
{
    partial class PrescriptionControl
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
            this.dtpPrescDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDeletePresc = new System.Windows.Forms.Button();
            this.btnAddPresc = new System.Windows.Forms.Button();
            this.dgvPrescription = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMethod = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimesPerDay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDosage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDrugName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescription)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpPrescDate
            // 
            this.dtpPrescDate.Location = new System.Drawing.Point(493, 442);
            this.dtpPrescDate.Name = "dtpPrescDate";
            this.dtpPrescDate.Size = new System.Drawing.Size(200, 35);
            this.dtpPrescDate.TabIndex = 104;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 103;
            this.label4.Text = "처방일자";
            // 
            // btnDeletePresc
            // 
            this.btnDeletePresc.Location = new System.Drawing.Point(400, 506);
            this.btnDeletePresc.Name = "btnDeletePresc";
            this.btnDeletePresc.Size = new System.Drawing.Size(178, 44);
            this.btnDeletePresc.TabIndex = 102;
            this.btnDeletePresc.Text = "삭제";
            this.btnDeletePresc.UseVisualStyleBackColor = true;
            // 
            // btnAddPresc
            // 
            this.btnAddPresc.Location = new System.Drawing.Point(192, 506);
            this.btnAddPresc.Name = "btnAddPresc";
            this.btnAddPresc.Size = new System.Drawing.Size(178, 44);
            this.btnAddPresc.TabIndex = 101;
            this.btnAddPresc.Text = "추가";
            this.btnAddPresc.UseVisualStyleBackColor = true;
            // 
            // dgvPrescription
            // 
            this.dgvPrescription.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrescription.Location = new System.Drawing.Point(45, 33);
            this.dgvPrescription.Name = "dgvPrescription";
            this.dgvPrescription.RowHeadersWidth = 82;
            this.dgvPrescription.RowTemplate.Height = 37;
            this.dgvPrescription.Size = new System.Drawing.Size(657, 286);
            this.dgvPrescription.TabIndex = 100;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 444);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 24);
            this.label7.TabIndex = 99;
            this.label7.Text = "투여 방법";
            // 
            // txtMethod
            // 
            this.txtMethod.Location = new System.Drawing.Point(152, 441);
            this.txtMethod.Name = "txtMethod";
            this.txtMethod.Size = new System.Drawing.Size(202, 35);
            this.txtMethod.TabIndex = 98;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 24);
            this.label5.TabIndex = 97;
            this.label5.Text = "투여 일수";
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(491, 396);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(202, 35);
            this.txtDays.TabIndex = 96;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 397);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 24);
            this.label3.TabIndex = 95;
            this.label3.Text = "투여 횟수";
            // 
            // txtTimesPerDay
            // 
            this.txtTimesPerDay.Location = new System.Drawing.Point(152, 394);
            this.txtTimesPerDay.Name = "txtTimesPerDay";
            this.txtTimesPerDay.Size = new System.Drawing.Size(202, 35);
            this.txtTimesPerDay.TabIndex = 94;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 93;
            this.label2.Text = "투약량";
            // 
            // txtDosage
            // 
            this.txtDosage.Location = new System.Drawing.Point(491, 350);
            this.txtDosage.Name = "txtDosage";
            this.txtDosage.Size = new System.Drawing.Size(202, 35);
            this.txtDosage.TabIndex = 92;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 91;
            this.label1.Text = "약품명";
            // 
            // txtDrugName
            // 
            this.txtDrugName.Location = new System.Drawing.Point(152, 350);
            this.txtDrugName.Name = "txtDrugName";
            this.txtDrugName.Size = new System.Drawing.Size(202, 35);
            this.txtDrugName.TabIndex = 90;
            // 
            // PrescriptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpPrescDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDeletePresc);
            this.Controls.Add(this.btnAddPresc);
            this.Controls.Add(this.dgvPrescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMethod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTimesPerDay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDosage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDrugName);
            this.Name = "PrescriptionControl";
            this.Size = new System.Drawing.Size(734, 582);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescription)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpPrescDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDeletePresc;
        private System.Windows.Forms.Button btnAddPresc;
        private System.Windows.Forms.DataGridView dgvPrescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMethod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimesPerDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDosage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDrugName;
    }
}