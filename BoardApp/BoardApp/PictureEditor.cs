using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using AForge.Imaging;
using System.Drawing.Imaging;

namespace BoardApp
{
    // this class has methods that have raw Bitmaps / picture and sets their size
    public class PictureEditor
    {
        public static PictureBox PictBoxTOflowLayout( PictureBox myPict)
        {
            myPict.SetBounds(0, 0, 80, 80);
            myPict.BackColor = Color.Black;
            myPict.SizeMode = PictureBoxSizeMode.Zoom;

            return myPict;
        }
        
        public static void ShowPictureFullSreen(ref FullScreenForm f,ref PictureBox p)
        {
            f.Close();
            f = new FullScreenForm();
            Screen[] screens = Screen.AllScreens;
            Rectangle bounds = screens[0].Bounds;
            f.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);

            //f.pb.SetBounds(0, 0, 300, 300);
            f.pb.BackColor = Color.Black;
            f.pb.SizeMode = PictureBoxSizeMode.StretchImage;

            f.pb.Image = p.Image;
            f.Show(); ///Close after showing once
        }

        public static void ShowPictureFullSreen2(ref FullScreenForm f, ref PictureBox p)
        {
            f.Close();
            f = new FullScreenForm();

            if (Screen.AllScreens.Length > 1)
            {
                f.StartPosition = FormStartPosition.Manual;
                Screen screen = GetSecondaryScreen();
                f.Location = screen.WorkingArea.Location;
                f.Size = new Size(screen.WorkingArea.Width, screen.WorkingArea.Height);

                f.pb.BackColor = Color.Black;
                f.pb.SizeMode = PictureBoxSizeMode.StretchImage ;
                f.pb.Image = p.Image;
                f.Show();

            }
        }

        private static Screen GetSecondaryScreen()
        {
            if (Screen.AllScreens.Length == 1)
            {
                return null;
            }
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Primary == false)
                {
                    return screen;
                }
            }
            return null;
        }

        public static void TbRotate(ref FullScreenForm f,PictureBox p,int value)
        {

            /*Bitmap image = (Bitmap)f.pb.Image;
            Bitmap a = AForge.Imaging.Image.Clone(image, PixelFormat.Format24bppRgb);  //convert your image to 8bpp and grayscale
            //AForge.Imaging.Image.SetGrayscalePalette(a);                   
            RotateBilinear ro = new RotateBilinear(value, true);
            Bitmap image2 = ro.Apply(a);
            f.pb.Image = image2;
            //f.Invalidate();
            */
            f.pb.Image = p.Image;

        }
        public static void TbSizeVertical(ref FullScreenForm f,ref PictureBox p)
        {
            f.pb.Image = p.Image;
        }
         
        public static void Zoom()
        {

        }

        
    }
}
