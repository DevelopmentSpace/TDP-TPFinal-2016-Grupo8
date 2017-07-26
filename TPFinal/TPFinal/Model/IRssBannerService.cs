using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.DTO;

namespace TPFinal.Model
{
	/// <summary>
	/// Interfaz para administrar Banners RSS
	/// </summary>
    interface IRssBannerService
    {
		/// <summary>
		/// Agrega un banner
		/// </summary>
		/// <param name="pRssBannerDTO">Banner a agregar</param>
        void Create(RssBannerDTO pRssBannerDTO);

		/// <summary>
		/// Actualiza un banner
		/// </summary>
		/// <param name="pRssBannerDTO">Banner a actualizar</param>
        void Update(RssBannerDTO pRssBannerDTO);

		/// <summary>
		/// Eliminar un banner
		/// </summary>
		/// <param name="pId">Banner a eliminar</param>
        void Delete(int pId);

		/// <summary>
		/// Obtiene un baner
		/// </summary>
		/// <param name="pId">Id del banner a obtener</param>
		/// <returns>Banner con Id dado</returns>
        RssBannerDTO Get(int pId);

		/// <summary>
		/// Obtiene todos los banners
		/// </summary>
		/// <returns>Enumerable con banners</returns>
        IEnumerable<RssBannerDTO> GetAll();
    }
}
