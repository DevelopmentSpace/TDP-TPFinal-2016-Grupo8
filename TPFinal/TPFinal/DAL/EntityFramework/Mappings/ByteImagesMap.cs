using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL.EntityFramework.Mappings
{
    public class ByteImageMap : EntityTypeConfiguration<ByteImage>
    {
        public ByteImageMap()
        {
            // Nombre de la tabla que tendrá la entidad, en este caso 'AccountMovement'.
            this.ToTable("ByteImage");

            // Clave primaria de la entidad, indicando que la columna se llama 'AccountMovementId' y que es autoincremental.
            this.HasKey(byteImage => byteImage.id)
                .Property(byteImage => byteImage.id)
                .HasColumnName("byteImageId")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            // Se establece la columna obligatoria (NOT NULL) 'bytes'.
            this.Property(byteImage => byteImage.bytes)
                .IsRequired();

        }
    }
}
