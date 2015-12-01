using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace VendingMachineEngine.Tests
{
    [TestFixture]
    public class WalletTests
    {
        [Test]
        public void Ctor_ValidPiles_CreatesAppropriatePiles()
        {
            var piles = new Wallet(new uint[] { 1, 2, 10 }).Piles;

            Assert.AreEqual(3, piles.Length);
            Assert.NotNull(piles.SingleOrDefault(p => p.Nominal == 1));
            Assert.NotNull(piles.SingleOrDefault(p => p.Nominal == 2));
            Assert.NotNull(piles.SingleOrDefault(p => p.Nominal == 10));
        }

        [Test]
        public void AddCoins_ValidNominal_AddsToPile()
        {
            var w = new Wallet(new uint[] { 1, 3 });
            w.AddCoins(3, 10);
            w.AddCoins(3, 12);
            w.AddCoins(1, 1);

            Assert.AreEqual(22, w[3].Count);
            Assert.AreEqual(1, w[1].Count);
        }

        [Test]
        public void SubstructCoins_ValidNominal_SubstructsFromPile()
        {
            var w = new Wallet(new uint[] { 1 });
            w[1].Count = 4;
            w.SubstructCoins(1, 2);

            Assert.AreEqual(2, w[1].Count);
        }

        [Test]
        public void GetCoins_AddFewCoins_ReturnsExpectedCount()
        {
            var w = new Wallet(new uint[] { 1 });
            w[1].Count = 2;
            Assert.AreEqual(2, w.GetCoins(1));
        }

        [Test]
        public void GetBestCoins_FewPiles_ReturnsWithTheHighestNominal()
        {
            var piles = new[]
            {
                new CoinsPile(10, 2),
                new CoinsPile(5, 2),
                new CoinsPile(2, 3),
                new CoinsPile(1, 30)
            };

            var result = new Wallet(piles).GetBestCoins(60);

            var ten = result.Single(p => p.Nominal == 10);
            Assert.AreEqual(2, ten.Count);

            var five = result.Single(p => p.Nominal == 5);
            Assert.AreEqual(2, ten.Count);

            var two = result.Single(p => p.Nominal == 2);
            Assert.AreEqual(3, two.Count);

            var one = result.Single(p => p.Nominal == 1);
            Assert.AreEqual(24, one.Count);
        }
    }
}
