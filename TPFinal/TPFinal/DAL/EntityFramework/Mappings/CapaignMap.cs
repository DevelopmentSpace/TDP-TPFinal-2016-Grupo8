using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL.EntityFramework.Mappings
{
    class CampaignMap : EntityTypeConfiguration<Campaign>
    {

        public CampaignMap()
        {
            // Nombre de la tabla que tendrá la entidad, en este caso 'Campaign'.
            this.ToTable("Campaign");

            // Clave primaria de la entidad, indicando que la columna se llama 'CampaignId' y que es autoincremental.
            this.HasKey(pCampaign => pCampaign.id)
                .Property(pCampaign => pCampaign.id)
                .HasColumnName("CampaignId")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            // Se establece la columna obligatoria (NOT NULL) 'interval'.
            this.Property(pCampaign => pCampaign.interval)
                .IsRequired();

            // Se establece la columna obligatoria (NOT NULL) 'initDate'.
            this.Property(pCampaign => pCampaign.initDate)
                .IsRequired();

            // Se establece la columna obligatoria (NOT NULL) 'endDate'.
            this.Property(pCampaign => pCampaign.endDate)
                .IsRequired();

            // Se establece la columna obligatoria (NOT NULL) 'initTime'.
            this.Property(pCampaign => pCampaign.initTime)
                .IsRequired();

            // Se establece la columna obligatoria (NOT NULL) 'endTime'.
            this.Property(pCampaign => pCampaign.endTime)
                .IsRequired();

            // Se establece la relación de uno a cero o muchos entre Campaign y Images,
            // permitiendo solamente la navegación desde Campaign hacia Images, con eliminación en cascada.
            // El nombre de la columna de la FK se nombra 'CampaignId'.
            this.HasMany(pCampaign => pCampaign.imagesList)
                .WithRequired()
                .Map(pMapping => pMapping.MapKey("CampaignId"))
                .WillCascadeOnDelete();
        }
    }
}
