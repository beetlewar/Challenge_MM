using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachineView
{
    public static class MessageBoxPresenter
    {
        public static void ShowError(string err)
        {
            MessageBox.Show(err, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
