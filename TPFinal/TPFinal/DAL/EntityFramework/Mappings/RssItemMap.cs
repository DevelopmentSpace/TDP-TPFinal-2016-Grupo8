using System;
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
    public class RssItemMap: EntityTypeConfiguration<RssItem>
    {
        public RssItemMap()
        {
            // Nombre de la tabla que tendrá la entidad, en este caso 'RssItem'.
            this.ToTable("RssItem");

            // Clave primaria de la entidad, formada por la clave del item y del banner asociado, autoincremental la del item
            this.HasKey(pRssItem => new { pRssItem.rssBannerId, pRssItem.id })
                .Property(pRssItem => pRssItem.id)
                .HasColumnName("RssItemId")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            // Se establece la columna obligatoria (NOT NULL) 'url'.
            this.Property(pRssItem => pRssItem.url)
                .IsRequired();

            // Se establece la columna obligatoria (NOT NULL) 'description'.
            this.Property(pRssItem => pRssItem.description)
                .IsRequired();

            // Se establece la columna obligatoria (NOT NULL) 'publishingDate'.
            this.Property(pRssItem => pRssItem.publishingDate);
        }
    }
}
