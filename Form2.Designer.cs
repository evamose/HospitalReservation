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
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservation)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "순번";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "환자 예약 시간";
            // 
            // txtReservationNumber
            // 
            this.txtReservationNumber.Location = new System.Drawing.Point(213, 78);
            this.txtReservationNumber.Name = "txtReservationNumber";
            this.txtReservationNumber.Size = new System.Drawing.Size(100, 32);
            this.txtReservationNumber.TabIndex = 2;
            // 
            // txtVisitDate
            // 
            this.txtVisitDate.Location = new System.Drawing.Point(213, 134);
            this.txtVisitDate.Name = "txtVisitDate";
            this.txtVisitDate.Size = new System.Drawing.Size(170, 32);
            this.txtVisitDate.TabIndex = 3;
            // 
            // dgvReservation
            // 
            this.dgvReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservation.Location = new System.Drawing.Point(425, 70);
            this.dgvReservation.Name = "dgvReservation";
            this.dgvReservation.RowHeadersWidth = 72;
            this.dgvReservation.RowTemplate.Height = 34;
            this.dgvReservation.Size = new System.Drawing.Size(562, 456);
            this.dgvReservation.TabIndex = 4;
            this.dgvReservation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservation_CellClick);
            // 
            // btnChangeReservation
            // 
            this.btnChangeReservation.Location = new System.Drawing.Point(732, 15);
            this.btnChangeReservation.Name = "btnChangeReservation";
            this.btnChangeReservation.Size = new System.Drawing.Size(125, 49);
            this.btnChangeReservation.TabIndex = 5;
            this.btnChangeReservation.Text = "변경";
            this.btnChangeReservation.UseVisualStyleBackColor = true;
            this.btnChangeReservation.Click += new System.EventHandler(this.btnChangeReservation_Click);
            // 
            // btnCancelReservation
            // 
            this.btnCancelReservation.Location = new System.Drawing.Point(862, 15);
            this.btnCancelReservation.Name = "btnCancelReservation";
            this.btnCancelReservation.Size = new System.Drawing.Size(125, 49);
            this.btnCancelReservation.TabIndex = 6;
            this.btnCancelReservation.Text = "삭제";
            this.btnCancelReservation.UseVisualStyleBackColor = true;
            // 
            // btnCheckReservation
            // 
            this.btnCheckReservation.Location = new System.Drawing.Point(601, 15);
            this.btnCheckReservation.Name = "btnCheckReservation";
            this.btnCheckReservation.Size = new System.Drawing.Size(125, 49);
            this.btnCheckReservation.TabIndex = 8;
            this.btnCheckReservation.Text = "등록";
            this.btnCheckReservation.UseVisualStyleBackColor = true;
            this.btnCheckReservation.Click += new System.EventHandler(this.btnCheckReservation_Click);
            // 
            // txtSymptom
            // 
            this.txtSymptom.Location = new System.Drawing.Point(213, 190);
            this.txtSymptom.Name = "txtSymptom";
            this.txtSymptom.Size = new System.Drawing.Size(170, 32);
            this.txtSymptom.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "증상";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(419, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 28);
            this.label6.TabIndex = 27;
            this.label6.Text = "예약";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button5.Location = new System.Drawing.Point(147, 477);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(139, 48);
            this.button5.TabIndex = 28;
            this.button5.Text = "조회";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 542);
            this.Controls.Add(this.button5);
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
        private System.Windows.Forms.Button button5;
    }
}
