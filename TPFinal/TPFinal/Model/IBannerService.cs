using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Model
{
    interface IBannerService : IObservable
    {
        void AddService(ITextBanner textBanner);

        String GetText();

        void ForceUpdate();
    }
}
