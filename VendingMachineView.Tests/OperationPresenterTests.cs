using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using VendingMachineEngine;

namespace VendingMachineView.Tests
{
    [TestFixture]
    public class OperationPresenterTests
    {
        [Test]
        public void Ctor_NullOperationView_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new OperationPresenter(MockRepository.GenerateMock<IOperation>(), null, MockRepository.GenerateStrictMock<IMessagePresenter>()));
        }

        [Test]
        public void Ctor_NullOperation_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new OperationPresenter(null, MockRepository.GenerateMock<IOperationView>(), MockRepository.GenerateStrictMock<IMessagePresenter>()));
        }

        [Test]
        public void PileClicked_MockOperation_CallsDeposit()
        {
            var mock = MockRepository.GenerateMock<IOperation>();
            mock.Expect(m => m.Deposit(3, 1));

            var stub = MockRepository.GenerateStub<IOperationView>();

            new OperationPresenter(mock, stub, MockRepository.GenerateStrictMock<IMessagePresenter>());

            stub.Raise(
                s=>s.PileClicked += null,
                stub, 
                new CoinsPileEventArgs(new CoinsPile(3, 12)));

            mock.VerifyAllExpectations();
        }

        [Test]
        public void PileClicked_OperationThrowsException_ShowsMessage()
        {
            var mock = MockRepository.GenerateMock<IMessagePresenter>();
            mock.Expect(m => m.ShowMessage("abc"));

            var oper = MockRepository.GenerateStub<IOperation>();
            oper.Stub(m => m.Deposit(0, 0)).IgnoreArguments().Throw(new EngineOperationException("abc"));

            var view = MockRepository.GenerateStub<IOperationView>();

            new OperationPresenter(oper, view, mock);

            view.Raise(
                s => s.PileClicked += null,
                view,
                new CoinsPileEventArgs(new CoinsPile(3, 12)));

            mock.VerifyAllExpectations();
        }

        [Test]
        public void BalanceChanged_SetsBalanceToView()
        {
            var mock = MockRepository.GenerateMock<IOperationView>();
            mock.Expect(m=>m.SetBalance(3));

            var stub = MockRepository.GenerateStub<IOperation>();

            new OperationPresenter(stub, mock, MockRepository.GenerateStub<IMessagePresenter>());

            stub.Raise(
                o => o.BalanceChanged += null,
                stub,
                new BalanceEventArgs(3));

            mock.VerifyAllExpectations();
        }

        [Test]
        public void MoneyBackClicked_MockOperation_CallsMoneyBack()
        {
            var mock = MockRepository.GenerateMock<IOperation>();
            mock.Expect(m => m.MoneyBack());

            var stub = MockRepository.GenerateStub<IOperationView>();

            new OperationPresenter(mock, stub, MockRepository.GenerateStrictMock<IMessagePresenter>());

            stub.Raise(
                s => s.MoneyBackClicked += null,
                stub,
                new CoinsPileEventArgs(new CoinsPile(3, 12)));

            mock.VerifyAllExpectations();
        }
    }
}
