using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL.EntityFramework
{
    class CampaignRepository : EFRepository<Campaign, DigitalSignageDbContext>, ICampaignRespository
    {

        DbContext iDbContext;

        public CampaignRepository(DigitalSignageDbContext pContext) : base(pContext)
        {
            this.iDbContext = pContext;
        }

        public IEnumerable<Campaign> GetActives(DateTime pDate, TimeSpan pTimeFrom, TimeSpan pTimeTo)
        {

            if (pDate == null)
                throw new ArgumentNullException("pDate");
            if (pTimeFrom == null)
                throw new ArgumentNullException("pTimeFrom");
            if (pTimeTo == null)
                throw new ArgumentNullException("pTimeTo");
            if (pTimeFrom.CompareTo(pTimeTo) > -1)
                throw new InvalidOperationException("pTimeFrom debe ser menor que pTimeTo");
           


            IQueryable<Campaign> query = from campaign in this.iDbContext.Set<Campaign>()
                                         where
                                             (campaign.initDate <= pDate && campaign.endDate >= pDate)
                                             &&
                                             (campaign.initTime <= pTimeTo && campaign.endTime >= pTimeFrom)
                        select campaign;

            var sqlString = query.ToString();

            return query;
        }
    }
}
