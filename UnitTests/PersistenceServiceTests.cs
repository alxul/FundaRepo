using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PropertyServices.Persistence;
using PropertyServices.Search.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class PersistenceServiceTests
    {
        [TestMethod]
        public async Task GetTop10Makelaars_ShouldBringResult_Successfully()
        {
            var moqService = new Mock<IPersistenceService>();
            moqService.Setup(x => x.GetTop10Makelaars(It.Is<SearchOptions>(t=>t.City == "utrecht")))
                .Returns(Task.FromResult(new List<MakelaarDto>() {
                    new MakelaarDto(1,"Test", 5)
                }));
            var results = await moqService.Object.GetTop10Makelaars(new SearchOptions(1, 10, "utrecht", false));

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Where(x => x.MakelaarId == 1).Select(x => x.PropertiesCount).FirstOrDefault() == 5);
        }

        [TestMethod]
        public async Task GetTop10Makelaars_ShouldFindNone()
        {
            var moqService = new Mock<IPersistenceService>();
            moqService.Setup(x => x.GetTop10Makelaars(It.Is<SearchOptions>(t => t.City == "utrecht")))
                .Returns(Task.FromResult(new List<MakelaarDto>() {
                    new MakelaarDto(1,"Test", 5)
                }));
            var results = await moqService.Object.GetTop10Makelaars(new SearchOptions(1, 10, "amsterdam", false));

            Assert.IsNull(results);
        }
    }
}
