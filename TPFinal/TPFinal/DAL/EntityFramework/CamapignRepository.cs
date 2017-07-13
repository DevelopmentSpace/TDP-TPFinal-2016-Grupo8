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

        public IEnumerable<Campaign> GetActives(DateTime pDateFrom, DateTime pDateTo)
        {
            IQueryable<Campaign> query = from campaign in this.iDbContext.Set<Campaign>()
                        where ((DbFunctions.TruncateTime(campaign.initDateTime) <= pDateFrom.Date && DbFunctions.TruncateTime(campaign.endDateTime) >= pDateTo.Date)
                        || (DbFunctions.TruncateTime(campaign.initDateTime) >= pDateFrom.Date && DbFunctions.TruncateTime(campaign.initDateTime) <= pDateTo.Date))
                        select campaign;

            var sqlString = query.ToString();

            return from campaign in this.iDbContext.Set<Campaign>()
                   select campaign;

            /*
            return from campaign in this.iDbContext.Set<Campaign>()
                   where ((DbFunctions.TruncateTime(campaign.initDateTime) <= pDateFrom.Date && DbFunctions.TruncateTime(campaign.endDateTime) >= pDateTo.Date) 
                   || (DbFunctions.TruncateTime(campaign.initDateTime) >= pDateFrom.Date && DbFunctions.TruncateTime(campaign.initDateTime) <= pDateTo.Date))
                   select campaign;*/
            /*

            return from campaign in this.iDbContext.Set<Campaign>()
                   where  ((campaign.initDateTime.Date <= pDateFrom.Date && campaign.endDateTime.Date >= pDateTo.Date) || (campaign.initDateTime >= pDateFrom.Date && campaign.initDateTime.Date <= pDateTo.Date))
                   select campaign;*/
        }
    }
}
