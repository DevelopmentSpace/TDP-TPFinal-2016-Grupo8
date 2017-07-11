using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Domain
{
    public class RssBanner : Banner
    {
        public String url { get; set; }

        public String description { get; set; }

        public virtual IList<RssItem> items { get; set; }
    }
}
