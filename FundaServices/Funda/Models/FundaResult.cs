using System.Collections.Generic;

namespace PropertyServices.Funda.Models
{
    // I used a JSON to C# converter to produce these classes, I didn't type it xD

    public class FundaResult
    {
        public long AccountStatus { get; set; }
        public bool EmailNotConfirmed { get; set; }
        public bool ValidationFailed { get; set; }
        public object ValidationReport { get; set; }
        public long Website { get; set; }
        public Metadata Metadata { get; set; }
        public List<FundaProperty> Objects { get; set; }
        public Paging Paging { get; set; }
        public long TotaalAantalObjecten { get; set; }
    }
}
