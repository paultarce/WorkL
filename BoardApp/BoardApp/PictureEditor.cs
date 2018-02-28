using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

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
    }
}
