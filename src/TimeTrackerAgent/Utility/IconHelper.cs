using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace TimeTrackerAgent.Utility
{
    public static class IconHelper
    {
        public static byte[] IconToBytes(Bitmap img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
