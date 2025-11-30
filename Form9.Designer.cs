namespace HospitalReservation
{
    partial class Form9
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
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSymptom = new System.Windows.Forms.TextBox();
            this.btnCheckReservation = new System.Windows.Forms.Button();
            this.btnCancelReservation = new System.Windows.Forms.Button();
            this.btnChangeReservation = new System.Windows.Forms.Button();
            this.dgvReservation = new System.Windows.Forms.DataGridView();
            this.txtVisitDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservation)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(150, 68);
            this.txtPatientName.Margin = new System.Windows.Forms.Padding(2);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(125, 25);
            this.txtPatientName.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 71);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 53;
            this.label7.Text = "환자명";
            // 
            // cboDept
            // 
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(150, 233);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(121, 23);
            this.cboDept.TabIndex = 52;
            this.cboDept.SelectedIndexChanged += new System.EventHandler(this.cboDept_SelectedIndexChanged);
            // 
            // cboDoctor
            // 
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.Location = new System.Drawing.Point(150, 274);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(121, 23);
            this.cboDoctor.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 277);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 50;
            this.label5.Text = "의사";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 237);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 49;
            this.label3.Text = "진료과";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSearch.Location = new System.Drawing.Point(102, 346);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(101, 34);
            this.btnSearch.TabIndex = 48;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(300, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 47;
            this.label6.Text = "예약";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 194);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 46;
            this.label4.Text = "증상";
            // 
            // txtSymptom
            // 
            this.txtSymptom.Location = new System.Drawing.Point(150, 192);
            this.txtSymptom.Margin = new System.Windows.Forms.Padding(2);
            this.txtSymptom.Name = "txtSymptom";
            this.txtSymptom.Size = new System.Drawing.Size(125, 25);
            this.txtSymptom.TabIndex = 45;
            // 
            // btnCheckReservation
            // 
            this.btnCheckReservation.Location = new System.Drawing.Point(432, 16);
            this.btnCheckReservation.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckReservation.Name = "btnCheckReservation";
            this.btnCheckReservation.Size = new System.Drawing.Size(91, 35);
            this.btnCheckReservation.TabIndex = 44;
            this.btnCheckReservation.Text = "예약";
            this.btnCheckReservation.UseVisualStyleBackColor = true;
            this.btnCheckReservation.Click += new System.EventHandler(this.btnCheckReservation_Click);
            // 
            // btnCancelReservation
            // 
            this.btnCancelReservation.Location = new System.Drawing.Point(622, 16);
            this.btnCancelReservation.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelReservation.Name = "btnCancelReservation";
            this.btnCancelReservation.Size = new System.Drawing.Size(91, 35);
            this.btnCancelReservation.TabIndex = 43;
            this.btnCancelReservation.Text = "취소";
            this.btnCancelReservation.UseVisualStyleBackColor = true;
            this.btnCancelReservation.Click += new System.EventHandler(this.btnCancelReservation_Click);
            // 
            // btnChangeReservation
            // 
            this.btnChangeReservation.Location = new System.Drawing.Point(527, 16);
            this.btnChangeReservation.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangeReservation.Name = "btnChangeReservation";
            this.btnChangeReservation.Size = new System.Drawing.Size(91, 35);
            this.btnChangeReservation.TabIndex = 42;
            this.btnChangeReservation.Text = "변경";
            this.btnChangeReservation.UseVisualStyleBackColor = true;
            this.btnChangeReservation.Click += new System.EventHandler(this.btnChangeReservation_Click);
            // 
            // dgvReservation
            // 
            this.dgvReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservation.Location = new System.Drawing.Point(304, 55);
            this.dgvReservation.Margin = new System.Windows.Forms.Padding(2);
            this.dgvReservation.Name = "dgvReservation";
            this.dgvReservation.RowHeadersWidth = 72;
            this.dgvReservation.RowTemplate.Height = 34;
            this.dgvReservation.Size = new System.Drawing.Size(409, 326);
            this.dgvReservation.TabIndex = 41;
            this.dgvReservation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservation_CellClick);
            // 
            // txtVisitDate
            // 
            this.txtVisitDate.Location = new System.Drawing.Point(150, 152);
            this.txtVisitDate.Margin = new System.Windows.Forms.Padding(2);
            this.txtVisitDate.Name = "txtVisitDate";
            this.txtVisitDate.Size = new System.Drawing.Size(125, 25);
            this.txtVisitDate.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 155);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 38;
            this.label2.Text = "환자 예약 시간";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(150, 110);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 25);
            this.textBox1.TabIndex = 56;
            // 
            // txtPhone
            // 
            this.txtPhone.AutoSize = true;
            this.txtPhone.Location = new System.Drawing.Point(26, 113);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(84, 19);
            this.txtPhone.TabIndex = 55;
            this.txtPhone.Text = "전화번호";
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 396);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboDept);
            this.Controls.Add(this.cboDoctor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSymptom);
            this.Controls.Add(this.btnCheckReservation);
            this.Controls.Add(this.btnCancelReservation);
            this.Controls.Add(this.btnChangeReservation);
            this.Controls.Add(this.dgvReservation);
            this.Controls.Add(this.txtVisitDate);
            this.Controls.Add(this.label2);
            this.Name = "Form9";
            this.Text = "환자 예약";
            this.Load += new System.EventHandler(this.Form9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSymptom;
        private System.Windows.Forms.Button btnCheckReservation;
        private System.Windows.Forms.Button btnCancelReservation;
        private System.Windows.Forms.Button btnChangeReservation;
        private System.Windows.Forms.DataGridView dgvReservation;
        private System.Windows.Forms.TextBox txtVisitDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label txtPhone;
    }
}