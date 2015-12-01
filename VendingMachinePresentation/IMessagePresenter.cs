using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachinePresentation
{
    public interface IMessagePresenter
    {
        void ShowError(string err);
        void ShowMessage(string msg);
    }
}
