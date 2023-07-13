using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SIGENFirmador
{
    public class PanelFirm:Panel
    {
        //campos
        private int borderRadius = 30;

        //constructor 
        public PanelFirm()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Gray;
            this.Size = new Size(500, 350);

        }
        //propiedades 
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; this.Invalidate(); }
        }

        //metodos
        private GraphicsPath GetFirmadorPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, 1, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }
        //Overriden methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //Border Radius

            RectangleF rectangleF = new RectangleF(0, 0, this.Width, this.Height);
            if (borderRadius > 2)
            {
                using (GraphicsPath graphicPath = GetFirmadorPath(rectangleF, borderRadius))
                using (Pen pen = new Pen(this.Parent.BackColor, 2))
                {
                    this.Region = new Region(graphicPath);
                    e.Graphics.DrawPath(pen, graphicPath);
                }

            }
            else this.Region = new Region(rectangleF);
        }

    }
}
