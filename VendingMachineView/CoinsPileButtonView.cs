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
    /// <summary>
    /// Представляет кнопку монеты, имитирующую внесение пользователем монеты
    /// </summary>
    public partial class CoinsPileButtonView : UserControl
    {
        public event EventHandler<CoinsPileEventArgs> PileClicked;

        private CoinsPileViewItem _pile;

        public CoinsPileButtonView()
        {
            InitializeComponent();
        }

        public void Setup(CoinsPileViewItem pile)
        {
            this._pile = pile;
            this._button.Text = string.Format("Внести\n{0}", this._pile.NominalStr);
        }

        private void _button_Click(object sender, EventArgs e)
        {
            var h = this.PileClicked;
            if( h != null )
            {
                h(this, new CoinsPileEventArgs(this._pile.Source));
            }
        }
    }
}
