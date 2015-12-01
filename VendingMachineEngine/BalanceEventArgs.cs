using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineEngine
{
    public class BalanceEventArgs : EventArgs
    {
        public uint Balance { get; private set; }

        public BalanceEventArgs(uint balance)
        {
            this.Balance = balance;
        }
    }
}
