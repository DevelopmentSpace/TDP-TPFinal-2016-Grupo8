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
        /// <summary>
        /// Representa una Mapping entre el objeto y las tablas de entity framework
        /// </summary>
        public RssBannerMap()
        {
            //Especifica que un banner rss tiene muchos items y que la clave foranea es rssBannerId, con eliminacion en cascada.
            this.HasMany<RssItem>(pBanner => pBanner.items)
                .WithRequired()
                .HasForeignKey<int>(i => i.rssBannerId)
                .WillCascadeOnDelete();
        }
    }
}
