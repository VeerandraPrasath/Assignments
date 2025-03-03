using System.Drawing;
using Task5;

namespace Plugins
{
    public class ResizeImage:IImageProcessor
    {
        public Bitmap GitMapProcessor(Bitmap bitMap)
        {
            int newWidth = bitMap.Width / 2;
            int newHeight = bitMap.Height / 2;
            Bitmap resizedBitmap = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(resizedBitmap))
            {
                graphics.DrawImage(bitMap, 0, 0, newWidth, newHeight);
            }
            Console.WriteLine("Image resized sucessfully !");

            return resizedBitmap;
        }
    }
}
