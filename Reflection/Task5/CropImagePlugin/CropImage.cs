using System.Drawing;
using Task5;

namespace Plugins
{
    public class CropImage :IImageProcessor
    {
        public Bitmap GitMapProcessor(Bitmap bitMap)
        {
            int cropWidth = bitMap.Width / 2;
            int cropHeight = bitMap.Height / 2;
            Rectangle cropRect = new Rectangle(0, 0, cropWidth, cropHeight);
            Bitmap croppedBitmap = bitMap.Clone(cropRect, bitMap.PixelFormat);
            Console.WriteLine("Image croped successfully !");

            return croppedBitmap;
        }
    }
}
