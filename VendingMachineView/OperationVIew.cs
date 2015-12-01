using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingMachineEngine;

namespace VendingMachineView
{
    public partial class OperationVIew : 
        UserControl, 
        IOperationView
    {
        public OperationVIew()
        {
            InitializeComponent();
        }

        public void Setup(IEnumerable<CoinsPile> userPiles)
        {
            foreach(var pile in userPiles)
            {
                var view = new CoinsPileView();
                view.Setup(pile);
                view.PileClicked += this.FirePileClicked;
                this._panel.Controls.Add(view);
            }
        }

        #region IOperationView

        public event EventHandler<CoinsPileEventArgs> PileClicked;

        private void FirePileClicked(object sender, CoinsPileEventArgs e)
        {
            var h = this.PileClicked;
            if( h != null )
            {
                h(this, e);
            }
        }

#warning реализовать
        public void SetBalance(uint balance)
        {
            this._balance.Value = balance;
        }

        #endregion
    }
}
