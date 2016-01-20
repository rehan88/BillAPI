using System.Web.Http.Results;
using Bill.API.Controllers.Controllers;
using Bill.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bill.APITests.Controllers
{
    [TestClass]
    public class BillControllerTests
    {
        private readonly Mock<IBillService> _billServiceMock = new Mock<IBillService>();
        
        [TestMethod]
        public void GetReturnsOkResultWhenBillServiceReturnsPopulatedString()
        {
            _billServiceMock.Setup(x => x.GetBill()).Returns(It.IsAny<string>());

            var billController = new BillController(_billServiceMock.Object);
            var result = billController.Get();
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<string>));
        }

        [TestMethod]
        public void GetReturnsBadReuestWhenBillServiceReturnsEmptyString()
        {
            _billServiceMock.Setup(x => x.GetBill()).Returns(string.Empty);

            var billController = new BillController(_billServiceMock.Object);
            var result = billController.Get();
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}