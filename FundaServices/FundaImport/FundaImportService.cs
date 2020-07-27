using PropertyServices.Persistence;
using PropertyServices.Persistence.Entities;
using PropertyServices.Search;
using PropertyServices.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PropertyServices.FundaImport
{
    public class FundaImportService : IFundaImportService
    {
        private readonly IPropertySearchService _propertySearchService;
        private readonly IPersistenceService _persistenceService;

        public FundaImportService(IPropertySearchService propertySearchService, IPersistenceService persistenceService)
        {
            _propertySearchService = propertySearchService ?? throw new ArgumentNullException(nameof(propertySearchService));
            _persistenceService = persistenceService ?? throw new ArgumentNullException(nameof(persistenceService));
        }

        public async Task ImportFromFundaForLocation(string city, bool hasGarden)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentException("Location is necessary");
            }

            var properties = new List<Property>();
            var makelaars = new List<Makelaar>();

            // TODO: If we can find out which properties have a garden we won't need to make the second call.
            // For now since I don't know if that info exists (ask) I'll save it from the separate requests.
            var apiResult = await _propertySearchService.SearchAsync(new SearchOptions(1, null, city, hasGarden));

            for (int i = 1; i < apiResult?.Paging?.AantalPaginas; i++)
            {
                if (apiResult?.Paging?.AantalPaginas > apiResult?.Paging?.HuidigePagina && apiResult?.Objects?.Count > 0)
                {
                    Thread.Sleep(100);
                    properties.AddRange(apiResult.Objects
                        .Where(x => x.MakelaarId.HasValue)
                        .Select(x => new Property(x.Id, x.Adres, city, x.MakelaarId.Value, hasGarden))); 

                    var newMakelaars = apiResult.Objects
                        .Where(x => x.MakelaarId.HasValue)
                        .Select(x => new
                        {
                            MakelaarId = x.MakelaarId.Value,
                            x.MakelaarNaam,
                        })
                        .Where(x => !makelaars.Exists(m => m.MakelaarId == x.MakelaarId))
                        .Distinct();
                    if (newMakelaars.Any())
                    {
                        makelaars.AddRange(newMakelaars.Select(x => new Makelaar(x.MakelaarId, x.MakelaarNaam)));
                    }

                    apiResult = await _propertySearchService.SearchAsync(new SearchOptions(apiResult.Paging.HuidigePagina + 1, null, city, hasGarden));
                }
            }

            if (makelaars.Any())
            {
                await _persistenceService.ImportOrUpdateMakelaars(makelaars);
            }

            if (properties.Any())
            {
                await _persistenceService.ImportProperties(properties);
            }

        }
    }
}
