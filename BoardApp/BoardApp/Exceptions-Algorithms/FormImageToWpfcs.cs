
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace BoardApp.Exceptions_Algorithms
{
    public class FormImageToWpfcs
    {
        /* public static BitmapImage ToWpfImage(this System.Drawing.Image img)
         {
             MemoryStream ms = new MemoryStream();  // no using here! BitmapImage will dispose the stream after loading
             img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

             BitmapImage ix = new BitmapImage();
             ix.BeginInit();
             ix.CacheOption = BitmapCacheOption.OnLoad; 
             ix.StreamSource = ms;
             ix.EndInit();
             return ix;
         }*/

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        /* public static System.Windows.Controls.Image ConvertDrawingImageToWPFImage(System.Drawing.Image gdiImg)
         {
             System.Windows.Controls.Image img = new System.Windows.Controls.Image();
             System.Windows.Media.ImageSource WpfBitmap;// new System.Windows.Media.ImageSource();

             //convert System.Drawing.Image to WPF image

             using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(gdiImg))
             {
                 IntPtr hBitmap = bmp.GetHbitmap();
                 try
                 {
                     WpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                 }
                 finally
                 {
                     DeleteObject(hBitmap);
                 }
                 img.Source = WpfBitmap;
                 img.Width = 500;
                 img.Height = 600;
                 img.Stretch = System.Windows.Media.Stretch.Fill;
                 return img;
             }
         }*/
        public static BitmapSource BitmapFromBase64(string base64String)
        {
            var bytes = Convert.FromBase64String(base64String);

            using (var stream = new MemoryStream(bytes))
            {
                return BitmapFrame.Create(stream,
                    BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }
        public static string BitmapToBase64String(System.Drawing.Image image)
        {

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byteImage = ms.ToArray();
            Convert.ToBase64String(byteImage); //here you should get a base64 string
            return Convert.ToBase64String(byteImage);
        }
    }
}

/*I had to change this lines:
img.Width = 500;
img.Height = 600;
with this:
img.Width = gdiImg.Width;
img.Height = gdiImg.Height;
to be able to adjust dynamcaly the image resolution
*/
