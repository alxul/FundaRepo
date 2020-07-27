using PropertyServices.Persistence.Entities;
using System.Collections.Generic;

namespace PropertyServices.Search.Models
{
    public class SearchResult
    {
        List<Property> Properties { get; set; } // Normally I don't use DB Entities but DTOs, but since this is a sample project let's skip it.
    }
}