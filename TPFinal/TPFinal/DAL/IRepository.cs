using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.DAL
{
    interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Agrega un elemento al repositorio
        /// </summary>
        /// <param name="pEntity">Elemento a agregar</param>
        void Add(TEntity pEntity);

        /// <summary>
        /// Elimina un elemento del repositorio
        /// </summary>
        /// <param name="pEntity">Elemento a eliminar</param>
        void Remove(TEntity pEntity);

        /// <summary>
        /// Obtiene un elemento por su Id
        /// </summary>
        /// <param name="pId">Id del elemento</param>
        /// <returns>Elemento cuya Id coincida</returns>
        TEntity Get(int pId);

        /// <summary>
        /// Obtiene todos los elementos en el repositorio
        /// </summary>
        /// <returns>Lista de elementos</returns>
        IEnumerable<TEntity> GetAll();
    }
}
