using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardApp.Exceptions_Algorithms
{
    public static class MyExtensions
    {
        public static PictureBox CreateNewWithAttribute(this PictureBox pb)
        {
            return new PictureBox { Image = pb.Image, Width = pb.Width };
        }
        
    }
}
