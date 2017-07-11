using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TPFinal.DAL.EntityFramework
{
    abstract class EFRepository<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        //Contexto a utilizar
        DbContext iDbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pContext">Contexto a utilizar</param>
        public EFRepository(TDbContext pContext)
        {
            if (pContext == null)
            {
                throw new ArgumentNullException(nameof(pContext));
            }

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
                throw new ArgumentNullException(nameof(pEntity));
            }

            this.iDbContext.Set<TEntity>().Add(pEntity);
        }

        /// <summary>
        /// Obtiene un elemento por su Id
        /// </summary>
        /// <param name="pId">Id del elemento</param>
        /// <returns>Elemento cuya Id coincida</returns>
        public TEntity Get(int pId)
        {
            return this.iDbContext.Set<TEntity>().Find(pId);
        }

        /// <summary>
        /// Obtiene todos los elementos en el repositorio
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public IEnumerable<TEntity> GetAll()
        {
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
                throw new ArgumentNullException(nameof(pEntity));
            }

            this.iDbContext.Set<TEntity>().Remove(pEntity);
        }
    }
}
