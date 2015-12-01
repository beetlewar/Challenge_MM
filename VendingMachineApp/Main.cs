using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingMachineEngine;
using VendingMachinePresentation;
using VendingMachineView;

namespace VendingMachineApp
{
    public partial class Main : Form
    {
        private readonly List<IDisposable> _objectsToDispose = new List<IDisposable>();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // инициализируем движок
            var userCoinPiles = new[]
            {
                new CoinsPile(1, 10),
                new CoinsPile(2, 30),
                new CoinsPile(5, 20),
                new CoinsPile(10, 15),
            };

            var machineCoinPiles = new[]
            {
                new CoinsPile(1, 100),
                new CoinsPile(2, 300),
                new CoinsPile(5, 200),
                new CoinsPile(10, 100),
            };

            var drinks = new[]
            {
                new Drink(10, 13, "Чай"),
                new Drink(20, 18, "Кофе"),
                new Drink(20, 21, "Кофе с молоком"),
                new Drink(15, 35, "Сок"),
            };

            var cook = new Cook(drinks);

            var operation = new Operation(new Wallet(userCoinPiles), new Wallet(machineCoinPiles), cook);

            // инициализируем вьюхи
            this._operationView.Setup(userCoinPiles);
            this._userWalletView.Setup(userCoinPiles);
            this._machineWalletView.Setup(machineCoinPiles);
            this._cookView.Setup(cook);

            // инициализируем презентеры
            this._objectsToDispose.Add(new OperationPresenter(operation, this._operationView));
            this._objectsToDispose.Add(new CookPresenter(operation, this._cookView, MessageBoxPresenter.Instance));
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                foreach(var o in this._objectsToDispose)
                {
                    o.Dispose();
                }
                this._objectsToDispose.Clear();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Main_Resize(object sender, EventArgs e)
        {

        }
    }
}
