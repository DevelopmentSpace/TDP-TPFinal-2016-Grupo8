using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL.EntityFramework
{
    class TextBannerRepository : EFRepository<TextBanner, DigitalSignageDbContext>
    {
        public TextBannerRepository(DigitalSignageDbContext pContext) : base(pContext)
        {
        }
    }
}
