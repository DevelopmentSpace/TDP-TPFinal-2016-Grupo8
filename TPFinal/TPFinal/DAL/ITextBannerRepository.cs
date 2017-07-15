using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL
{
    public interface ITextBannerRepository : IRepository<TextBanner>
    {
        IEnumerable<TextBanner> GetActives(DateTime pDate, TimeSpan pTimeFrom, TimeSpan pTimeTo);
    }
}
