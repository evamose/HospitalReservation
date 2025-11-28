namespace HospitalReservation
{
    partial class DoctorDetailForm
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
            this.components = new System.ComponentModel.Container();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.mtxtPhone = new System.Windows.Forms.MaskedTextBox();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblLicense = new System.Windows.Forms.Label();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblDept = new System.Windows.Forms.Label();
            this.lblBirth = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDoctorId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDoctorId = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btnWorkSchedule = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(704, 406);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(410, 35);
            this.txtAddress2.TabIndex = 7;
            // 
            // mtxtPhone
            // 
            this.mtxtPhone.Location = new System.Drawing.Point(704, 277);
            this.mtxtPhone.Mask = "000-0000-0000";
            this.mtxtPhone.Name = "mtxtPhone";
            this.mtxtPhone.Size = new System.Drawing.Size(200, 35);
            this.mtxtPhone.TabIndex = 4;
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Items.AddRange(new object[] {
            "내과",
            "외과",
            "정형외과",
            "소아과",
            "산부인과",
            "피부과",
            "안과",
            "이비인후과",
            "가정의학과"});
            this.cmbDept.Location = new System.Drawing.Point(705, 503);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(157, 32);
            this.cmbDept.TabIndex = 3;
            // 
            // dtpBirth
            // 
            this.dtpBirth.Location = new System.Drawing.Point(704, 234);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(200, 35);
            this.dtpBirth.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(130, 121);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(226, 244);
            this.listView1.TabIndex = 16;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(642, 796);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 53);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(447, 796);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 53);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(532, 454);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(106, 24);
            this.lblLicense.TabIndex = 60;
            this.lblLicense.Text = "면허번호";
            // 
            // txtLicense
            // 
            this.txtLicense.Location = new System.Drawing.Point(705, 456);
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Size = new System.Drawing.Size(263, 35);
            this.txtLicense.TabIndex = 9;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(532, 365);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(58, 24);
            this.lblAddress.TabIndex = 58;
            this.lblAddress.Text = "주소";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(704, 365);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(411, 35);
            this.txtAddress.TabIndex = 6;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 15F);
            this.lblTitle.Location = new System.Drawing.Point(155, 43);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(177, 40);
            this.lblTitle.TabIndex = 56;
            this.lblTitle.Text = "의사정보";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(532, 280);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(82, 24);
            this.lblPhone.TabIndex = 55;
            this.lblPhone.Text = "연락처";
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(533, 501);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(82, 24);
            this.lblDept.TabIndex = 54;
            this.lblDept.Text = "진료과";
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Location = new System.Drawing.Point(532, 233);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(106, 24);
            this.lblBirth.TabIndex = 53;
            this.lblBirth.Text = "생년월일";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(704, 193);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(157, 35);
            this.txtName.TabIndex = 1;
            // 
            // txtDoctorId
            // 
            this.txtDoctorId.Location = new System.Drawing.Point(704, 118);
            this.txtDoctorId.Name = "txtDoctorId";
            this.txtDoctorId.ReadOnly = true;
            this.txtDoctorId.Size = new System.Drawing.Size(264, 35);
            this.txtDoctorId.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(532, 196);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(58, 24);
            this.lblName.TabIndex = 50;
            this.lblName.Text = "이름";
            // 
            // lblDoctorId
            // 
            this.lblDoctorId.AutoSize = true;
            this.lblDoctorId.Location = new System.Drawing.Point(532, 125);
            this.lblDoctorId.Name = "lblDoctorId";
            this.lblDoctorId.Size = new System.Drawing.Size(85, 24);
            this.lblDoctorId.TabIndex = 49;
            this.lblDoctorId.Text = "의사 ID";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(704, 320);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(363, 35);
            this.txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(532, 323);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(82, 24);
            this.lblEmail.TabIndex = 70;
            this.lblEmail.Text = "이메일";
            // 
            // txtRoom
            // 
            this.txtRoom.Location = new System.Drawing.Point(705, 550);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(363, 35);
            this.txtRoom.TabIndex = 8;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(533, 553);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(82, 24);
            this.lblRoom.TabIndex = 72;
            this.lblRoom.Text = "진료실";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(532, 599);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(113, 24);
            this.lblNote.TabIndex = 75;
            this.lblNote.Text = "비고/메모";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(705, 601);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(409, 35);
            this.txtNote.TabIndex = 10;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(129, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 34);
            this.button1.TabIndex = 76;
            this.button1.Text = "등록/수정";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnWorkSchedule
            // 
            this.btnWorkSchedule.Location = new System.Drawing.Point(705, 724);
            this.btnWorkSchedule.Name = "btnWorkSchedule";
            this.btnWorkSchedule.Size = new System.Drawing.Size(183, 38);
            this.btnWorkSchedule.TabIndex = 78;
            this.btnWorkSchedule.Text = "근무 스케줄";
            this.btnWorkSchedule.UseVisualStyleBackColor = true;
            this.btnWorkSchedule.Click += new System.EventHandler(this.btnWorkSchedule_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(533, 731);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 24);
            this.label1.TabIndex = 77;
            this.label1.Text = "근무 스케줄";
            // 
            // DoctorDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 926);
            this.Controls.Add(this.btnWorkSchedule);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtAddress2);
            this.Controls.Add(this.mtxtPhone);
            this.Controls.Add(this.cmbDept);
            this.Controls.Add(this.dtpBirth);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.txtLicense);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblDept);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtDoctorId);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDoctorId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DoctorDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "의사 정보";
            this.Load += new System.EventHandler(this.DoctorDetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.MaskedTextBox mtxtPhone;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDoctorId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDoctorId;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnWorkSchedule;
        private System.Windows.Forms.Label label1;
    }
}
