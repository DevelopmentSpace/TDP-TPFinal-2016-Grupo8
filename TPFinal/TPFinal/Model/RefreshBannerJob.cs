using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace TPFinal.Model
{
    class RefreshBannerJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            /*foreach (ITextBanner textBanner in iTextBannerList)
            {
                textBanner.Refresh();
            }

            NotifyListeners();*/
        }
    }
}
