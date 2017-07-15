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
        DigitalSignageDbContext iDbContext;
        public TextBannerRepository(DigitalSignageDbContext pContext) : base(pContext)
        {
            this.iDbContext = pContext;
        }

        public IEnumerable<TextBanner> GetActives(DateTime pDate, TimeSpan pTimeFrom, TimeSpan pTimeTo)
        {
            if (pDate == null)
                throw new ArgumentNullException("pDate");
            if (pTimeFrom == null)
                throw new ArgumentNullException("pTimeFrom");
            if (pTimeTo == null)
                throw new ArgumentNullException("pTimeTo");
            if (pTimeFrom.CompareTo(pTimeTo) > -1)
                throw new InvalidOperationException("pTimeFrom debe ser menor que pTimeTo");



            IQueryable<TextBanner> query = from textBanner in this.iDbContext.Set<TextBanner>()
                                          where
                                              (textBanner.initDate <= pDate && textBanner.endDate >= pDate)
                                              &&
                                              (textBanner.initTime <= pTimeTo && textBanner.endTime >= pTimeFrom)
                                          select textBanner;

            var sqlString = query.ToString();

            return query;
        }
    }
}
