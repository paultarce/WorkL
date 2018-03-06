using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.Windows.Forms;

namespace BoardApp.Exceptions_Algorithms
{
    public class Crop
    {
        Image<Bgr, byte> imgInput;
        Rectangle rect;
        Point StartLocation;
        Point EndLocation;


        public Crop(ref PictureBox p)
        {
            Bitmap b = new Bitmap(p.Image);
            imgInput = new Image<Bgr, byte>(b);
            p.Image = imgInput.Bitmap;
        }

        public Rectangle GetRectangle()
        {
            rect = new Rectangle();
            rect.X = Math.Min(StartLocation.X, EndLocation.X); //pentru a putea desena dreptunghiul de crop in oricare directie
            rect.Y = Math.Min(StartLocation.Y, EndLocation.Y);
            rect.Width = Math.Abs(StartLocation.X - EndLocation.X);
            rect.Height = Math.Abs(StartLocation.Y - EndLocation.Y);

            return rect;
        }
        public void Paint(PaintEventArgs e)
        {
            if(rect!=null)
            {
                e.Graphics.DrawRectangle(Pens.Red, GetRectangle());
            }
        }
        public void MouseDown(MouseEventArgs e)
        {
            StartLocation = e.Location;
        }
        public void MouseMove(MouseEventArgs e,ref PictureBox p)
        {
            EndLocation = e.Location;
            p.Invalidate();

        }
        public void MouseUp(MouseEventArgs e,ref bool IsMouseDown,ref PictureBox p)
        {
            
            if(IsMouseDown == true)
            {
                EndLocation = e.Location;
                IsMouseDown = false;
                if(rect != null)
                {
                    imgInput.ROI = rect;// region of interest
                    Image<Bgr, byte> temp = imgInput.CopyBlank();
                    imgInput.CopyTo(temp);
                    imgInput.ROI = Rectangle.Empty;
                    p.Image = temp.Bitmap;
                }
            }

        }
    }
}
