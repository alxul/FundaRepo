using PropertyServices.Persistence.Entities;
using PropertyServices.Search.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyServices.Persistence
{
    public interface IPersistenceService
    {
        Task ImportProperties(List<Property> properties);
        Task<List<MakelaarDto>> GetTop10Makelaars(SearchOptions options);
        Task ImportOrUpdateMakelaars(List<Makelaar> makelaars);
    }
}
