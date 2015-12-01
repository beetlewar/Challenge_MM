using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine;

namespace VendingMachineView
{
    public class CoinsPileEventArgs : EventArgs
    {
        public CoinsPile Pile { get; private set; }

        public CoinsPileEventArgs(CoinsPile pile)
        {
            this.Pile = pile;
        }
    }
}
