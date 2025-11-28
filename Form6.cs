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
    public partial class Form6 : Form
    {
        string connectionString =
           "User Id=HOSPITAL_USER;" +
           "Password=1234;" +
           "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
           "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));";
        int doctorId;
        public Form6(int id)
        {
            InitializeComponent();
            doctorId = id;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }
        private void LoadScheduleList()
        {
            string query = @"
        SELECT SCHEDULE_ID, WORK_DATE, STATUS, SHIFT
        FROM WORK_SCHEDULE
        WHERE DOCTOR_ID = :id
        ORDER BY WORK_DATE
    ";

            OracleDataAdapter da = new OracleDataAdapter(query, connectionString);
            da.SelectCommand.Parameters.Add(new OracleParameter(":id", doctorId));

            DataSet ds = new DataSet();
            da.Fill(ds, "schedule");

            dgvSchedule.DataSource = ds.Tables["schedule"];
        }

        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            txtDoctorId.Text = doctorId.ToString();
            LoadScheduleList();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus.Text == "OFF")
            {
                cmbShift.Enabled = false;
                cmbShift.SelectedIndex = -1;
            }
            else
            {
                cmbShift.Enabled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmbShift_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
