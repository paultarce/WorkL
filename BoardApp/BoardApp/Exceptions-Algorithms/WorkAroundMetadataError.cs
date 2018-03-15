using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BoardApp.Exceptions_Algorithms
{
    class WorkAroundMetadataError
    {
        private BitmapImage ImageFromGDIplus(string uriPath)

        {

            Bitmap badMetadataImage = new Bitmap(uriPath);

            ImageCodecInfo myImageCodecInfo;

            System.Drawing.Imaging.Encoder myEncoder;

            EncoderParameter myEncoderParameter;

            EncoderParameters myEncoderParameters;

            // get an ImageCodecInfo object that represents the JPEG codec

            myImageCodecInfo = GetEncoderInfo("image/jpeg");

            // Create an Encoder object based on the GUID for the Quality parameter category

            myEncoder = System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object

            // An EncoderParameters object has an array of EncoderParameter objects.

            // In this case, there is only one EncoderParameter object in the array.

            myEncoderParameters = new EncoderParameters(1);

            // Save the image as a JPEG file with quality level 75.

            myEncoderParameter = new EncoderParameter(myEncoder, 75L);

            myEncoderParameters.Param[0] = myEncoderParameter;

            badMetadataImage.Save(@"C:\Temp\foo.bmp", myImageCodecInfo, myEncoderParameters);

            // Create the source to use as the tb source

            BitmapImage bi = new BitmapImage();

            bi.BeginInit();

            bi.UriSource = new Uri(@"C:\Temp\foo.bmp", UriKind.Absolute);

            bi.EndInit();

            return bi;

        }





        private static ImageCodecInfo GetEncoderInfo(String mimeType)

        {

            int j;

            ImageCodecInfo[] encoders;

            encoders = ImageCodecInfo.GetImageEncoders();

            for (j = 0; j < encoders.Length; ++j)

            {

                if (encoders[j].MimeType == mimeType)

                    return encoders[j];

            }

            return null;

        }
    }
}
