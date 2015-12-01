using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineEngine
{
    /// <summary>
    /// Управляет переводом денег с одного кошелька на другой, выполняя операции по вносу денег, сдаче и приготовлению напитка
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Кошелек пользователя
        /// </summary>
        public IWallet UserWallet { get; private set; }

        /// <summary>
        /// Кошелек аппарата
        /// </summary>
        public IWallet MachineWallet { get; private set; }

        /// <summary>
        /// Ссылка на виртуальынй повар
        /// </summary>
        public ICook Cook { get; private set; }

        /// <summary>
        /// Остаток денег
        /// </summary>
        public uint Balance { get; internal set; }

        public Operation(IWallet userWallet, IWallet machineWallet, ICook cook)
        {
            if(userWallet == null)
            {
                throw new ArgumentNullException();
            }
            if (machineWallet == null)
            {
                throw new ArgumentNullException();
            }
            if(cook == null)
            {
                throw new ArgumentNullException();
            }

            this.UserWallet = userWallet;
            this.MachineWallet = machineWallet;
            this.Cook = cook;
        }

        /// <summary>
        /// Вносит указанную сумму денег.
        /// </summary>
        /// <param name="nominal">номинал вносимых денег</param>
        /// <param name="count">Количество вносимых монет</param>
        public void Deposit(uint nominal, uint count)
        {
            this.UserWallet.SubstructCoins(nominal, count);
            this.MachineWallet.AddCoins(nominal, count);
            this.Balance += (nominal * count);
        }

        /// <summary>
        /// Осуществляет возврат денег - возвращает набор стопок
        /// </summary>
        public void MoneyBack()
        {
            var piles = this.MachineWallet.GetBestCoins(this.Balance);
            foreach(var pile in piles)
            {
                this.UserWallet.AddCoins(pile.Nominal, pile.Count);
            }
            this.Balance = 0;
        }

        /// <summary>
        /// Осуществляет покупку напитка, при этом с баланса списываются деньги и начинает готовиться напиток.
        /// </summary>
        /// <param name="drinkId">Идентификатор приготавливаемого напитка</param>
        public void Buy(object drinkId)
        {
            var cost = this.Cook.GetCost(drinkId);
            if(cost > this.Balance)
            {
                throw new EngineOperationException("Недостаточно средств");
            }
            this.Cook.Make(drinkId);
            this.Balance -= cost;
        }
    }
}
