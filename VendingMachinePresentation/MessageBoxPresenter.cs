using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachinePresentation
{
    public class MessageBoxPresenter : 
        IMessagePresenter
    {
        private static IMessagePresenter _presenter;

        public static IMessagePresenter Instance
        {
            get
            { 
                if(_presenter == null)
                {
                    _presenter = new MessageBoxPresenter();
                }
                return _presenter; 
            }
        }

        private MessageBoxPresenter() { }

        public void ShowError(string err)
        {
            MessageBox.Show(err, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
