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
    public partial class CoinsPileView : UserControl
    {
        public event EventHandler<CoinsPileEventArgs> PileClicked;

        public CoinsPileView()
        {
            InitializeComponent();
        }

        public void Setup(CoinsPile pile)
        {
            this._button.Tag = pile;
            this._button.Text = pile.Nominal.ToString();
        }

        private void _button_Click(object sender, EventArgs e)
        {
            var h = this.PileClicked;
            if( h != null )
            {
                h(this, new CoinsPileEventArgs((CoinsPile)this._button.Tag));
            }
        }
    }
}
