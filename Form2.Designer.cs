namespace HospitalReservation
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReservationNumber = new System.Windows.Forms.TextBox();
            this.txtVisitDate = new System.Windows.Forms.TextBox();
            this.dgvReservation = new System.Windows.Forms.DataGridView();
            this.btnChangeReservation = new System.Windows.Forms.Button();
            this.btnCancelReservation = new System.Windows.Forms.Button();
            this.btnCheckReservation = new System.Windows.Forms.Button();
            this.txtSymptom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservation)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "순번";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 141);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "환자 예약 시간";
            // 
            // txtReservationNumber
            // 
            this.txtReservationNumber.Location = new System.Drawing.Point(155, 56);
            this.txtReservationNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReservationNumber.Name = "txtReservationNumber";
            this.txtReservationNumber.Size = new System.Drawing.Size(74, 25);
            this.txtReservationNumber.TabIndex = 2;
            // 
            // txtVisitDate
            // 
            this.txtVisitDate.Location = new System.Drawing.Point(155, 138);
            this.txtVisitDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtVisitDate.Name = "txtVisitDate";
            this.txtVisitDate.Size = new System.Drawing.Size(125, 25);
            this.txtVisitDate.TabIndex = 3;
            // 
            // dgvReservation
            // 
            this.dgvReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservation.Location = new System.Drawing.Point(309, 50);
            this.dgvReservation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvReservation.Name = "dgvReservation";
            this.dgvReservation.RowHeadersWidth = 72;
            this.dgvReservation.RowTemplate.Height = 34;
            this.dgvReservation.Size = new System.Drawing.Size(409, 326);
            this.dgvReservation.TabIndex = 4;
            this.dgvReservation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservation_CellClick);
            // 
            // btnChangeReservation
            // 
            this.btnChangeReservation.Location = new System.Drawing.Point(532, 11);
            this.btnChangeReservation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChangeReservation.Name = "btnChangeReservation";
            this.btnChangeReservation.Size = new System.Drawing.Size(91, 35);
            this.btnChangeReservation.TabIndex = 5;
            this.btnChangeReservation.Text = "변경";
            this.btnChangeReservation.UseVisualStyleBackColor = true;
            this.btnChangeReservation.Click += new System.EventHandler(this.btnChangeReservation_Click);
            // 
            // btnCancelReservation
            // 
            this.btnCancelReservation.Location = new System.Drawing.Point(627, 11);
            this.btnCancelReservation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelReservation.Name = "btnCancelReservation";
            this.btnCancelReservation.Size = new System.Drawing.Size(91, 35);
            this.btnCancelReservation.TabIndex = 6;
            this.btnCancelReservation.Text = "삭제";
            this.btnCancelReservation.UseVisualStyleBackColor = true;
            this.btnCancelReservation.Click += new System.EventHandler(this.btnCancelReservation_Click);
            // 
            // btnCheckReservation
            // 
            this.btnCheckReservation.Location = new System.Drawing.Point(437, 11);
            this.btnCheckReservation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCheckReservation.Name = "btnCheckReservation";
            this.btnCheckReservation.Size = new System.Drawing.Size(91, 35);
            this.btnCheckReservation.TabIndex = 8;
            this.btnCheckReservation.Text = "등록";
            this.btnCheckReservation.UseVisualStyleBackColor = true;
            this.btnCheckReservation.Click += new System.EventHandler(this.btnCheckReservation_Click);
            // 
            // txtSymptom
            // 
            this.txtSymptom.Location = new System.Drawing.Point(155, 178);
            this.txtSymptom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSymptom.Name = "txtSymptom";
            this.txtSymptom.Size = new System.Drawing.Size(125, 25);
            this.txtSymptom.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 180);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "증상";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(305, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "예약";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSearch.Location = new System.Drawing.Point(107, 341);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(101, 34);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 223);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 30;
            this.label3.Text = "진료과";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 266);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 32;
            this.label5.Text = "의사";
            // 
            // cboDoctor
            // 
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.Location = new System.Drawing.Point(155, 263);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(121, 23);
            this.cboDoctor.TabIndex = 33;
            // 
            // cboDept
            // 
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(155, 219);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(121, 23);
            this.cboDept.TabIndex = 34;
            this.cboDept.SelectedIndexChanged += new System.EventHandler(this.cboDept_SelectedIndexChanged);
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(155, 100);
            this.txtPatientName.Margin = new System.Windows.Forms.Padding(2);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(125, 25);
            this.txtPatientName.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 103);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 19);
            this.label7.TabIndex = 35;
            this.label7.Text = "환자명";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 387);
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
            this.Controls.Add(this.txtReservationNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.Text = "예약 관리";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReservationNumber;
        private System.Windows.Forms.TextBox txtVisitDate;
        private System.Windows.Forms.DataGridView dgvReservation;
        private System.Windows.Forms.Button btnChangeReservation;
        private System.Windows.Forms.Button btnCancelReservation;
        private System.Windows.Forms.Button btnCheckReservation;
        private System.Windows.Forms.TextBox txtSymptom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label7;
    }
}


