using System.IO;
using System.Windows.Media.Imaging;

namespace ChatStudents_Sabitov.Classes.Common
{
    public class BitmapFromArrayByte
    {
        public static BitmapImage LoadImage(byte[] data)
        {
            BitmapImage image = new();
            using (var stream = new MemoryStream(data))
            {
                stream.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = stream;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
