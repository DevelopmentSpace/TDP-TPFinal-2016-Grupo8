using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL.EntityFramework
{
    /// <summary>
    /// Implementacion de repositorio de banner de Texto
    /// </summary>
    class TextBannerRepository : EFRepository<TextBanner, DigitalSignageDbContext>, ITextBannerRepository
    {
		private static readonly ILog cLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// Contexto a utilizar
		/// </summary>
		DbContext iDbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pContext">Contexto a utilizar</param>
        public TextBannerRepository(DigitalSignageDbContext pContext) : base(pContext)
        {
            this.iDbContext = pContext;
        }

        /// <summary>
        /// Obtiene los banners de texto activos en una fecha y rango de hora específico
        /// </summary>
        /// <param name="pDate">Fecha a buscar</param>
        /// <param name="pTimeFrom">Inicio de intervalo de tiempo</param>
        /// <param name="pTimeTo">Fin de intervalo de tiempo</param>
        /// <returns>Lista de banners de texto activos en el horario y fecha dados</returns>
        public IEnumerable<TextBanner> GetActives(DateTime pDate, TimeSpan pTimeFrom, TimeSpan pTimeTo)
        {
            if (pDate == null)
                throw new ArgumentNullException("pDate");
            if (pTimeFrom == null)
                throw new ArgumentNullException("pTimeFrom");
            if (pTimeTo == null)
                throw new ArgumentNullException("pTimeTo");
            if (pTimeFrom.CompareTo(pTimeTo) > -1)
                throw new InvalidOperationException("pTimeFrom debe ser menor que pTimeTo");

            cLogger.Info("Obteniendo Banner de texto activos");

            IQueryable<TextBanner> query = from textBanner in this.iDbContext.Set<TextBanner>()
                                          where
                                              //La fecha actual esta entre la fecha de inicio y fin del banner
                                              (textBanner.initDate <= pDate && textBanner.endDate >= pDate)
                                              &&
                                              //El banner empieza antes del fin del intervalo y termina despues del principio del intervalo
                                              (textBanner.initTime <= pTimeTo && textBanner.endTime >= pTimeFrom)
                                          select textBanner;

            return query;
        }
    }
}
