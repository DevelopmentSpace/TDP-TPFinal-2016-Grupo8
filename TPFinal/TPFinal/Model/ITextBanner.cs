using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.Model
{
    interface ITextBanner
    {
       String GetText();

       void Refresh();

        bool IsActive(Banner pBanner);
    }
}
