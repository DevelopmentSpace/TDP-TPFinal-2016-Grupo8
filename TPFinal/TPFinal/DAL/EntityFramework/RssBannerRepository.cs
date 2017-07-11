using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL.EntityFramework
{
    class RssBannerRepository : EFRepository<RssBanner, DigitalSignageDbContext>, IRssBannerRepository
    {
        public RssBannerRepository(DigitalSignageDbContext pContext) : base(pContext)
        {
        }
    }
}
