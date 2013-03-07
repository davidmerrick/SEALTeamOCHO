using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TAPS.UI
{
    public partial class ParkingLotDisplay : Form
    {
        protected ParkingLotDetailView mParkingLot;
        public event EventHandler<EventArgs> ReturnToMapEvent;

        public ParkingLotDisplay()
        {
            InitializeComponent();
        }

        public ParkingLotDetailView ParkingLot
        {
            get
            {
                return this.ParkingLotFrame.ParkingLot;
            }
            set
            {
                this.ParkingLotFrame.ParkingLot = value;
                this.mParkingLot = value;

                if (this.mParkingLot != null)
                {
                    UpdateShownData();
                    this.UpdateTimer.Enabled = true;
                }
                else
                    this.UpdateTimer.Enabled = false;
            }
        }

        protected void UpdateShownData()
        {
            if (this.mParkingLot == null) return;

            this.LabelLotName.Text = this.mParkingLot.LotName;
            this.LabelFree.Text = String.Format("{0} of {1} free", this.mParkingLot.AvailableSpaces,
                this.mParkingLot.TotalSpaces);
            this.LabelVacantPercent.Text = String.Format("{0:P0}", this.mParkingLot.PercentAvailable);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        protected void OnReturnToMap(EventArgs e)
        {
            EventHandler<EventArgs> handler = this.ReturnToMapEvent;

            if (handler != null)
                handler(this, e);
        }

        private void ButtonReturnToMap_Click(object sender, EventArgs e)
        {
            //raise a ReturnToMap event
            OnReturnToMap(new EventArgs());
        }

        private void ParkingLotDisplay_Load(Object sender, EventArgs e)
        {

        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (this.mParkingLot == null) return;

            //get updates to parking lot
            this.mParkingLot.UpdateAvailableSpaces();
            this.UpdateShownData();
            this.ParkingLotFrame.Invalidate();
        }

       
    }
}
