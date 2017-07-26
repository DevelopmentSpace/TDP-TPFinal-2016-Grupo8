using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Domain
{
    /// <summary>
    /// Representa un banner cuya fuente de text es RSS
    /// </summary>
    public class RssBanner : Banner
    {
        /// <summary>
        /// Url del RSS
        /// </summary>
        public String url { get; set; }

        /// <summary>
        /// Lista de Items RSS
        /// </summary>
        virtual public IList<RssItem> items { get; set; }
    }
}
