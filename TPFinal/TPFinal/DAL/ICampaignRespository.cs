using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL
{
    /// <summary>
    /// Interfaz de acceso a Campañas
    /// </summary>
    public interface ICampaignRespository : IRepository<Campaign>
    {
        /// <summary>
        /// Obtiene las campañas activas en una fecha y rango de hora específico
        /// </summary>
        /// <param name="pDate">Fecha a buscar</param>
        /// <param name="pTimeFrom">Inicio de intervalo de tiempo</param>
        /// <param name="pTimeTo">Fin de intervalo de tiempo</param>
        /// <returns>Lista de campañas activas en el horario y fecha dados</returns>
        IEnumerable<Campaign> GetActives(DateTime pDate, TimeSpan pTimeFrom, TimeSpan pTimeTo);

    }
}
