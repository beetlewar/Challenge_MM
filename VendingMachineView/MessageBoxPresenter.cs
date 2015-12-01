using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachineView
{
    public class MessageBoxPresenter :
        IMessagePresenter
    {
        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
