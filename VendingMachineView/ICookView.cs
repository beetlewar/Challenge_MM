using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineView
{
    public interface ICookView
    {
        event EventHandler<DrinkIdEventArgs> BuyDrinkClicked;
    }
}
