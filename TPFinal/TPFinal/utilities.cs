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

        public static IList<TimeSpan> createTimeSpans(string initHour,string initMinute,string endHour,string endMinute)
        {
            int initHourInt, endHourInt, initMinuteInt, endMinuteInt;
            IList<TimeSpan> listTimeSpan = new List< TimeSpan> { };

            initHourInt = Convert.ToInt32(initHour);
            endHourInt = Convert.ToInt32(endHour);
            initMinuteInt = Convert.ToInt32(initMinute);
            endMinuteInt = Convert.ToInt32(endMinute);

            if (initHourInt < 0 || initHourInt > 23 || endHourInt < 0 || endHourInt > 23 || ((initHourInt >= endHourInt) && (initMinuteInt >= endMinuteInt)) || initMinuteInt < 0 || initMinuteInt > 59 || endMinuteInt < 0 || endMinuteInt > 59)
            {
                throw new ArgumentException();
            }

            listTimeSpan.Add(new TimeSpan(initHourInt, initMinuteInt, 0));
            listTimeSpan.Add(new TimeSpan(endHourInt, endMinuteInt, 0));

            return listTimeSpan;
        }
    }
}
