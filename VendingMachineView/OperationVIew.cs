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
                var view = new CoinsPileButtonView();
                view.Setup(pile);
                view.PileClicked += this.FirePileClicked;
                this._panel.Controls.Add(view);
            }
        }

        #region IOperationView

        public event EventHandler<CoinsPileEventArgs> PileClicked;
        public event EventHandler MoneyBackClicked;

        private void FirePileClicked(object sender, CoinsPileEventArgs e)
        {
            var h = this.PileClicked;
            if( h != null )
            {
                h(this, e);
            }
        }

        private void _buttobMoneyBack_Click(object sender, EventArgs e)
        {
            var h = this.MoneyBackClicked;
            if( h != null )
            {
                h(this, EventArgs.Empty);
            }
        }

        public void SetBalance(uint balance)
        {
            this._balance.Text = balance.ToString();
        }

        #endregion
    }
}
