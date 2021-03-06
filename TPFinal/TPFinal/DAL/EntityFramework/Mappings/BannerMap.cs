﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL.EntityFramework.Mappings
{
    /// <summary>
    /// Representa una Mapping entre el objeto y las tablas de entity framework
    /// </summary>
    public class BannerMap:EntityTypeConfiguration<Banner>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BannerMap()
        {
            // Nombre de la tabla que tendrá la entidad, en este caso 'Banner'.
            this.ToTable("Banner");

            // Clave primaria de la entidad, indicando que la columna se llama 'AccountMovementId' y que es autoincremental.
            this.HasKey(pBanner => pBanner.id)
                .Property(pBanner => pBanner.id)
                .HasColumnName("BannerId")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            // Se establece la columna obligatoria (NOT NULL) 'name'.
            this.Property(pBanner => pBanner.name)
                .IsRequired();

            // Se establece la columna obligatoria (NOT NULL) 'initDate'.
            this.Property(pBanner => pBanner.initDate)
                .IsRequired();

            // Se establece la columna obligatoria (NOT NULL) 'endDate'.
            this.Property(pBanner => pBanner.endDate)
                .IsRequired();

            // Se establece la columna obligatoria (NOT NULL) 'initTime'.
            this.Property(pBanner => pBanner.initTime)
                .IsRequired();

            // Se establece la columna obligatoria (NOT NULL) 'endTime'.
            this.Property(pBanner => pBanner.endTime)
                .IsRequired();

            //para la herencia se define un atributo tipo segun el tipo de subclase
            Map<TextBanner>(x => x.Requires("Type")
                                        .HasValue("T")
                                        .HasColumnType("char")
                                        .HasMaxLength(1));

            Map<RssBanner>(x => x.Requires("Type")
                                          .HasValue("R")
                            );

        }
    }
}
