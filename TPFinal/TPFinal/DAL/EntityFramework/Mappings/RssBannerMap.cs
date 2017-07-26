using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL.EntityFramework.Mappings
{
    class RssBannerMap: EntityTypeConfiguration<RssBanner>
    {
        public RssBannerMap()
        {
            this.HasMany<RssItem>(pBanner => pBanner.items)
                .WithRequired()
                .HasForeignKey<int>(i => i.rssBannerId)
                .WillCascadeOnDelete();
        }
    }
}
