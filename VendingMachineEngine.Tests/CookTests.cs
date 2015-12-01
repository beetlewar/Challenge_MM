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
    public class CookTests
    {
        [Test]
        public void GetCost_MockDrink_ReqeustsExpectedCost()
        {
            var d1 = MockRepository.GenerateStub<IDrink>();
            d1.Stub(d => d.Cost).Return(33);
            d1.Stub(d => d.Id).Return(1);

            var d2 = MockRepository.GenerateStub<IDrink>();
            d2.Stub(d => d.Id).Return(2);

            Assert.AreEqual(33, new Cook(new[] { d2, d1 }).GetCost(1));
        }

        [Test]
        public void GetCost_MockDrink_CallsMake()
        {
            var mock = MockRepository.GenerateMock<IDrink>();
            mock.Expect(d => d.Make());
            mock.Stub(d => d.Id).Return(1);

            var d1 = MockRepository.GenerateStub<IDrink>();
            d1.Stub(d => d.Id).Return(2);

            new Cook(new[] { d1, mock }).Make(1);

            mock.VerifyAllExpectations();
        }
    }
}
