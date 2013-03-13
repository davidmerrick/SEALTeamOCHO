using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParkingLotCreator
{
    public partial class LotCreatorFrame : TAPS.UI.MapFrame
    {

        protected bool isDrawing;
        protected Rectangle drawingRectangle;
        protected List<Rectangle> mSpaces;
        protected LotCreatorMode mMode;

        public LotCreatorFrame()
        {
            InitializeComponent();

            this.isDrawing = false;
        }

        public enum LotCreatorMode
        {
            drawing,
            selection
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if(this.mMode == LotCreatorMode.drawing)
            {
                //start drawing parking space rectangle
                this.isDrawing = true;
                this.drawingRectangle = new Rectangle(e.X, e.Y, 1, 1);
            }
            else if(this.mMode == LotCreatorMode.selection)
            {
                //determine if a space is selected


                //only allow the base class to pan the image if we are not
                //in drawing mode
                base.OnMouseDown(e);
            } 
        }

        protected int getSelectedSpaceIndex(Point pt)
        {
            //get a transformation matrix for transforming world to page coords
            Matrix transform = base.GetPageTransform();

            foreach (Rectangle spc in this.mSpaces)
            {
                //convert the rectangle to page coords
                Rectangle pageRect = transformRectangle(spc, transform);
                if (pageRect.Contains(pt))
                {
                    
                }
            }

            return 0;
        }

        //assumes that 'transform' consists of only translation and scaling
        protected Rectangle transformRectangle(Rectangle r, Matrix transform)
        {
            //array contains the points: top left corner, top right corner, bottom left corner
            Point[] pts = new Point[] {new Point(r.X,r.Y),
                                        new Point(r.X + r.Width, r.Y),
                                        new Point(r.X, r.Y + r.Height)};

            transform.TransformPoints(pts);
            Rectangle newRect = new Rectangle(pts[0].X, pts[0].Y, pts[1].X - pts[0].X, pts[2].Y - pts[0].Y);
            return newRect;
        }
    }
}
