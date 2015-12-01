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
            Assert.Throws<ArgumentNullException>(() => new OperationPresenter(MockRepository.GenerateMock<IOperation>(), null));
        }

        [Test]
        public void Ctor_NullOperation_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new OperationPresenter(null, MockRepository.GenerateMock<IOperationView>()));
        }

        [Test]
        public void PileClicked_MockOperation_CallsDeposit()
        {
            var mock = MockRepository.GenerateMock<IOperation>();
            mock.Expect(m => m.Deposit(3, 12));

            var stub = MockRepository.GenerateStub<IOperationView>();

            new OperationPresenter(mock, stub);

            stub.Raise(
                s=>s.PileClicked += null,
                stub, 
                new CoinsPileEventArgs(new CoinsPile(3, 12)));

            mock.VerifyAllExpectations();
        }
    }
}
