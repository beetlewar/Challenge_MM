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
        public event EventHandler CountChanged;

        private uint _count;

        /// <summary>
        /// Количество порций
        /// </summary>
        public uint Count
        {
            get { return this._count; }
            private set
            {
                if (this._count != value)
                {
                    this._count = value;
                    var h = this.CountChanged;
                    if (h != null)
                    {
                        h(this, EventArgs.Empty);
                    }
                }
            }
        }

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
            if (this.Count == 0)
            {
                throw new EngineOperationException("Напиток закончился");
            }
            --this.Count;
        }
    }
}
