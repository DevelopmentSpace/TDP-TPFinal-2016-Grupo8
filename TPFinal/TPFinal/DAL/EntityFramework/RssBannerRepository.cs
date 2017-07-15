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
        DigitalSignageDbContext iDbContext;
        public RssBannerRepository(DigitalSignageDbContext pContext) : base(pContext)
        {
            this.iDbContext = pContext;
        }

        public IEnumerable<RssBanner> GetActives(DateTime pDate, TimeSpan pTimeFrom, TimeSpan pTimeTo)
        {
            if (pDate == null)
                throw new ArgumentNullException("pDate");
            if (pTimeFrom == null)
                throw new ArgumentNullException("pTimeFrom");
            if (pTimeTo == null)
                throw new ArgumentNullException("pTimeTo");
            if (pTimeFrom.CompareTo(pTimeTo) > -1)
                throw new InvalidOperationException("pTimeFrom debe ser menor que pTimeTo");



            IQueryable<RssBanner> query = from rssBanner in this.iDbContext.Set<RssBanner>()
                                         where
                                             (rssBanner.initDate <= pDate && rssBanner.endDate >= pDate)
                                             &&
                                             (rssBanner.initTime <= pTimeTo && rssBanner.endTime >= pTimeFrom)
                                         select rssBanner;

            var sqlString = query.ToString();

            return query;
        }
    }
}
