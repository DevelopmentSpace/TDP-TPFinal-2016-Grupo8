using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TPFinal
{
    static class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log.Info("Iniciando aplicacion");
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Application());
            log.Info("Finalizando aplicacion");

            Environment.Exit(Environment.ExitCode);
        }
    }
}
