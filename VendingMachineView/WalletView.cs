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
    public partial class WalletView : UserControl
    {
        public WalletView()
        {
            InitializeComponent();
        }

        public void Setup(IEnumerable<CoinsPile> piles)
        {
            foreach(var pile in piles)
            {
                var view = new CoinsPileInfoView();
                view.Setup(pile);
                this._panel.Controls.Add(view);
            }
        }
    }
}
