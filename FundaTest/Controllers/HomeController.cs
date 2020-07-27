using FundaTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PropertyServices.FundaImport;
using PropertyServices.Persistence;
using PropertyServices.Search;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FundaTest.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IOptions<ApiSettings> _fundaSettings;
        private readonly IPersistenceService _persistenceService;
        private readonly IFundaImportService _fundaImportService;

        public HomeController(IOptions<ApiSettings> fundaSettings, IPersistenceService persistenceService, IFundaImportService fundaImportService)
        {
            _fundaSettings = fundaSettings ?? throw new ArgumentNullException(nameof(fundaSettings));
            _persistenceService = persistenceService ?? throw new ArgumentNullException(nameof(persistenceService));
            _fundaImportService = fundaImportService ?? throw new ArgumentNullException(nameof(fundaImportService));
        }

        public async Task<IActionResult> Index(HomeViewModel model)
        {
            if (!string.IsNullOrEmpty(model.SearchOptions.City))
            {
                model.Results = await _persistenceService.GetTop10Makelaars(model.SearchOptions);
            }

            return View(model);
        }

        public async Task<IActionResult> Import(HomeViewModel model)
        {
            await _fundaImportService.ImportFromFundaForLocation(model.SearchOptions.City, model.SearchOptions.HasGarden);

            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
