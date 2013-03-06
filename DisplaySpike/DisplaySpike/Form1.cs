using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisplaySpike
{
    public partial class Form1 : Form
    {
        Rectangle myRect = new Rectangle(0, 0, 100, 100);
        Pen bluePen = new Pen(Color.Blue, 2);
        Window myWindow;
        Point centerBeforeDrag = new Point(100, 100);
        Point mouseStart = new Point(0, 0);
        Size originalWindowSize;
        float scalingFactor = 1.0f;
        Image myImage = DisplaySpike.Properties.Resources.CampusMap;
        List<Region> parkingLots;
        List<Brush> parkingLotFills;
        int? selectedLotIndex;
        String statusText;


        //predefined brushes
        SolidBrush normalBrush = new SolidBrush(Color.FromArgb(180, Color.LawnGreen));
        SolidBrush selectedBrush = new SolidBrush(Color.FromArgb(240, Color.LawnGreen));

        public Form1()
        {
            InitializeComponent();
            this.myWindow = new Window();
            this.myWindow.Center = new Point(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
            this.myWindow.Dimensions = new Size(this.ClientSize.Width, this.ClientSize.Height);
            this.centerBeforeDrag = this.myWindow.Center;
            this.originalWindowSize = new Size(this.ClientSize.Width, this.ClientSize.Height);
            this.DoubleBuffered = true;
            this.statusText = "No selection";

            //create parking lot regions
            parkingLots = new List<Region>();
            parkingLotFills = new List<Brush>();

            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(new Point[] { new Point(20, 20), new Point(20, 60), new Point(50, 60), new Point(50, 20) });
            parkingLots.Add(new Region(path));
            parkingLotFills.Add(normalBrush);

            path = new GraphicsPath();
            path.AddPolygon(new Point[] { new Point(100,40), new Point(150,40), new Point(150,90), new Point(200,90),
                new Point(200,150), new Point(100,150)});
            parkingLots.Add(new Region(path));
            parkingLotFills.Add(normalBrush);

            path = new GraphicsPath();
            path.AddPolygon(new Point[] { new Point(300, 100), new Point(360, 100), new Point(340, 300), new Point(280, 300) });
            parkingLots.Add(new Region(path));
            parkingLotFills.Add(normalBrush);

            this.selectedLotIndex = null;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;

            //convert world coords to viewport coords
            dc.TranslateTransform((float)-this.myWindow.Xmin, (float)-this.myWindow.Ymin, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            dc.ScaleTransform((float)this.ClientSize.Width / (float)this.myWindow.Dimensions.Width,
                (float)this.ClientSize.Height / (float)this.myWindow.Dimensions.Height, System.Drawing.Drawing2D.MatrixOrder.Prepend);

            dc.DrawImage(myImage, new Point(0, 0));
            

            int i = 0;
            foreach (Region r in this.parkingLots)
            {
                dc.FillRegion(this.parkingLotFills[i], r);
                i++;
            }

            dc.ResetTransform();
            //draw status string
            Font textFont = new Font("Arial", 14, FontStyle.Regular);
            Brush textBrush = Brushes.Black;
            dc.DrawString(this.statusText, textFont, textBrush, 10.0f, 10.0f);

            base.OnPaint(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.mouseStart = e.Location;
            }
            this.statusText = "";
            base.OnMouseDown(e);
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.myWindow.Center.X = this.centerBeforeDrag.X - (e.X - this.mouseStart.X);
                this.myWindow.Center.Y = this.centerBeforeDrag.Y - (e.Y - this.mouseStart.Y);
            }
            else
            {
                Matrix transform = new Matrix();
                transform.Reset();
                transform.Translate((float)-this.myWindow.Xmin, (float)-this.myWindow.Ymin, System.Drawing.Drawing2D.MatrixOrder.Prepend);
                transform.Scale((float)this.ClientSize.Width / (float)this.myWindow.Dimensions.Width,
                (float)this.ClientSize.Height / (float)this.myWindow.Dimensions.Height, System.Drawing.Drawing2D.MatrixOrder.Prepend);

                //determine whether the mouse is over any region
                foreach (Brush b in this.parkingLotFills)
                {
                    
                }

                bool inRegion = false;

                int i = 0;
                foreach (Region rWorld in this.parkingLots)
                {
                    Region rPage = rWorld.Clone();
                    rPage.Transform(transform);
                    if (rPage.IsVisible(e.Location))
                    {
                        inRegion = true;
                        this.statusText = String.Format("Region {0}", i);
                        this.parkingLotFills[i] = this.selectedBrush;
                        if(this.selectedLotIndex.HasValue && this.selectedLotIndex != i)
                            this.parkingLotFills[this.selectedLotIndex.Value] = this.normalBrush;
                        this.selectedLotIndex = i;
                        break;
                    }
                    i++;
                }

                if (!inRegion && this.selectedLotIndex.HasValue)
                {
                    this.statusText = "No selection";
                    this.parkingLotFills[this.selectedLotIndex.Value] = this.normalBrush;
                    this.selectedLotIndex = null;
                }
            }

            this.Invalidate();
            base.OnMouseMove(e);
        }


        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.centerBeforeDrag = this.myWindow.Center;

            base.OnMouseUp(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            //adjust Window size
            this.scalingFactor =  this.scalingFactor - e.Delta * 0.001f;
            this.myWindow.Dimensions.Width = (int) ((float) this.originalWindowSize.Width * scalingFactor);
            this.myWindow.Dimensions.Height = (int)((float)this.originalWindowSize.Height * scalingFactor);
            this.Invalidate();
            base.OnMouseWheel(e);
        }
    }


    class Window
    {
        public Point Center;
        public Size Dimensions;

        public int Xmin
        {
            get
            {
                return Center.X - Dimensions.Width / 2;
            }
        }

        public int Ymin
        {
            get
            {
                return Center.Y - Dimensions.Height / 2;
            }
        }
    }
}
