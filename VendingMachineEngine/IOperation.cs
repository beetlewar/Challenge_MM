using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineEngine
{
    public interface IOperation
    {
        void Deposit(uint nominal, uint count);
    }
}
