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
            Assert.Throws<ArgumentNullException>(() => new CookPresenter(null, MockRepository.GenerateStub<ICookView>()));
        }

        [Test]
        public void Ctor_NullCookView_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new CookPresenter(MockRepository.GenerateStub<IOperation>(), null));
        }

        [Test]
        public void BuyDrinkClicked_MockOperation_CallsBuy()
        {
            var mock = MockRepository.GenerateMock<IOperation>();
            mock.Expect(m => m.Buy(1));

            var stub = MockRepository.GenerateStub<ICookView>();

            new CookPresenter(mock, stub);

            stub.Raise(
                s => s.BuyDrinkClicked += null,
                stub,
                new DrinkIdEventArgs(1));

            mock.VerifyAllExpectations();
        }
    }
}
