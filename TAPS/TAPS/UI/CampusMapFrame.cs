using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TAPS.UI
{

    /// <summary>
    /// Displays the campus map and draws parking lot regions colored by vacancy. 
    /// Dragging the mouse over a region causes it to be highlighted and displays
    /// a tooltip giving the vacant/total ratio of the lot. Clicking a region brings
    /// up the ParkingLotFrame.
    /// </summary>
    public partial class CampusMapFrame : MapFrame
    {
        public event EventHandler<LotClickEventArgs> LotClickEvent;

        protected CampusMapView dataView;
        protected ParkingLotView selectedLot;
        protected String tooltip;
        protected Point tooltipPosition;

        protected static Color colorVacant = Color.LawnGreen;
        protected static Color colorFull = Color.Red;
        protected static int lotTransparency = 200;
        protected static double selectionDarkenFactor = (double)0.3;
        protected static Point tooltipOffset = new Point(0, -50);

        /// <summary>
        /// Creates a new CampusMapFrame and creates a new CampusMapView to provide data
        /// for the map.
        /// </summary>
        public CampusMapFrame() : base()
        {
            InitializeComponent();

            //this.dataView = new CampusMapView();
            this.selectedLot = null;
            this.tooltip = "";
        }

        //errors may be thrown if the control is used before this method has been called
        public void InitializeDataView()
        {
            this.dataView = new CampusMapView();
            base.MapImage = this.dataView.CampusMap;
        }

        protected override void DrawAdditionalGraphics(Graphics dc)
        {
            if (this.dataView == null) return;

            Matrix id = new Matrix();
            id.Reset();

            //draw each lot in the appropriate color
            foreach (ParkingLotView lot in this.dataView.ParkingLotViews)
            {
                if (selectedLot != null)
                {
                    if (lot.LotName ==  selectedLot.LotName)
                    {
                        dc.FillRegion(ChooseSelectionBrush(lot), lot.LotRegion);
                        
                        continue;
                    }
                }
                
                //if lot is not selected, draw in normal color
                dc.FillRegion(ChooseLotBrush(lot), lot.LotRegion);
            }

            //draw tooltip text
            dc.ResetTransform();
            if (tooltip != "")
            {
                dc.DrawString(tooltip, new Font("Calibri", 12, FontStyle.Regular),
                    new SolidBrush(Color.Black), this.tooltipPosition);
            }

            base.DrawAdditionalGraphics(dc);
        }

        protected virtual Brush ChooseLotBrush(ParkingLotView lot)
        {
            System.Windows.Media.GradientStopCollection gsc = new
                System.Windows.Media.GradientStopCollection();

            gsc.Add(new System.Windows.Media.GradientStop(
                DrawingColorToWMColor(colorVacant), (double) 1.0));
            gsc.Add(new System.Windows.Media.GradientStop(
                DrawingColorToWMColor(colorFull), 0.0));

            //add some transparency to the color
            Color c = Color.FromArgb(lotTransparency, GetRelativeColor(gsc, lot.PercentAvailable));
            return new SolidBrush(c);
            
        }

        protected System.Windows.Media.Color DrawingColorToWMColor(Color c)
        {
            return System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B);
        }

        protected Color WMColorToDrawingColor(System.Windows.Media.Color c)
        {
            return Color.FromArgb(c.A, c.R, c.G, c.B);
        }

        //this code is copied from the web:
        //http://stackoverflow.com/questions/9650049/get-color-in-specific-location-on-gradient
        public static Color GetRelativeColor(System.Windows.Media.GradientStopCollection gsc, double offset)
        {
            System.Windows.Media.GradientStop before = gsc.Where(w => w.Offset == gsc.Min(m => m.Offset)).First();
            System.Windows.Media.GradientStop after = gsc.Where(w => w.Offset == gsc.Max(m => m.Offset)).First();

            foreach (var gs in gsc)
            {
                if (gs.Offset < offset && gs.Offset > before.Offset)
                {
                    before = gs;
                }
                if (gs.Offset > offset && gs.Offset < after.Offset)
                {
                    after = gs;
                }
            }

            var color = new System.Windows.Media.Color();

            color.ScA = (float)((offset - before.Offset) * (after.Color.ScA - before.Color.ScA) / (after.Offset - before.Offset) + before.Color.ScA);
            color.ScR = (float)((offset - before.Offset) * (after.Color.ScR - before.Color.ScR) / (after.Offset - before.Offset) + before.Color.ScR);
            color.ScG = (float)((offset - before.Offset) * (after.Color.ScG - before.Color.ScG) / (after.Offset - before.Offset) + before.Color.ScG);
            color.ScB = (float)((offset - before.Offset) * (after.Color.ScB - before.Color.ScB) / (after.Offset - before.Offset) + before.Color.ScB);

            return Color.FromArgb(color.A, color.R, color.G, color.B);
            
        }


        protected virtual Brush ChooseSelectionBrush(ParkingLotView lot)
        {
            //use the same brush as normal, but darken the color
            SolidBrush normal = (SolidBrush) ChooseLotBrush(lot);
            
            //darken the brush slightly
            System.Windows.Media.GradientStopCollection gsc = new
                System.Windows.Media.GradientStopCollection();

            gsc.Add(new System.Windows.Media.GradientStop(
                DrawingColorToWMColor(normal.Color), (double)0.0));
            gsc.Add(new System.Windows.Media.GradientStop(
                DrawingColorToWMColor(Color.Black), 1.0));

            return new SolidBrush(GetRelativeColor(gsc, selectionDarkenFactor));
        }

        protected virtual String GetTooltipText(ParkingLotView selected)
        {
            return String.Format("{0}\n{1} of {2} free", selected.LotName,
                selected.AvailableSpaces, selected.TotalSpaces);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this.dataView == null) return;

            bool lotSelected = false;

            Matrix pageTransform = base.GetPageTransform();

            //detect which parking lot region (if any) the mouse is in
            foreach (ParkingLotView lot in this.dataView.ParkingLotViews)
            {
                //transform region to page coords
                Region rPage = lot.LotRegion.Clone();
                rPage.Transform(pageTransform);

                if (rPage.IsVisible(e.Location))
                {
                    if (this.selectedLot != null)
                    {
                        if (lot.LotName == this.selectedLot.LotName)
                        {
                            //update tooltip location
                            this.tooltipPosition = new Point(e.Location.X + tooltipOffset.X,
                                e.Location.Y + tooltipOffset.Y);
                            lotSelected = true;
                            break;
                        }
                    }

                    //the selected lot is a new selection
                    this.selectedLot = lot;
                    this.tooltip = GetTooltipText(lot);
                    this.tooltipPosition = new Point(e.Location.X + tooltipOffset.X,
                        e.Location.Y + tooltipOffset.Y);
                    lotSelected = true;
                    break;
                }
            }

            if (!lotSelected)
            {
                this.selectedLot = null;
                this.tooltip = "";
                this.selectedLot = null;
            }

            base.OnMouseMove(e);
            //this.Invalidate();
        }

        //determines whether a lot region was clicked
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this.dataView == null) return;

            base.OnMouseUp(e);

            ParkingLotView clickedLot = GetSelectedLot(e.Location);
            if (clickedLot != null)
            {
                //Invoke lot click event
                OnLotClick(new LotClickEventArgs(clickedLot));
            }
        }

        protected ParkingLotView GetSelectedLot(Point pt)
        {
            foreach (ParkingLotView lot in this.dataView.ParkingLotViews)
            {
                if (lot.LotRegion.IsVisible(pt)) return lot;
            }

            return null;
        }

        protected void OnLotClick(LotClickEventArgs e)
        {
            EventHandler<LotClickEventArgs> handler = this.LotClickEvent;
            if (handler != null)
                handler(this, e);
        }

    }

    public class LotClickEventArgs : EventArgs
    {
        protected ParkingLotView mLot;

        public LotClickEventArgs(ParkingLotView lot)
        {
            if(lot == null)
                throw new ArgumentNullException("lot", "parameter cannot be null");

            this.mLot = lot;
        }


        public ParkingLotView Lot
        {
            get
            {
                return this.mLot;
            }
        }
        
    }
}
