using Common.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;


namespace TPFinal.DAL.EntityFramework
{
    /// <summary>
    /// Implementacion de repositorio de campañas
    /// </summary>
    class CampaignRepository : EFRepository<Campaign, DigitalSignageDbContext>, ICampaignRespository
    {
		private static readonly ILog cLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// Contexto a utilizar
		/// </summary>
		DbContext iDbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pContext">Contexto a utilizar en el repositorio</param>
        public CampaignRepository(DigitalSignageDbContext pContext) : base(pContext)
        {
            this.iDbContext = pContext;
        }

        /// <summary>
        /// Obtiene las campañas activas en una fecha y rango de hora específico
        /// </summary>
        /// <param name="pDate">Fecha a buscar</param>
        /// <param name="pTimeFrom">Inicio de intervalo de tiempo</param>
        /// <param name="pTimeTo">Fin de intervalo de tiempo</param>
        /// <returns>Lista de campañas activas en el horario y fecha dados</returns>
        public IEnumerable<Campaign> GetActives(DateTime pDate, TimeSpan pTimeFrom, TimeSpan pTimeTo)
        {

            if (pDate == null)
                throw new ArgumentNullException("pDate");
            if (pTimeFrom == null)
                throw new ArgumentNullException("pTimeFrom");
            if (pTimeTo == null)
                throw new ArgumentNullException("pTimeTo");
            if (pTimeFrom.CompareTo(pTimeTo) > 0)
                throw new InvalidOperationException("pTimeFrom debe ser menor que pTimeTo");


            cLogger.Info("Obteniendo Campañas activas");

            IQueryable<Campaign> query = from campaign in this.iDbContext.Set<Campaign>()
                                         where
                                             //La fecha actual esta entre la fecha de inicio y fin de la campaña
                                             (campaign.initDate <= pDate && campaign.endDate >= pDate) 
                                             &&
                                             //La campaña empieza antes del fin del intervalo y termina despues del principio del intervalo
                                             (campaign.initTime <= pTimeTo && campaign.endTime >= pTimeFrom)
                        select campaign;

            return QueryableExtensions.Include(query, "imagesList");
        }
    }
}
