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
    public partial class CookView : 
        UserControl, 
        ICookView
    {
        public event EventHandler<DrinkIdEventArgs> BuyDrinkClicked;

        public CookView()
        {
            InitializeComponent();
        }

        public void Setup(ICook cook)
        {
            foreach(var drink in cook.Drinks)
            {
                var drinkView = new DrinkView();
                this._panel.Controls.Add(drinkView);
                drinkView.Setup(new DrinkViewItem(drink));

                drinkView.BuyClicked += drinkView_BuyClicked;
            }
        }

        void drinkView_BuyClicked(object sender, DrinkIdEventArgs e)
        {
            var h = this.BuyDrinkClicked;
            if( h != null)
            {
                h(this, e);
            }
        }
    }
}
