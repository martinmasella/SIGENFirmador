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
    public class SolapaFirm : Button
    {
        //campos
        private int borderSize = 0;
        private int borderRadius = 40;
        private Color borderColor = Color.FromArgb(93, 23, 175);

        //constructor
        public SolapaFirm()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(136, 40);
            this.BackColor = Color.FromArgb(93, 23, 175);
            this.ForeColor = Color.White;

        }
        //metodo
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, 90, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, 90, 90, 90, 90);
            path.CloseFigure();

            return path;

        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width, this.Height);

            if (borderRadius > 2) //borde redondeado
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    //boton
                    this.Region = new Region(pathSurface);
                    //dibuja el borde de la superficie
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    //borde del boton
                    if (borderSize >= 1)
                        //dibuja el borde del control
                        pevent.Graphics.DrawPath(penBorder, pathBorder);

                }
            }
            else //boton normal
            {
                //boton
                this.Region = new Region(rectSurface);
                //borde del boton
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);

                    }
                }
            }


        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }
        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }

    }

}
