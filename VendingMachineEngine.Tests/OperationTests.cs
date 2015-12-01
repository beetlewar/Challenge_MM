using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;

namespace VendingMachineEngine.Tests
{
    [TestFixture]
    public class OperationTests
    {
        [Test]
        public void Ctor_NullUserWallet_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
                new Operation(null, MockRepository.GenerateStub<IWallet>(), MockRepository.GenerateStub<ICook>()));
        }

        [Test]
        public void Ctor_NullMachineWallet_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new Operation(MockRepository.GenerateStub<IWallet>(), null, MockRepository.GenerateStub<ICook>()));
        }

        [Test]
        public void Ctor_NullCook_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new Operation(MockRepository.GenerateStub<IWallet>(), MockRepository.GenerateStub<IWallet>(), null));
        }

        [Test]
        public void Deposit_MockUserWallet_SubstructsRequiredValue()
        {
            var mock = MockRepository.GenerateMock<IWallet>();
            mock.Expect(m => m.SubstructCoins(3, 4));

            new Operation(mock, MockRepository.GenerateStub<IWallet>(), MockRepository.GenerateStub<ICook>()).Deposit(3, 4);

            mock.VerifyAllExpectations();
        }

        [Test]
        public void Deposit_MockMachineWallet_AddsRequiredValue()
        {
            var mock = MockRepository.GenerateMock<IWallet>();
            mock.Expect(m => m.AddCoins(3, 4));

            new Operation(MockRepository.GenerateStub<IWallet>(), mock, MockRepository.GenerateStub<ICook>()).Deposit(3, 4);

            mock.VerifyAllExpectations();
        }

        [Test]
        public void Deposit_ValidCoins_IncreasesBalance()
        {
            var o = new Operation(MockRepository.GenerateStub<IWallet>(), MockRepository.GenerateStub<IWallet>(), MockRepository.GenerateStub<ICook>());
            o.Balance = 10;
            o.Deposit(3, 4);
            Assert.AreEqual(22, o.Balance);
        }

        [Test]
        public void MoneyBack_MockMachineWallet_TakesBestCoins()
        {
            var mock = MockRepository.GenerateMock<IWallet>();
            mock.Expect(m => m.GetBestCoins(100)).Return(new[] { new CoinsPile(1) });

            var o = new Operation(MockRepository.GenerateStub<IWallet>(), mock, MockRepository.GenerateStub<ICook>());
            o.Balance = 100;
            o.MoneyBack();

            mock.VerifyAllExpectations();
        }

        [Test]
        public void MoneyBack_MockUserWallet_AddExpectedPillsToUserWallet()
        {
            var piles = new[] { new CoinsPile(1, 3), new CoinsPile(2, 4) };

            var mock = MockRepository.GenerateMock<IWallet>();
            mock.Expect(m => m.AddCoins(1, 3));
            mock.Expect(m => m.AddCoins(2, 4));

            var stub = MockRepository.GenerateStub<IWallet>();
            stub.Stub(s => s.GetBestCoins(0)).IgnoreArguments().Return(piles);

            new Operation(mock, stub, MockRepository.GenerateStub<ICook>()).MoneyBack();

            mock.VerifyAllExpectations();
        }

        [Test]
        public void MoneyBack_SetsBalanceToZero()
        {
            var stub = MockRepository.GenerateStub<IWallet>();
            stub.Stub(s => s.GetBestCoins(0)).IgnoreArguments().Return(new[] { new CoinsPile(1) });

            var o = new Operation(MockRepository.GenerateStub<IWallet>(), stub, MockRepository.GenerateStub<ICook>());
            o.Balance = 100;
            o.MoneyBack();

            Assert.AreEqual(0, o.Balance);
        }

        [Test]
        public void Cook_BigBalance_CallsCook()
        {
            var mock = MockRepository.GenerateMock<ICook>();
            mock.Expect(m => m.Make(1));

            new Operation(MockRepository.GenerateStub<IWallet>(), MockRepository.GenerateStub<IWallet>(), mock).Buy(1);

            mock.VerifyAllExpectations();
        }

        [Test]
        public void Cook_BigBalance_DecreasesBalanceBySpecifiedCost()
        {
            var stub = MockRepository.GenerateStub<ICook>();
            stub.Stub(s => s.GetCost("abc")).Return(12);

            var o = new Operation(MockRepository.GenerateStub<IWallet>(), MockRepository.GenerateStub<IWallet>(), stub);
            o.Balance = 15;
            o.Buy("abc");

            Assert.AreEqual(3, o.Balance);
        }

        [Test]
        public void Cook_InsufficientMoney_ThrowsEngineOperationException()
        {
            var stub = MockRepository.GenerateStub<ICook>();
            stub.Stub(s => s.GetCost(null)).IgnoreArguments().Return(4);
            stub.Stub(s => s.Make(null)).IgnoreArguments().Throw(new Exception());

            var o = new Operation(MockRepository.GenerateStub<IWallet>(), MockRepository.GenerateStub<IWallet>(), stub);
            o.Balance = 3;
            Assert.Throws<EngineOperationException>(() => o.Buy("black_coffee"));
        }
    }
}
