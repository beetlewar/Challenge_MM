using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineEngine
{
    public interface IOperation
    {
        event EventHandler<BalanceEventArgs> BalanceChanged;

        uint Balance { get; }

        void Deposit(uint nominal, uint count);

        void MoneyBack();

        void Buy(object drinkId);
    }
}
