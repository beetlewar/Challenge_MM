using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingMachineEngine;
using VendingMachinePresentation;

namespace VendingMachineApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // т.к. у нас однопоточное приложение, перехватываем только исключения потока приложения
            Application.ThreadException += (s, ea) =>
                {
                    if(ea.Exception is EngineOperationException)
                    {
                        MessageBoxPresenter.Instance.ShowError(ea.Exception.Message);
                    }
                    else
                    {
                        MessageBoxPresenter.Instance.ShowError("Возникла неизвестная ошибка");
                    }
                };

            Application.Run(new Main());
        }
    }
}
