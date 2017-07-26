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
    /// <summary>
    /// Clase de herramientas suplementarias
    /// </summary>
    class Utilities
    {
        /// <summary>
        /// Crea un array de bytes a partir de una imagen.
        /// </summary>
        /// <param name="i">Imagen</param>
        /// <returns>Array de bytes que hacen la imagen</returns>
        public static Byte[] imageToByte(Image i)
        {
            MemoryStream stream = new MemoryStream();
            i.Save(stream, ImageFormat.Png);
            byte[] bytes = stream.ToArray();
            return bytes;
        }

        /// <summary>
        /// Crea dos TimeSpans a partir de una hora y minuto de inicio y de fin.
        /// </summary>
        /// <param name="initHour">Hora de inicio en string</param>
        /// <param name="initMinute">Minuto de inicio en string</param>
        /// <param name="endHour">Hora de fin en string</param>
        /// <param name="endMinute">Minuto de fin en string</param>
        /// <returns>Lista con dos TimeSpan(Inicio en posicion 0 y fin en posicion 1)</returns>
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
