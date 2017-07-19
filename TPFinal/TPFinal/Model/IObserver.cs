using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Model
{
    public interface IObserver
    {
        void Update(String pDes);
    }
}
