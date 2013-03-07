using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TAPS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //get an image for the map frame
            this.mapFrame1.MapImage = Image.FromFile("../../Data/ParkingData/CampusMap.bmp");
        }
    }
}
