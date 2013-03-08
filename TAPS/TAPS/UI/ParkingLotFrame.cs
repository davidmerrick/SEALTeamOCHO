using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TAPS.UI;

namespace TAPS.UI
{
    public partial class ParkingLotFrame : MapFrame
    {
        protected ParkingLotDetailView mParkingLot;

        protected static Brush vacantBrush = new SolidBrush(
            Color.FromArgb(180, Color.Green));
        protected static Brush occupiedBrush = new SolidBrush(
            Color.FromArgb(180, Color.Red));
        protected static Brush offLimitsBrush = new SolidBrush(
            Color.FromArgb(180, Color.Gray));
        protected static Brush textBrush = new SolidBrush(Color.Black);

        public ParkingLotFrame()
        {
            InitializeComponent();

            this.mParkingLot = null;
        }

        public ParkingLotDetailView ParkingLot
        {
            get
            {
                return this.mParkingLot;
            }
            set
            {
                this.mParkingLot = value;
                if (value != null)
                {
                    base.MapImage = this.mParkingLot.LotImage;
                }
            }
        }

        protected override void DrawAdditionalGraphics(Graphics dc)
        {
            if (this.mParkingLot == null) return;

            //draw each parking space
            foreach (Space spc in this.mParkingLot.Spaces)
            {
                DrawParkingSpace(dc, spc);
            }

            base.DrawAdditionalGraphics(dc);
        }

        protected void DrawParkingSpace(Graphics dc, Space spc)
        {
            //draw the rectangle
            if (!spc.CanUserPark(UserSettings.ParkingPermissions))
            {
                dc.FillRectangle(offLimitsBrush, spc.rect);
            }
            else if (spc.vacant)
            {
                dc.FillRectangle(vacantBrush, spc.rect);
            }
            else
            {
                dc.FillRectangle(occupiedBrush, spc.rect);
            }

            //draw the parking space flag in the center of the rectangle
            Point flagPos = new Point(spc.rect.X + spc.rect.Width / 2,
                spc.rect.Y + spc.rect.Height / 2);

            String flagText = "";
            if (spc.faculty)
                flagText = "F";
            else if (spc.handicap)
                flagText = "H";

            if (flagText != "")
                dc.DrawString(flagText, new Font("Calibri", 12, FontStyle.Bold),
                    textBrush, flagPos);
        }
    }
}
