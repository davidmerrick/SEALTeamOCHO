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
    public partial class MapFrame : UserControl
    {
        protected Image mMapImage;
        protected Window myWindow;
        protected Point centerBeforeDrag = new Point(100, 100);
        protected Point mouseStart = new Point(0, 0);
        protected Size originalWindowSize;
        protected float scalingFactor = 1.0f;

        public MapFrame()
        {
            InitializeComponent();

            this.mMapImage = null;

            this.myWindow = new Window();
            this.myWindow.Center = new Point(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
            this.myWindow.Dimensions = new Size(this.ClientSize.Width, this.ClientSize.Height);
            this.centerBeforeDrag = this.myWindow.Center;
            this.originalWindowSize = new Size(this.ClientSize.Width, this.ClientSize.Height);
            this.DoubleBuffered = true;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            

            //convert world coords to viewport coords
            dc.TranslateTransform((float)-this.myWindow.Xmin, (float)-this.myWindow.Ymin, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            dc.ScaleTransform((float)this.ClientSize.Width / (float)this.myWindow.Dimensions.Width,
                (float)this.ClientSize.Height / (float)this.myWindow.Dimensions.Height, System.Drawing.Drawing2D.MatrixOrder.Prepend);

            if(this.mMapImage != null) dc.DrawImage(this.mMapImage, new Point(0, 0));
            this.DrawAdditionalGraphics(dc);
            base.OnPaint(e);
        }

        protected virtual void DrawAdditionalGraphics(Graphics dc)
        {

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.mouseStart = e.Location;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.myWindow.Center.X = this.centerBeforeDrag.X - (e.X - this.mouseStart.X);
                this.myWindow.Center.Y = this.centerBeforeDrag.Y - (e.Y - this.mouseStart.Y);
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
            this.scalingFactor = this.scalingFactor - e.Delta * 0.001f;
            this.myWindow.Dimensions.Width = (int)((float)this.originalWindowSize.Width * scalingFactor);
            this.myWindow.Dimensions.Height = (int)((float)this.originalWindowSize.Height * scalingFactor);
            this.Invalidate();
            base.OnMouseWheel(e);
        }

        public Image MapImage
        {
            get
            {
                return this.mMapImage;
            }
            set
            {
                this.mMapImage = value;
            }
        }

        protected Matrix GetPageTransform()
        {
            Matrix transform = new Matrix();
            transform.Reset();
            transform.Translate((float)-this.myWindow.Xmin, (float)-this.myWindow.Ymin, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            transform.Scale((float)this.ClientSize.Width / (float)this.myWindow.Dimensions.Width,
            (float)this.ClientSize.Height / (float)this.myWindow.Dimensions.Height, System.Drawing.Drawing2D.MatrixOrder.Prepend);

            return transform;
        }
    }


    public class Window
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
