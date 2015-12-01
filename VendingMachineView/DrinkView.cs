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
    /// Презентер для этой вьюхи делать не стал
    /// </summary>
    public partial class DrinkView : UserControl
    {
        public event EventHandler<DrinkIdEventArgs> BuyClicked;
        private DrinkViewItem _drink;

        public DrinkView()
        {
            InitializeComponent();
        }

        public void Setup(DrinkViewItem drink)
        {
            this._drink = drink;

            this._groupBoxName.Text = drink.DisplayName;
            this._buttonBuy.Text = drink.CostStr;

            this.UpdateView();

            this._drink.Source.CountChanged += _drink_CountChanged;
        }

        void _drink_CountChanged(object sender, EventArgs e)
        {
            this.UpdateView();
        }

        private void UpdateView()
        {
            this._textBoxCount.Text = this._drink.CountStr;
        }

        private void _buttonSize_Click(object sender, EventArgs e)
        {
            var h = this.BuyClicked;
            if( h != null )
            {
                h(this, new DrinkIdEventArgs(this._drink.Source.Id));
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(this._drink != null)
                {
                    this._drink.Source.CountChanged -= _drink_CountChanged;
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
