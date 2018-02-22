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
    }
}
