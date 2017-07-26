using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using log4net;

namespace TPFinal.DAL.EntityFramework
{
    /// <summary>
    /// Representa un repositorio generico en entity framework
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TDbContext"></typeparam>
    abstract class EFRepository<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
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
        public EFRepository(TDbContext pContext)
        {
            if (pContext == null)
            {
                cLogger.Error("Crear repositorio con contexto nulo");
                throw new ArgumentNullException(nameof(pContext));
            }

            cLogger.Info("Repositorio creado");
            this.iDbContext = pContext;
        }


        /// <summary>
        /// Agrega un elemento al repositorio
        /// </summary>
        /// <param name="pEntity">Elemento a agregar</param>
        public void Add(TEntity pEntity)
        {
            if (pEntity == null)
            {
                cLogger.Error("Intento agregar entidad nula");
                throw new ArgumentNullException(nameof(pEntity));
            }

            this.iDbContext.Set<TEntity>().Add(pEntity);
            cLogger.Info("Entidad Agregada");
        }

        /// <summary>
        /// Obtiene un elemento por su Id
        /// </summary>
        /// <param name="pId">Id del elemento</param>
        /// <returns>Elemento cuya Id coincida</returns>
        public TEntity Get(int pId)
        {
            cLogger.Info("Buscando entidad por id");
            try
            {
                return this.iDbContext.Set<TEntity>().Find(pId);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException();
            }

        }

        /// <summary>
        /// Obtiene todos los elementos en el repositorio
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public IEnumerable<TEntity> GetAll()
        {
            cLogger.Info("Obteniendo todas las entidades");
            return this.iDbContext.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Elimina un elemento del repositorio
        /// </summary>
        /// <param name="pEntity">Elemento a eliminar</param>
        public void Remove(TEntity pEntity)
        {
            if (pEntity == null)
            {
                cLogger.Error("Intento eliminar entidad nula");
                throw new ArgumentNullException(nameof(pEntity));
            }

            cLogger.Info("Eliminando entidad");
            this.iDbContext.Set<TEntity>().Remove(pEntity);
        }
    }
}
