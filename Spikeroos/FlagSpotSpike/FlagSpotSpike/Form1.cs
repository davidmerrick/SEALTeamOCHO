using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlagSpotSpike
{
    public partial class Form1 : Form
    {
        int curSpotSelected = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void showFlaggedSpot()
        {
            pbStudent1.BackColor = Color.LightSteelBlue;
            pbStudent2.BackColor = Color.LightSteelBlue;
            pbStudent3.BackColor = Color.LightSteelBlue;
            pbStudent4.BackColor = Color.LightSteelBlue;
            pbStudent5.BackColor = Color.LightSteelBlue;
            pbStudent6.BackColor = Color.LightSteelBlue;
            pbFaculty1.BackColor = Color.LightSteelBlue;
            pbFaculty2.BackColor = Color.LightSteelBlue;
            pbFaculty3.BackColor = Color.LightSteelBlue;
            pbFaculty4.BackColor = Color.LightSteelBlue;
            pbFaculty5.BackColor = Color.LightSteelBlue;
            pbFaculty6.BackColor = Color.LightSteelBlue;

            if (UserSettings.Default.FlaggedSpot.CompareTo("") != 0)
            {
                if (UserSettings.Default.FlaggedSpot.CompareTo("1") == 0)
                {
                    pbStudent1.BackColor = Color.Yellow;
                }
                else if (UserSettings.Default.FlaggedSpot.CompareTo("2") == 0)
                {
                    pbStudent2.BackColor = Color.Yellow;
                }
                else if (UserSettings.Default.FlaggedSpot.CompareTo("3") == 0)
                {
                    pbStudent3.BackColor = Color.Yellow;
                }
                else if (UserSettings.Default.FlaggedSpot.CompareTo("4") == 0)
                {
                    pbStudent4.BackColor = Color.Yellow;
                }
                else if (UserSettings.Default.FlaggedSpot.CompareTo("5") == 0)
                {
                    pbStudent5.BackColor = Color.Yellow;
                }
                else if (UserSettings.Default.FlaggedSpot.CompareTo("6") == 0)
                {
                    pbStudent6.BackColor = Color.Yellow;
                }
                else if (UserSettings.Default.FlaggedSpot.CompareTo("7") == 0)
                {
                    pbFaculty1.BackColor = Color.Yellow;
                }
                else if (UserSettings.Default.FlaggedSpot.CompareTo("8") == 0)
                {
                    pbFaculty2.BackColor = Color.Yellow;
                }
                else if (UserSettings.Default.FlaggedSpot.CompareTo("9") == 0)
                {
                    pbFaculty3.BackColor = Color.Yellow;
                }
                else if (UserSettings.Default.FlaggedSpot.CompareTo("10") == 0)
                {
                    pbFaculty4.BackColor = Color.Yellow;
                }
                else if (UserSettings.Default.FlaggedSpot.CompareTo("11") == 0)
                {
                    pbFaculty5.BackColor = Color.Yellow;
                }
                else if (UserSettings.Default.FlaggedSpot.CompareTo("12") == 0)
                {
                    pbFaculty6.BackColor = Color.Yellow;
                }
            }
        }

        private void pbStudent1_MouseEnter(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("1") != 0)
                pbStudent1.BackColor = Color.DarkBlue;
        }

        private void pbStudent2_MouseEnter(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("2") != 0)
                pbStudent2.BackColor = Color.DarkBlue;
        }

        private void pbStudent3_MouseEnter(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("3") != 0)
                pbStudent3.BackColor = Color.DarkBlue;
        }

        private void pbStudent4_MouseEnter(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("4") != 0)
                pbStudent4.BackColor = Color.DarkBlue;
        }

        private void pbStudent5_MouseEnter(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("5") != 0)
                pbStudent5.BackColor = Color.DarkBlue;
        }

        private void pbStudent6_MouseEnter(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("6") != 0)
                pbStudent6.BackColor = Color.DarkBlue;
        }

        private void pbFaculty1_MouseEnter(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("7") != 0)
                pbFaculty1.BackColor = Color.DarkBlue;
        }

        private void pbFaculty2_MouseEnter(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("8") != 0)
                pbFaculty2.BackColor = Color.DarkBlue;
        }

        private void pbFaculty3_MouseEnter(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("9") != 0)
                pbFaculty3.BackColor = Color.DarkBlue;
        }

        private void pbFaculty4_MouseEnter(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("10") != 0)
                pbFaculty4.BackColor = Color.DarkBlue;  
        }

        private void pbFaculty5_MouseEnter(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("11") != 0)
                pbFaculty5.BackColor = Color.DarkBlue;
        }

        private void pbFaculty6_MouseEnter(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("12") != 0)
                pbFaculty6.BackColor = Color.DarkBlue;
        }

        private void pbStudent1_MouseLeave(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("1") != 0)
                pbStudent1.BackColor = Color.LightSteelBlue;
        }

        private void pbStudent2_MouseLeave(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("2") != 0)
                pbStudent2.BackColor = Color.LightSteelBlue;
        }

        private void pbStudent3_MouseLeave(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("3") != 0)
                pbStudent3.BackColor = Color.LightSteelBlue;
        }

        private void pbStudent4_MouseLeave(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("4") != 0)
                pbStudent4.BackColor = Color.LightSteelBlue;
        }

        private void pbStudent5_MouseLeave(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("5") != 0)
                pbStudent5.BackColor = Color.LightSteelBlue;
        }

        private void pbStudent6_MouseLeave(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("6") != 0)
                pbStudent6.BackColor = Color.LightSteelBlue;
        }

        private void pbFaculty1_MouseLeave(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("7") != 0)
                pbFaculty1.BackColor = Color.LightSteelBlue;
        }

        private void pbFaculty2_MouseLeave(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("8") != 0)
                pbFaculty2.BackColor = Color.LightSteelBlue;
        }

        private void pbFaculty3_MouseLeave(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("9") != 0)
                pbFaculty3.BackColor = Color.LightSteelBlue;
        }

        private void pbFaculty4_MouseLeave(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("10") != 0)
                pbFaculty4.BackColor = Color.LightSteelBlue;
        }

        private void pbFaculty5_MouseLeave(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("11") != 0)
                pbFaculty5.BackColor = Color.LightSteelBlue;
        }

        private void pbFaculty6_MouseLeave(object sender, EventArgs e)
        {
            if (UserSettings.Default.FlaggedSpot.CompareTo("12") != 0)
                pbFaculty6.BackColor = Color.LightSteelBlue;
        }

        private void pbStudent1_Click(object sender, EventArgs e)
        {
            if (curSpotSelected == 1)
            {
                curSpotSelected = 0;
                btnFlag.Enabled = false;
            }
            else
            {
                curSpotSelected = 1;

                if (UserSettings.Default.FlaggedSpot.CompareTo("1") == 0)
                {
                    btnUnFlag.Enabled = true;
                }
                else
                {
                    btnFlag.Enabled = true;
                }
            }                
        }

        private void pbStudent2_Click(object sender, EventArgs e)
        {
            if (curSpotSelected == 1)
            {
                curSpotSelected = 0;
                btnFlag.Enabled = false;
            }
            else
            {
                curSpotSelected = 2;

                if (UserSettings.Default.FlaggedSpot.CompareTo("2") == 0)
                {
                    btnUnFlag.Enabled = true;
                }
                else
                {
                    btnFlag.Enabled = true;
                }
            }  
        }

        private void pbStudent3_Click(object sender, EventArgs e)
        {
            if (curSpotSelected == 1)
            {
                curSpotSelected = 0;
                btnFlag.Enabled = false;
            }
            else
            {
                curSpotSelected = 3;

                if (UserSettings.Default.FlaggedSpot.CompareTo("3") == 0)
                {
                    btnUnFlag.Enabled = true;
                }
                else
                {
                    btnFlag.Enabled = true;
                }
            }  
        }

        private void pbStudent4_Click(object sender, EventArgs e)
        {
            if (curSpotSelected == 1)
            {
                curSpotSelected = 0;
                btnFlag.Enabled = false;
            }
            else
            {
                curSpotSelected = 4;

                if (UserSettings.Default.FlaggedSpot.CompareTo("4") == 0)
                {
                    btnUnFlag.Enabled = true;
                }
                else
                {
                    btnFlag.Enabled = true;
                }
            }  
        }

        private void pbStudent5_Click(object sender, EventArgs e)
        {
            if (curSpotSelected == 1)
            {
                curSpotSelected = 0;
                btnFlag.Enabled = false;
            }
            else
            {
                curSpotSelected = 5;

                if (UserSettings.Default.FlaggedSpot.CompareTo("5") == 0)
                {
                    btnUnFlag.Enabled = true;
                }
                else
                {
                    btnFlag.Enabled = true;
                }
            }  
        }

        private void pbStudent6_Click(object sender, EventArgs e)
        {
            if (curSpotSelected == 1)
            {
                curSpotSelected = 0;
                btnFlag.Enabled = false;
            }
            else
            {
                curSpotSelected = 6;

                if (UserSettings.Default.FlaggedSpot.CompareTo("6") == 0)
                {
                    btnUnFlag.Enabled = true;
                }
                else
                {
                    btnFlag.Enabled = true;
                }
            }  
        }

        private void pbFaculty1_Click(object sender, EventArgs e)
        {
            if (curSpotSelected == 1)
            {
                curSpotSelected = 0;
                btnFlag.Enabled = false;
            }
            else
            {
                curSpotSelected = 7;

                if (UserSettings.Default.FlaggedSpot.CompareTo("7") == 0)
                {
                    btnUnFlag.Enabled = true;
                }
                else
                {
                    btnFlag.Enabled = true;
                }
            }  
        }

        private void pbFaculty2_Click(object sender, EventArgs e)
        {
            if (curSpotSelected == 1)
            {
                curSpotSelected = 0;
                btnFlag.Enabled = false;
            }
            else
            {
                curSpotSelected = 8;

                if (UserSettings.Default.FlaggedSpot.CompareTo("8") == 0)
                {
                    btnUnFlag.Enabled = true;
                }
                else
                {
                    btnFlag.Enabled = true;
                }
            }  
        }

        private void pbFaculty3_Click(object sender, EventArgs e)
        {
            if (curSpotSelected == 1)
            {
                curSpotSelected = 0;
                btnFlag.Enabled = false;
            }
            else
            {
                curSpotSelected = 9;

                if (UserSettings.Default.FlaggedSpot.CompareTo("9") == 0)
                {
                    btnUnFlag.Enabled = true;
                }
                else
                {
                    btnFlag.Enabled = true;
                }
            }  
        }

        private void pbFaculty4_Click(object sender, EventArgs e)
        {
            if (curSpotSelected == 1)
            {
                curSpotSelected = 0;
                btnFlag.Enabled = false;
            }
            else
            {
                curSpotSelected = 10;

                if (UserSettings.Default.FlaggedSpot.CompareTo("10") == 0)
                {
                    btnUnFlag.Enabled = true;
                }
                else
                {
                    btnFlag.Enabled = true;
                }
            }  
        }

        private void pbFaculty5_Click(object sender, EventArgs e)
        {
            if (curSpotSelected == 1)
            {
                curSpotSelected = 0;
                btnFlag.Enabled = false;
            }
            else
            {
                curSpotSelected = 11;

                if (UserSettings.Default.FlaggedSpot.CompareTo("11") == 0)
                {
                    btnUnFlag.Enabled = true;
                }
                else
                {
                    btnFlag.Enabled = true;
                }
            }  
        }

        private void pbFaculty6_Click(object sender, EventArgs e)
        {
            if (curSpotSelected == 1)
            {
                curSpotSelected = 0;
                btnFlag.Enabled = false;
            }
            else
            {
                curSpotSelected = 12;

                if (UserSettings.Default.FlaggedSpot.CompareTo("12") == 0)
                {
                    btnUnFlag.Enabled = true;
                }
                else
                {
                    btnFlag.Enabled = true;
                }
            }  
        }

        private void btnFlag_Click(object sender, EventArgs e)
        {
            UserSettings.Default.FlaggedSpot = curSpotSelected.ToString();
            UserSettings.Default.Save();

            showFlaggedSpot();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showFlaggedSpot();
        }

        private void btnUnFlag_Click(object sender, EventArgs e)
        {
            UserSettings.Default.FlaggedSpot = "";
            UserSettings.Default.Save();

            curSpotSelected = 0;

            btnUnFlag.Enabled = false;

            showFlaggedSpot();
        }
    }
}
