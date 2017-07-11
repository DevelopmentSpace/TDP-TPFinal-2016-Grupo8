using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.DAL.EntityFramework.Mappings;
using TPFinal.Domain;

namespace TPFinal.DAL.EntityFramework
{
    internal class DigitalSignageDbContext:DbContext
    {
    
        /// <summary>
        /// DbSet para Campañas
        /// </summary>
        public DbSet<Campaign> campaigns { get; set; }

        public DbSet<Banner> banners { get; set; }

        public DbSet<RssBanner> rssBanners { get; set; }

        public DbSet<TextBanner> textBanners { get; set; }

        public DbSet<RssItem> rssItems { get; set; }


        /*
public DigitalSignage() : base("DigitalSignage")
{
    // Se establece la estrategia personalizada de inicialización de la BBDD.
    Database.SetInitializer<DigitalSignage>(new DatabaseInitializationStrategy());
}*/

        /// <summary>
        /// Sustitucion del metodo OnModelCreating
        /// </summary>
        /// <param name="pModelBuilder">Model builder</param>
        protected override void OnModelCreating(DbModelBuilder pModelBuilder)
        {
            pModelBuilder.Configurations.Add(new CampaignMap());
            pModelBuilder.Configurations.Add(new BannerMap());
            pModelBuilder.Configurations.Add(new RssBannerMap());
            pModelBuilder.Configurations.Add(new TextBannerMap());
            pModelBuilder.Configurations.Add(new RssItemMap());


            base.OnModelCreating(pModelBuilder);
        }
    }
}
