using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineEngine
{
    public interface IWallet
    {
        void AddCoins(uint nominal, uint count);
        void SubstructCoins(uint nominal, uint count);

        /// <summary>
        /// Возвращает деньги наиболее удобным для кошелька способом
        /// </summary>
        /// <param name="value">Объем запрашиваемых денег</param>
        CoinsPile[] GetBestCoins(uint value);
    }
}
