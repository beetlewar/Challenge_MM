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
    public interface IDrink
    {
        event EventHandler CountChanged;

        /// <summary>
        /// Возвращает количество оставшихся порций
        /// </summary>
        uint Count { get; }

        /// <summary>
        /// Стоимость напитка
        /// </summary>
        uint Cost { get; }

        /// <summary>
        /// Готовит напиток. В результате успешного приготовления уменьшает количество порций на 1.
        /// Если напиток приготовить не удается, генерит исключение EngineOperationException.
        /// </summary>
        void Make();

        /// <summary>
        /// Идентификатор напитка
        /// </summary>
        object Id { get; }
    }
}
