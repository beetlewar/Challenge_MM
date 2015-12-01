using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineEngine
{
    /// <summary>
    /// Напиток
    /// </summary>
    public class Drink : IDrink
    {
        /// <summary>
        /// Количество порций
        /// </summary>
        public uint Count { get; private set; }

        /// <summary>
        /// Стоимость напитка
        /// </summary>
        public uint Cost { get; private set; }

        /// <summary>
        /// Идентификатор напитка
        /// </summary>
        public object Id { get; private set; }

        public Drink(
            uint count,
            uint cost,
            object id)
        {
            this.Count = count;
            this.Cost = cost;
            this.Id = id;
        }

        public void Make()
        {
            if(this.Count == 0)
            {
                throw new EngineOperationException("Напиток закончился");
            }
            --this.Count;
        }
    }
}
