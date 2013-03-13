using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacultyAndStudentSpike
{
    public partial class frmLot : Form
    {
        public frmLot()
        {
            InitializeComponent();
        }

        private void frmLot_Load(object sender, EventArgs e)
        {
            if (UserSettings.Default.Faculty.CompareTo("1") == 0)
                rbFaculty.Checked = true;
            else
                rbStudent.Checked = true;
        }

        private void toggleFacultySpots()
        {
            pbStudent1.Hide();
            pbStudent2.Hide();
            pbStudent3.Hide();
            pbStudent4.Hide();
            pbStudent5.Hide();
            pbStudent6.Hide();

            pbFaculty1.Show();
            pbFaculty2.Show();
            pbFaculty3.Show();
            pbFaculty4.Show();
            pbFaculty5.Show();
            pbFaculty6.Show();
        }

        private void toggleStudentSpots()
        {
            pbFaculty1.Hide();
            pbFaculty2.Hide();
            pbFaculty3.Hide();
            pbFaculty4.Hide();
            pbFaculty5.Hide();
            pbFaculty6.Hide();

            pbStudent1.Show();
            pbStudent2.Show();
            pbStudent3.Show();
            pbStudent4.Show();
            pbStudent5.Show();
            pbStudent6.Show();
        }

        private void rbStudent_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Default.Faculty = "0";

            toggleStudentSpots();

            UserSettings.Default.Save();
        }

        private void rbFaculty_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Default.Faculty = "1";

            toggleFacultySpots();

            UserSettings.Default.Save();
        }
    }
}
