﻿using log4net;
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
    /// <summary>
    /// Contexto de entity framework
    /// </summary>
    public class DigitalSignageDbContext:DbContext
    {
		private static readonly ILog cLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// DbSet para Campañas
		/// </summary>
		public DbSet<Campaign> campaigns { get; set; }

        /// <summary>
        /// DbSet para banners
        /// </summary>
        public DbSet<Banner> banners { get; set; }

        /// <summary>
        /// DbSet para banners RSS
        /// </summary>
        public DbSet<RssBanner> rssBanners { get; set; }

        /// <summary>
        /// DbSet para banners estaticos
        /// </summary>
        public DbSet<TextBanner> textBanners { get; set; }

        /// <summary>
        /// DbSet para items RSS
        /// </summary>
        public DbSet<RssItem> rssItems { get; set; }

        /// <summary>
        /// DbSet para imagenes de las campañas
        /// </summary>
        public DbSet<ByteImage> byteImages { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        public DigitalSignageDbContext() : base("DigitalSignage")
        {
            cLogger.Info("Creando instancia de dbContext");

            // Se establece la estrategia personalizada de inicialización de la BBDD.
            Database.SetInitializer<DigitalSignageDbContext>(new DropCreateDatabaseIfModelChanges<DigitalSignageDbContext>());
            //Database.SetInitializer<DigitalSignageDbContext>(new DropCreateDatabaseAlways<DigitalSignageDbContext>());
        }

        /// <summary>
        /// Constructor for testing
        /// </summary>
        /// <param name="name">nombre de la Base de Datos</param>
        public DigitalSignageDbContext(String name) : base(name)
        {
            // Se establece la estrategia personalizada de inicialización de la BBDD.
            Database.SetInitializer<DigitalSignageDbContext>(new DropCreateDatabaseAlways<DigitalSignageDbContext>());
        }

        /// <summary>
        /// Sustitucion del metodo OnModelCreating
        /// </summary>
        /// <param name="pModelBuilder">Model builder</param>
        protected override void OnModelCreating(DbModelBuilder pModelBuilder)
        {
            pModelBuilder.Configurations.Add(new CampaignMap());
            pModelBuilder.Configurations.Add(new ByteImageMap());
            pModelBuilder.Configurations.Add(new BannerMap());
            pModelBuilder.Configurations.Add(new RssItemMap());
            pModelBuilder.Configurations.Add(new RssBannerMap());


            base.OnModelCreating(pModelBuilder);
        }
    }
}
