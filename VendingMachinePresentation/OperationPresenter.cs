using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine;
using VendingMachineView;

namespace VendingMachinePresentation
{
    public class OperationPresenter : 
        IDisposable
    {
        public IOperationView View { get; private set; }
        public IOperation Operation { get; private set; }

        public OperationPresenter(
            IOperation operarion,
            IOperationView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException("view");
            }
            if (operarion == null)
            {
                throw new ArgumentNullException("operation");
            }

            this.View = view;
            this.Operation = operarion;

            this.View.PileClicked += View_PileClicked;
            this.View.MoneyBackClicked += View_MoneyBackClicked;
            this.Operation.BalanceChanged += Operation_BalanceChanged;
        }

        void View_MoneyBackClicked(object sender, EventArgs e)
        {
            this.Operation.MoneyBack();
        }

        void Operation_BalanceChanged(object sender, BalanceEventArgs e)
        {
            this.View.SetBalance(e.Balance);
        }

        void View_PileClicked(object sender, CoinsPileEventArgs e)
        {
            this.Operation.Deposit(e.Pile.Nominal, 1);
        }

        public void Dispose()
        {
            this.View.PileClicked -= View_PileClicked;
            this.View.MoneyBackClicked -= View_MoneyBackClicked;
            this.Operation.BalanceChanged -= Operation_BalanceChanged;
            this.Operation = null;
        }
    }
}
