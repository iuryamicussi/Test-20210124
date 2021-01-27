using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Moq;
using Thomson.Assessment.Controllers;
using Thomson.Assessment.Infrastructure.DAL;
using Microsoft.Extensions.Logging;
using Thomson.Assessment.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Thomson.Assessment.Tests.Controllers
{
    [TestClass]
    public class CaseControllerTest
    {
        private readonly CaseController target;
        private readonly Mock<ILogger<CaseController>> _mockLogger;
        private readonly Mock<ICaseRepository> _mockCaseRepository;

        public CaseControllerTest()
        {
            _mockLogger = new Mock<ILogger<CaseController>>();
            _mockCaseRepository = new Mock<ICaseRepository>();

            target = new CaseController(_mockLogger.Object, _mockCaseRepository.Object);
        }

        [TestMethod]
        public async Task WhenCallingGet_WithAPopulatedDb_ShouldReturnACollectionOfCases()
        {
            //arrange
            var expected = CaseStubs.CaseList();
            _mockCaseRepository.Setup(x => x.GetAll()).ReturnsAsync(expected);

            //act
            var result = await target.Get();

            //assert
            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task WhenCallingGetFilteringForExistingCase_ShouldReturnTheCase()
        {
            //arrange
            var expected = CaseStubs.CaseList().First();
            _mockCaseRepository.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(expected);

            //act
            var result = await target.Get("12345");

            //assert
            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task WhenCallingPostPassingCaseAlreadyInserted_ShouldReturnErrorWithMessage()
        {
            //arrange
            var alreadyCreatedCase = CaseStubs.CaseList().First();
            _mockCaseRepository.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(alreadyCreatedCase);

            //act
            var result = await target.Post(alreadyCreatedCase);
            var badRequestResult = result as BadRequestObjectResult;

            //assert
            badRequestResult.Should().NotBeNull();
            badRequestResult.StatusCode.Should().Be(400);
        }

        //TODO
    }
}