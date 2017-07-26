using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Model
{
	/// <summary>
	/// Interfaz correspondiente al objeto observable del patron observer
	/// </summary>
    interface IObservable
    {
		/// <summary>
		/// Añade un listener
		/// </summary>
		/// <param name="pListener">Listener a agregar</param>
        void AddListener(IObserver pListener);

		/// <summary>
		/// Elimina un listener
		/// </summary>
		/// <param name="pListener">Listener a eliminar</param>
        void RemoveListener(IObserver pListener);

		/// <summary>
		/// Notifica a los listener registrados
		/// </summary>
        void NotifyListeners();
    }
}
