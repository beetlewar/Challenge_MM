using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace VendingMachineEngine.Tests
{
    [TestFixture]
    public class DrinkTests
    {
        [Test]
        public void Make_Empty_ThrowsEngineOperationException()
        {
            Assert.Throws<EngineOperationException>(() => new Drink(0, 1, 1).Make());
        }

        [Test]
        public void Make_Full_DecrementsCount()
        {
            var d = new Drink(11, 1, 1);
            d.Make();

            Assert.AreEqual(10, d.Count);
        }
    }
}
