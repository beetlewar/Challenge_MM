using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineEngine
{
    /// <summary>
    /// Виртуальная стопка монет. Состоит из номинала и количества монет.
    /// </summary>
    public class CoinsPile
    {
        public event EventHandler CountChanged;

        private uint _count;

        /// <summary>
        /// Номинал монеты
        /// </summary>
        public uint Nominal { get; private set; }

        /// <summary>
        /// Количество монет в стопке
        /// </summary>
        public uint Count
        {
            get { return this._count; }
            internal set
            {
                if(this._count != value)
                {
                    this._count = value;
                    var h = this.CountChanged;
                    if(  h != null )
                    {
                        h(this, EventArgs.Empty);
                    }
                }
            }
        }

        public CoinsPile(uint nominal) :
            this(nominal, 0)
        {
        }

        public CoinsPile(uint nominal, uint count)
        {
            if (nominal == 0)
            {
                throw new ArgumentException("Номинал не может быть нулевым");
            }
            this.Nominal = nominal;
            this.Add(count);
        }

        /// <summary>
        /// Добавляет монету к стопке
        /// </summary>
        /// <param name="count">Количество добавляемых монет</param>
        public void Add(uint count)
        {
            this.Count += count;
        }

        /// <summary>
        /// Удаляет часть монет из стопки
        /// </summary>
        /// <param name="count">Количество удаляемых монет</param>
        public void Substruct(uint count)
        {
            if(count > this.Count)
            {
                throw new EngineOperationException("Недостаточно монет");
            }
            this.Count -= count;
        }

        /// <summary>
        /// Забирает часть денег из указанной суммы и модифицирует остаток
        /// </summary>
        /// <param name="balance">Остаток денег, который меняется в результате взятия денег</param>
        /// <returns>Возвращает забранные монеты</returns>
        public CoinsPile TakeCoins(ref uint balance)
        {
            var coinsToTake = Math.Min(this.Count, balance / this.Nominal);
            balance -= (coinsToTake * this.Nominal);
            this.Count -= coinsToTake;

            return new CoinsPile(this.Nominal, coinsToTake);
        }
    }
}
