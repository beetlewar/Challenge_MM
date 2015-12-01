using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineEngine
{
    /// <summary>
    /// Виртуальный повар. Готовит напитки, оповощает о готовности
    /// </summary>
    public interface ICook
    {
        /// <summary>
        /// Готовит напиток с указанным Id
        /// </summary>
        /// <param name="id">Id приготавливаемого напитка</param>
        void Make(object id);

        /// <summary>
        /// Возвращает стоимость напитка
        /// </summary>
        /// <param name="id">Id напитка</param>
        uint GetCost(object id);
    }
}
