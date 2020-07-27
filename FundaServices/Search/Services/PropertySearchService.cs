using Newtonsoft.Json;
using PropertyServices.Funda.Models;
using PropertyServices.Search.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PropertyServices.Search
{
    public class PropertySearchService : IPropertySearchService
    {
        private ApiSettings _apiSettings { get; }

        public PropertySearchService(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings ?? throw new ArgumentNullException(nameof(apiSettings));
        }

        public async Task<FundaResult> SearchAsync(SearchOptions options)
        {
            if (options == null || (string.IsNullOrEmpty(options.City)))
            {
                // TODO: Log invalid request
                throw new ArgumentException();
            }

            var client = new HttpClient();
            client.BaseAddress = _apiSettings.BaseUrl;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));

            var parameters = GetApiParameters(options);

            var result = await client.GetAsync(parameters);
            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FundaResult>(json);
        }

        private string GetApiParameters(SearchOptions options)
        {
            var searchHasGardenOption = options.HasGarden ?
                "/tuin" :
                string.Empty;

            return $"{_apiSettings.ApiPath}/{_apiSettings.ApiKey}/?type=koop&pagesize={options.PageSize ?? _apiSettings.MaxPageSize}&page={options.PageIndex}&zo=/{options.City}{searchHasGardenOption}/";
        }
    }
}
