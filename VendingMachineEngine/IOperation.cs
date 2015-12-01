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
    public interface IOperation
    {
        event EventHandler<BalanceEventArgs> BalanceChanged;

        /// <summary>
        /// Возвращает остаток внесенных средств
        /// </summary>
        uint Balance { get; }

        /// <summary>
        /// Вносит монетки определенного номинала
        /// </summary>
        /// <param name="nominal">Номинал вносимых монет</param>
        /// <param name="count">Количество вносимых монет</param>
        void Deposit(uint nominal, uint count);

        /// <summary>
        /// Возвращает сдачу
        /// </summary>
        void MoneyBack();

        /// <summary>
        /// Покупает напиток, в результате чего остаток уменьшается на стоимость напитка.
        /// Если денег не достаточно, генерит EngineOperationException.
        /// </summary>
        /// <param name="drinkId">Идентификатор покупаемого напитка</param>
        void Buy(object drinkId);
    }
}
