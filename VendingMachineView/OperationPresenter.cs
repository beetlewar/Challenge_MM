using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine;

namespace VendingMachineView
{
    public class OperationPresenter : IDisposable
    {
        public IOperationView View { get; private set; }
        public IOperation Operation { get; private set; }

        public OperationPresenter(
            IOperation operarion,
            IOperationView view)
        {
            if(view == null)
            {
                throw new ArgumentNullException("view");
            }
            if(operarion == null)
            {
                throw new ArgumentNullException("operation");
            }

            this.View = view;
            this.Operation = operarion;

            this.View.PileClicked += View_PileClicked;
        }

        void View_PileClicked(object sender, CoinsPileEventArgs e)
        {
            this.Operation.Deposit(e.Pile.Nominal, e.Pile.Count);
        }

        public void Dispose()
        {
            this.View.PileClicked -= View_PileClicked;
            this.Operation = null;
        }
    }
}
