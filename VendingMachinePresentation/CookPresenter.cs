using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine;
using VendingMachineView;

namespace VendingMachinePresentation
{
    public class CookPresenter : 
        IDisposable
    {
        public IOperation Operation { get; private set; }
        public ICookView View { get; private set; }
        public IMessagePresenter MessagePresenter { get; private set; }

        public CookPresenter(
            IOperation operation,
            ICookView view,
            IMessagePresenter messagePresenter)
        {
            if(operation == null)
            {
                throw new ArgumentNullException("operation");
            }
            if (view == null)
            {
                throw new ArgumentNullException("view");
            }

            this.Operation = operation;
            this.View = view;
            this.MessagePresenter = messagePresenter;

            this.View.BuyDrinkClicked += View_DrinkClicked;
        }

        void View_DrinkClicked(object sender, DrinkIdEventArgs e)
        {
            this.Operation.Buy(e.DrinkId);
            this.MessagePresenter.ShowMessage(string.Format("Вы купили {0}", e.DrinkId));
        }

        public void Dispose()
        {
            this.View.BuyDrinkClicked -= View_DrinkClicked;
        }
    }
}
