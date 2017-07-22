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

            // Clave primaria de la entidad, indicando que la columna se llama 'RssItemId' y que es autoincremental.
            this.HasKey(pRssItem => pRssItem.id)
                .Property(pRssItem => pRssItem.id)
                .HasColumnName("RssItemId")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            // Se establece la columna obligatoria (NOT NULL) 'url'.
            this.Property(pRssItem => pRssItem.url)
                .IsRequired();

            // Se establece la columna obligatoria (NOT NULL) 'description', con una longitud máxima de 50 caracteres [varchar(50)].
            this.Property(pRssItem => pRssItem.description)
                .IsRequired()
                .HasMaxLength(100);

            // Se establece la columna obligatoria (NOT NULL) 'publishingDate'.
            this.Property(pRssItem => pRssItem.publishingDate);
        }
    }
}
