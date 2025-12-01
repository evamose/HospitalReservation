namespace HospitalReservation
{
    partial class PatientDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblBirth = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPatientId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPatientId = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.lblVisitReason = new System.Windows.Forms.Label();
            this.txtVisitReason = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.mtxtPhone = new System.Windows.Forms.MaskedTextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.btnPrescTab = new System.Windows.Forms.Button();
            this.btnVisitTab = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(87, 321);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(82, 24);
            this.lblPhone.TabIndex = 33;
            this.lblPhone.Text = "연락처";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(87, 275);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(58, 24);
            this.lblGender.TabIndex = 31;
            this.lblGender.Text = "성별";
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Location = new System.Drawing.Point(87, 230);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(106, 24);
            this.lblBirth.TabIndex = 29;
            this.lblBirth.Text = "생년월일";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(259, 190);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(157, 35);
            this.txtName.TabIndex = 27;
            // 
            // txtPatientId
            // 
            this.txtPatientId.Location = new System.Drawing.Point(259, 115);
            this.txtPatientId.Name = "txtPatientId";
            this.txtPatientId.Size = new System.Drawing.Size(264, 35);
            this.txtPatientId.TabIndex = 26;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(87, 193);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(58, 24);
            this.lblName.TabIndex = 25;
            this.lblName.Text = "이름";
            // 
            // lblPatientId
            // 
            this.lblPatientId.AutoSize = true;
            this.lblPatientId.Location = new System.Drawing.Point(87, 122);
            this.lblPatientId.Name = "lblPatientId";
            this.lblPatientId.Size = new System.Drawing.Size(85, 24);
            this.lblPatientId.TabIndex = 24;
            this.lblPatientId.Text = "환자 ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 15F);
            this.label6.Location = new System.Drawing.Point(106, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 40);
            this.label6.TabIndex = 34;
            this.label6.Text = "환자정보";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(87, 363);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(58, 24);
            this.lblAddress.TabIndex = 36;
            this.lblAddress.Text = "주소";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(259, 363);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(397, 35);
            this.txtAddress.TabIndex = 35;
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location = new System.Drawing.Point(87, 620);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(114, 24);
            this.lblDoctor.TabIndex = 40;
            this.lblDoctor.Text = "담당 의사";
            // 
            // lblVisitReason
            // 
            this.lblVisitReason.AutoSize = true;
            this.lblVisitReason.Location = new System.Drawing.Point(87, 464);
            this.lblVisitReason.Name = "lblVisitReason";
            this.lblVisitReason.Size = new System.Drawing.Size(114, 24);
            this.lblVisitReason.TabIndex = 38;
            this.lblVisitReason.Text = "방문 이유";
            // 
            // txtVisitReason
            // 
            this.txtVisitReason.Location = new System.Drawing.Point(260, 466);
            this.txtVisitReason.Name = "txtVisitReason";
            this.txtVisitReason.Size = new System.Drawing.Size(396, 35);
            this.txtVisitReason.TabIndex = 37;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(551, 716);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 53);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(720, 716);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 53);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtpBirth
            // 
            this.dtpBirth.Location = new System.Drawing.Point(259, 231);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(200, 35);
            this.dtpBirth.TabIndex = 44;
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "남",
            "여"});
            this.cmbGender.Location = new System.Drawing.Point(259, 277);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(97, 32);
            this.cmbGender.TabIndex = 45;
            // 
            // mtxtPhone
            // 
            this.mtxtPhone.Location = new System.Drawing.Point(259, 318);
            this.mtxtPhone.Mask = "000-0000-0000";
            this.mtxtPhone.Name = "mtxtPhone";
            this.mtxtPhone.Size = new System.Drawing.Size(200, 35);
            this.mtxtPhone.TabIndex = 46;
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(259, 404);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(396, 35);
            this.txtAddress2.TabIndex = 47;
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(260, 621);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(263, 32);
            this.cmbDoctor.TabIndex = 48;
            // 
            // panelDetail
            // 
            this.panelDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetail.Location = new System.Drawing.Point(676, 92);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(734, 582);
            this.panelDetail.TabIndex = 49;
            // 
            // btnPrescTab
            // 
            this.btnPrescTab.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPrescTab.Location = new System.Drawing.Point(1048, 40);
            this.btnPrescTab.Name = "btnPrescTab";
            this.btnPrescTab.Size = new System.Drawing.Size(362, 50);
            this.btnPrescTab.TabIndex = 51;
            this.btnPrescTab.Text = "처방";
            this.btnPrescTab.UseVisualStyleBackColor = false;
            this.btnPrescTab.Click += new System.EventHandler(this.btnPrescTab_Click);
            // 
            // btnVisitTab
            // 
            this.btnVisitTab.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnVisitTab.Location = new System.Drawing.Point(676, 40);
            this.btnVisitTab.Name = "btnVisitTab";
            this.btnVisitTab.Size = new System.Drawing.Size(362, 50);
            this.btnVisitTab.TabIndex = 52;
            this.btnVisitTab.Text = "진단";
            this.btnVisitTab.UseVisualStyleBackColor = false;
            this.btnVisitTab.Click += new System.EventHandler(this.btnVisitTab_Click);
            // 
            // PatientDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 781);
            this.Controls.Add(this.btnVisitTab);
            this.Controls.Add(this.btnPrescTab);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.cmbDoctor);
            this.Controls.Add(this.txtAddress2);
            this.Controls.Add(this.mtxtPhone);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.dtpBirth);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.lblVisitReason);
            this.Controls.Add(this.txtVisitReason);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPatientId);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPatientId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatientDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "환자 정보";
            this.Load += new System.EventHandler(this.PatientDetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPatientId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPatientId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblVisitReason;
        private System.Windows.Forms.TextBox txtVisitReason;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.MaskedTextBox mtxtPhone;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Button btnPrescTab;
        private System.Windows.Forms.Button btnVisitTab;
    }
}