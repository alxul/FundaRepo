using PropertyServices.Funda.Models;
using PropertyServices.Search.Models;
using System.Threading.Tasks;

namespace PropertyServices.Search
{
    public interface IPropertySearchService
    {
        Task<FundaResult> SearchAsync(SearchOptions options);
    }
}