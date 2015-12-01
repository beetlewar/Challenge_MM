using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine;

namespace VendingMachineView
{
    public class OperationPresenter : 
        APresenter,
        IDisposable
    {
        public IOperationView View { get; private set; }
        public IOperation Operation { get; private set; }

        public OperationPresenter(
            IOperation operarion,
            IOperationView view,
            IMessagePresenter msgPresenter) :
            base(msgPresenter)
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
            this.Operation.BalanceChanged += Operation_BalanceChanged;
        }

        void Operation_BalanceChanged(object sender, BalanceEventArgs e)
        {
            base.DoSafeAction(() => this.View.SetBalance(e.Balance));
        }

        void View_PileClicked(object sender, CoinsPileEventArgs e)
        {
            base.DoSafeAction(() => this.Operation.Deposit(e.Pile.Nominal, 1));
        }

        public void Dispose()
        {
            this.View.PileClicked -= View_PileClicked;
            this.Operation.BalanceChanged -= Operation_BalanceChanged;
            this.Operation = null;
        }
    }
}
