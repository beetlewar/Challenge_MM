using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine;

namespace VendingMachineView
{
    public class CoinsPileViewItem
    {
        public CoinsPile Source { get; private set; }

        public string NominalStr
        {
            get { return string.Format("{0} руб", this.Source.Nominal); }
        }

        public string CountStr
        {
            get { return string.Format("{0} шт", this.Source.Count); }
        }

        public CoinsPileViewItem(CoinsPile source)
        {
            this.Source = source;
        }
    }
}
