using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.DTO;

namespace TPFinal.Model
{
    /// <summary>
    /// Interfaz del servicio de banner de textos
    /// </summary>
    interface ITextBannerService
    {
        /// <summary>
        /// Añade un banner de texto
        /// </summary>
        /// <param name="pTextBannerDTO">Banner de texto a agregar</param>
        void Create(TextBannerDTO pTextBannerDTO);

        /// <summary>
        /// Actualiza un banner de texto
        /// </summary>
        /// <param name="pTextBannerDTO">Banner de texto a actualizar</param>
        void Update(TextBannerDTO pTextBannerDTO);

        /// <summary>
        /// Elimina banner de texto
        /// </summary>
        /// <param name="pId">Id del banner de texto a eliminar</param>
        void Delete(int pId);

        /// <summary>
        /// Obtiene un banner de texto por su ID
        /// </summary>
        /// <param name="pId">Id del banner de texto</param>
        /// <returns>Banner de texto con el Id dado</returns>
        TextBannerDTO Get(int pId);

        /// <summary>
        /// Obtiene todos los texto de banner
        /// </summary>
        /// <returns>Enumerable con todos los banner de texto</returns>
        IEnumerable<TextBannerDTO> GetAll();
    }
}
