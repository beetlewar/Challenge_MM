using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineView
{
    public class DrinkIdEventArgs : EventArgs
    {
        public object DrinkId { get; private set; }

        public DrinkIdEventArgs(object drinkId)
        {
            this.DrinkId = drinkId;
        }
    }
}
