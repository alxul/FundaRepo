using PropertyServices.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundaTest.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            SearchOptions = new SearchOptions();
            Results = new List<MakelaarDto>();
        }

        public SearchOptions SearchOptions { get; set; }
        public List<MakelaarDto> Results { get; set; }
    }
}
