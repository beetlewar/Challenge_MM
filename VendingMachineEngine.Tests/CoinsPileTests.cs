using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace VendingMachineEngine.Tests
{
    [TestFixture]
    public class CoinsPileTests
    {
        [Test]
        public void Ctor_InvalidNominal_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new CoinsPile(0));
        }

        [Test]
        public void Ctor_ValidNominal_SetsNominal()
        {
            Assert.AreEqual(3, new CoinsPile(3).Nominal);
        }

        [Test]
        public void Add_ValidNumber_Adds()
        {
            var c = new CoinsPile(1);
            c.Add(3);
            Assert.AreEqual(3, c.Count);
        }

        [TestCase(5)]
        [TestCase(2)]
        public void Substruct_ValidNumber_Substructs(int val)
        {
            var c = new CoinsPile(1, 5);
            c.Substruct((uint)val);
            Assert.AreEqual(5 - val, c.Count);
        }

        [Test]
        public void Subsctruct_BigNumber_ThrowsEngineOperationException()
        {
            Assert.Throws<EngineOperationException>(() => new CoinsPile(1, 1).Substruct(2));
        }

        [Test]
        public void TakeCoins_BigBalance_SetsCoinsToZeroAndModifiesBalance()
        {
            uint bal = 100;

            var p = new CoinsPile(3, 32);
            var result = p.TakeCoins(ref bal);

            Assert.AreEqual(0, p.Count);
            Assert.AreEqual(3, result.Nominal);
            Assert.AreEqual(32, result.Count);
            Assert.AreEqual(4, bal);
        }

        [Test]
        public void TakeCoins_SmallBalance_SetsCoinsToValidCountAndBalanceToZero()
        {
            uint bal = 30;

            var p = new CoinsPile(2, 20);
            var result = p.TakeCoins(ref bal);

            Assert.AreEqual(5, p.Count);
            Assert.AreEqual(2, result.Nominal);
            Assert.AreEqual(15, result.Count);
            Assert.AreEqual(0, bal);
        }
    }
}
