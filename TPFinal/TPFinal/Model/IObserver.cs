using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Model
{
	/// <summary>
	/// IObserver perteniciente al patron listener
	/// </summary>
    public interface IObserver
    {
		/// <summary>
		/// Metodo ejectuado por el observable para avisar de cambios
		/// </summary>
		/// <param name="pDes">Descripcion del cambio</param>
        void Update(String pDes);
    }
}
