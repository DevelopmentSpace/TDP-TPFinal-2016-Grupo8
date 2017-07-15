using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL
{
    public interface IRssBannerRepository : IRepository<RssBanner>
    {
        IList<RssBanner> GetActives(DateTime pDateFrom1, DateTime pDateFrom2, DateTime pDateTo);
    }
}
