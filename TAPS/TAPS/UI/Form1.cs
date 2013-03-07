using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TAPS.UI;

namespace TAPS
{
    public partial class Form1 : Form
    {
        protected TAPS.UI.ParkingLotDisplay lotDisplay;

        public Form1()
        {
            InitializeComponent();

            this.CampusMapFrame.InitializeDataView();

            lotDisplay = new ParkingLotDisplay();
            lotDisplay.Hide();

            //register for LotClick event
            this.CampusMapFrame.LotClickEvent += HandleLotClick;

            //register for ReturnToMap event
            this.lotDisplay.ReturnToMapEvent += HandleReturnToMap;
        }

        protected void HandleLotClick(Object sender, TAPS.UI.LotClickEventArgs e)
        {
            this.Hide();
            this.lotDisplay.ParkingLot = e.Lot.GetParkingLotDetailView();
            this.lotDisplay.Show();
        }

        protected void HandleReturnToMap(Object sender, EventArgs e)
        {
            this.lotDisplay.Hide();
            this.Show();
        }
    }
}
