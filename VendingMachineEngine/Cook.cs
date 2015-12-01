using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineEngine
{
    /// <summary>
    /// Шеф-повар, который работает с напитками
    /// </summary>
    public class Cook : ICook
    {
        private readonly Dictionary<object, IDrink> _drinks;

        public IDrink[] Drinks
        {
            get { return this._drinks.Values.ToArray(); }
        }

        public Cook(IEnumerable<IDrink> drinks)
        {
            this._drinks = drinks.ToDictionary(d => d.Id);
        }

        public uint GetCost(object id)
        {
            return this._drinks[id].Cost;
        }

        public void Make(object id)
        {
            this._drinks[id].Make();
        }
    }
}
