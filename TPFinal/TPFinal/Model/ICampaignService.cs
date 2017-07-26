using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.DTO;

namespace TPFinal.Model
{
    interface ICampaignService : IObservable
    {
		/// <summary>
		/// Agrega una campaña
		/// </summary>
		/// <param name="pCampaignDTO">Campaña a agregar</param>
        void Create(CampaignDTO pCampaignDTO);

		/// <summary>
		/// Elimina una campaña
		/// </summary>
		/// <param name="pCampaignDTO">Campaña a eliminar</param>
        void Update(CampaignDTO pCampaignDTO);

		/// <summary>
		/// Elimina una campaña
		/// </summary>
		/// <param name="pId">Id de la campaña a eliminar</param>
        void Delete(int pId);

		/// <summary>
		/// Obtiene una campaña
		/// </summary>
		/// <param name="pId">Id de la campaña</param>
		/// <returns>Campaña con Id dado</returns>
        CampaignDTO GetCampaign(int pId);

		/// <summary>
		/// Obtiene todas las campañas
		/// </summary>
		/// <returns>Enumerable con campañas</returns>
        IEnumerable<CampaignDTO> GetAll();

		/// <summary>
		/// Obtiene la imagen actual a mostrar
		/// </summary>
		/// <returns>Imagen a mostrar</returns>
        ByteImageDTO GetActualImage();

		/// <summary>
		/// Actualiza las campañas con la base de datos.
		/// </summary>
        void ForceUpdate();
    }
}
