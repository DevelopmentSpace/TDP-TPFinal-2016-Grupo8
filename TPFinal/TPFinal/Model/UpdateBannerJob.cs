using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using TPFinal.DAL;
using TPFinal.Domain;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TPFinal.Model
{
	/// <summary>
	/// Trabajo a ejecutar para actualizar los banners
	/// </summary>
    [PersistJobDataAfterExecutionAttribute()]
    [DisallowConcurrentExecution()]
    class UpdateBannerJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            
        }
    }
}
