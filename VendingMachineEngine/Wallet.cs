using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineEngine
{
    /// <summary>
    /// Виртуальный кошелек, состоящий из стопок монет.
    /// </summary>
    public class Wallet : IWallet
    {
        private readonly Dictionary<uint, CoinsPile> _piles;

        /// <summary>
        /// сортированные в порядке убыания номинала стопки
        /// </summary>
        private readonly CoinsPile[] _sortedPiles;

        internal CoinsPile this[uint nominal]
        {
            get { return this._piles[nominal]; }
        }

        /// <summary>
        /// Возвращает стопки
        /// </summary>
        public CoinsPile[] Piles
        {
            get { return this._piles.Values.ToArray(); }
        }

        /// <summary>
        /// Создает кошелек с коллекцией стопок заданного интервала
        /// </summary>
        /// <param name="nominals">Номиналы каждой стопки</param>
        public Wallet(IEnumerable<uint> nominals) :
            this(nominals.Select(n=>new CoinsPile(n)))
        {
        }

        /// <summary>
        /// Создает кошелек с коллекцией заданных
        /// </summary>
        public Wallet(IEnumerable<CoinsPile> piles)
        {
            this._sortedPiles = piles.ToArray();
            this._piles = this._sortedPiles.ToDictionary(p => p.Nominal);
            Array.Sort(this._sortedPiles, (x, y) => -x.Nominal.CompareTo(y.Nominal));
        }

        /// <summary>
        /// Добавляет монеты с указанным номиналом в соответствующую стопку.
        /// Если стопка с таким номиналом не найдена, генерит EngineOperationException.
        /// </summary>
        /// <param name="nominal">номинал</param>
        /// <param name="count">Количество добавляемых монет данного номинала</param>
        public void AddCoins(uint nominal, uint count)
        {
            this._piles[nominal].Add(count);
        }

        /// <summary>
        /// Удаляет монеты с указанным номиналом.
        /// </summary>
        /// <param name="nominal">Номинал удаляемых монет</param>
        /// <param name="count">Количество удаляемых монет</param>
        public void SubstructCoins(uint nominal, uint count)
        {
            this._piles[nominal].Substruct(count);
        }

        /// <summary>
        /// Возвращает количество монет в стопке с определенным номиналом.
        /// </summary>
        /// <param name="nominal">Номинал запрашиваемой монеты</param>
        public uint GetCoins(uint nominal)
        {
            return this._piles[nominal].Count;
        }

        /// <summary>
        /// Возвращает деньги с наибольшим номиналом
        /// </summary>
        /// <param name="value">Объем запрашиваемых денег</param>
        public CoinsPile[] GetBestCoins(uint value)
        {
            var result = new List<CoinsPile>();
            foreach(var pile in this._sortedPiles)
            {
                result.Add(pile.TakeCoins(ref value));
            }

            Debug.Assert(value == 0);

            return result.ToArray();
        }
    }
}
