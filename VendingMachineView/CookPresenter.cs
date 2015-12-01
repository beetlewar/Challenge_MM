﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine;

namespace VendingMachineView
{
    public class CookPresenter : 
        APresenter,
        IDisposable
    {
        public IOperation Operation { get; private set; }
        public ICookView View { get; private set; }

        public CookPresenter(
            IOperation operation,
            ICookView view,
            IMessagePresenter msgPresenter) :
            base(msgPresenter)
        {
            if(operation == null)
            {
                throw new ArgumentNullException("operation");
            }
            if (view == null)
            {
                throw new ArgumentNullException("view");
            }

            this.Operation = operation;
            this.View = view;

            this.View.BuyDrinkClicked += View_DrinkClicked;
        }

        void View_DrinkClicked(object sender, DrinkIdEventArgs e)
        {
            base.DoSafeAction(() =>
                {
                    this.Operation.Buy(e.DrinkId);
                    base.ShowMessage(string.Format("Вы купили {0}", e.DrinkId));
                });
        }

        public void Dispose()
        {
            this.View.BuyDrinkClicked -= View_DrinkClicked;
        }
    }
}