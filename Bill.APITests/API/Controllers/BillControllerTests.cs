using System.Web.Http.Results;
using Bill.API.Controllers.Controllers;
using Bill.Core.Interfaces;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bill.APITests.API.Controllers
{
    [TestClass]
    public class BillControllerTests
    {
        private readonly Mock<IBillService> _billServiceMock = new Mock<IBillService>();
        private readonly Mock<ILog> _iLogMock = new Mock<ILog>();

        const string SimpleJsonObject = "{testkey: testvalue}";

        [TestMethod]
        public void GetReturnsOkResultWhenBillServiceReturnsPopulatedString()
        {
            _billServiceMock.Setup(x => x.GetBill()).Returns(SimpleJsonObject);

            var billController = new BillController(_billServiceMock.Object, _iLogMock.Object);
            var result = billController.Get();
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<string>));
        }

        [TestMethod]
        public void GetReturnsBadReuestWhenBillServiceReturnsEmptyString()
        {
            _billServiceMock.Setup(x => x.GetBill()).Returns(string.Empty);

            var billController = new BillController(_billServiceMock.Object, _iLogMock.Object);
            var result = billController.Get();
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}