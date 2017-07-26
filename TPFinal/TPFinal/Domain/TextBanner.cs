using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Domain
{
    /// <summary>
    /// Representa un banner con texto estático
    /// </summary>
    public class TextBanner : Banner
    {
        /// <summary>
        /// Texto del banner
        /// </summary>
        public String text { get; set; }
    }
}
