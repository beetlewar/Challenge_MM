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
    public class CookPresenterTests
    {
        [Test]
        public void Ctor_NullOperation_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new CookPresenter(null, MockRepository.GenerateStub<ICookView>(), MockRepository.GenerateStub<IMessagePresenter>()));
        }

        [Test]
        public void Ctor_NullCookView_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new CookPresenter(MockRepository.GenerateStub<IOperation>(), null, MockRepository.GenerateStub<IMessagePresenter>()));
        }

        [Test]
        public void Ctor_NullMessagePresenter_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new CookPresenter(MockRepository.GenerateStub<IOperation>(), MockRepository.GenerateStub<ICookView>(), null));
        }

        [Test]
        public void BuyDrinkClicked_OperationThrowsException_ShowsMessage()
        {
            var mock = MockRepository.GenerateMock<IMessagePresenter>();
            mock.Expect(m => m.ShowMessage("cde"));

            var oper = MockRepository.GenerateStub<IOperation>();
            oper.Stub(m => m.Buy(null)).IgnoreArguments().Throw(new EngineOperationException("cde"));

            var view = MockRepository.GenerateStub<ICookView>();

            new CookPresenter(oper, view, mock);

            view.Raise(
                s => s.BuyDrinkClicked += null,
                view,
                new DrinkIdEventArgs(123));

            mock.VerifyAllExpectations();
        }

        [Test]
        public void BuyDrinkClicked_MockOperation_CallsBuy()
        {
            var mock = MockRepository.GenerateMock<IOperation>();
            mock.Expect(m => m.Buy(1));

            var stub = MockRepository.GenerateStub<ICookView>();

            new CookPresenter(mock, stub, MockRepository.GenerateStub<IMessagePresenter>());

            stub.Raise(
                s => s.BuyDrinkClicked += null,
                stub,
                new DrinkIdEventArgs(1));

            mock.VerifyAllExpectations();
        }
    }
}
