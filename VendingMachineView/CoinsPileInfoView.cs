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
    /// Я не стал делать presenter для этой вьюхи, хотя надо бы
    /// </summary>
    public partial class CoinsPileInfoView : UserControl
    {
        private CoinsPileViewItem _pile;

        public CoinsPileInfoView()
        {
            InitializeComponent();
        }

        public void Setup(CoinsPileViewItem pile)
        {
            this._pile = pile;
            this._nominal.Text = this._pile.NominalStr;
            this.UpdateView();

            this._pile.Source.CountChanged += _pile_CountChanged;
        }

        void _pile_CountChanged(object sender, EventArgs e)
        {
            this.UpdateView();
        }

        private void UpdateView()
        {
            this._count.Text = this._pile.CountStr;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(this._pile != null)
                {
                    this._pile.Source.CountChanged -= _pile_CountChanged;
                    this._pile = null;
                }
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
