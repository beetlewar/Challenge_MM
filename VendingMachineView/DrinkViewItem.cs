using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine;

namespace VendingMachineView
{
    public class DrinkViewItem
    {
        public IDrink Source { get; private set; }

        public string DisplayName
        {
            get { return this.Source.Id.ToString(); }
        }

        public string CountStr
        {
            get { return string.Format("{0} порций", this.Source.Count.ToString()); }
        }

        public string CostStr
        {
            get { return string.Format("{0} руб", this.Source.Cost); }
        }

        public DrinkViewItem(IDrink source)
        {
            this.Source = source;
        }
    }
}
