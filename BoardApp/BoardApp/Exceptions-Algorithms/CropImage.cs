using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BoardApp.Exceptions_Algorithms
{
    public static class CropImage
    {

        public static Image Fit2PictureBox(this Image image, PictureBox picBox)
        {
            Bitmap bmp = null;
            Graphics g;

            // Scale:
            double scaleY = (double)image.Width / picBox.Width;
            double scaleX = (double)image.Height / picBox.Height;
            double scale = scaleY < scaleX ? scaleX : scaleY;

            // Create new bitmap:
            bmp = new Bitmap(
                (int)((double)picBox.Width / scale),
                (int)((double)picBox.Height / scale));

            // Set resolution of the new image:
            bmp.SetResolution(
                image.HorizontalResolution,
                image.VerticalResolution);

            // Create graphics:
            g = Graphics.FromImage(bmp);

            // Set interpolation mode:
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Draw the new image:
            g.DrawImage(
                image,
                new Rectangle(            // Destination
                    0, 0,
                    bmp.Width, bmp.Height),
                new Rectangle(            // Source
                    0, 0,
                    image.Width, image.Height),
                GraphicsUnit.Pixel);

            // Release the resources of the graphics:
            g.Dispose();

            // Release the resources of the origin image:
            image.Dispose();

            return bmp;
        }

        public static Image Crop(this Image image, Rectangle selection,PictureBox pict)
        {
            Bitmap bmp = image as Bitmap;

            // Check if it is a bitmap:
            if (bmp == null)
                throw new ArgumentException("No valid bitmap");

            // Crop the image:
            double factorX =(double)image.Width / pict.Width;
            double factorY = (double)image.Height / pict.Height;

            double width = factorX * selection.Width;
            double height = factorY * selection.Height;

            selection.Height = (int)Math.Floor(height);
            selection.Width = (int)Math.Floor(width);
            selection.X = (int)Math.Floor( selection.X * factorX);
            selection.Y = (int)Math.Floor(selection.Y * factorY);
            Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);

            // Release the resources:
            image.Dispose();

            return cropBmp;
        }
    }
}
