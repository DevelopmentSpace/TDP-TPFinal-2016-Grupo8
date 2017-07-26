using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace TPFinal
{
    class Utilities
    {
        public static Byte[] imageToByte(Image i)
        {
            MemoryStream stream = new MemoryStream();
            i.Save(stream, ImageFormat.Png);
            byte[] bytes = stream.ToArray();
            return bytes;
        }
    }
}
