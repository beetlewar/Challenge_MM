using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineView
{
    public interface IMessagePresenter
    {
        /// <summary>
        /// Отображает сообщение
        /// </summary>
        void ShowMessage(string msg);
    }
}
