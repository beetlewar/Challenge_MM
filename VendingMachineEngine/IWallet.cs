using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineEngine
{
    public interface IWallet
    {
        /// <summary>
        /// Возвращает стопки монет
        /// </summary>
        CoinsPile[] Piles { get; }

        /// <summary>
        /// Добавляет монеты в определенную стопку
        /// </summary>
        /// <param name="nominal">Номинал добавляемых монет</param>
        /// <param name="count">Количество добавляемых монет</param>
        void AddCoins(uint nominal, uint count);

        /// <summary>
        /// Забирает монеты из определенной стопки
        /// </summary>
        /// <param name="nominal">Номинал забираемых монет</param>
        /// <param name="count">Количество забираемых монет</param>
        void SubstructCoins(uint nominal, uint count);

        /// <summary>
        /// Возвращает деньги наиболее удобным для кошелька способом
        /// </summary>
        /// <param name="value">Объем запрашиваемых денег</param>
        CoinsPile[] GetBestCoins(uint value);
    }
}
