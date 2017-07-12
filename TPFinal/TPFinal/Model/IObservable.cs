using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Model
{
    interface IObservable
    {
        void AddListener(IObserver pListener);
        void RemoveListener(IObserver pListener);
        void NotifyListeners();
    }
}
