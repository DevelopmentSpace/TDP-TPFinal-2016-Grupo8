using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using TPFinal.Domain;

namespace TPFinal.Model
{
	
	/// <summary>
	/// Trabajo a ejecutar para cambiar de imagen
	/// </summary>
    [PersistJobDataAfterExecutionAttribute()]
    [DisallowConcurrentExecution()]
    class ChangeImageJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
        }
    }
}
