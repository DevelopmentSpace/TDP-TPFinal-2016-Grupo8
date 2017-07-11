using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL
{
    interface IBannerRepository : IRepository<Banner>
    {
        IList<Banner> GetActives(DateTime pDate, DateTime pTinit, DateTime pTfinish);

    }
}
