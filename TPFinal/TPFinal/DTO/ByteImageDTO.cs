using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TPFinal.DTO.Infrastructure;
using TPFinal.Domain;

namespace TPFinal.DTO
{
    public class ByteImageDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int id { get; set; }
        public Byte[] bytes { get; set; }
    }

    public class ByteImageMapper : MapperBase<ByteImage, ByteImageDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<ByteImage, ByteImageDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<ByteImage, ByteImageDTO>>)(p => new ByteImageDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    id = p.id,
                    bytes = p.bytes
                }));
            }
        }

        public override void MapToModel(ByteImageDTO dto, ByteImage model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.id = dto.id;
            model.bytes = dto.bytes;

        }
    }
}
