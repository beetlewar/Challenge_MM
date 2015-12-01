using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingMachineEngine;

namespace VendingMachineView
{
    public abstract class APresenter
    {
        private readonly IMessagePresenter _msgPresenter;

        protected APresenter() : this(new MessageBoxPresenter()) 
        { 
        }

        protected APresenter(IMessagePresenter presenter)
        {
            if(presenter == null)
            {
                throw new ArgumentNullException("presenter");
            }
            this._msgPresenter = presenter;
        }

        /// <summary>
        /// Выполняет callback в безопасном режиме - в случае возникновения ошибки обрабатывает ее.
        /// </summary>
        /// <param name="callback"></param>
        protected void DoSafeAction(Action callback)
        {
            try
            {
                callback();
            }
            catch (EngineOperationException ex)
            {
                this._msgPresenter.ShowMessage(ex.Message);
            }
            catch (Exception)
            {
                this._msgPresenter.ShowMessage("Возникла неизвестная ошибка");
            }
        }

        protected void ShowMessage(string msg)
        {
            this._msgPresenter.ShowMessage(msg);
        }
    }
}
