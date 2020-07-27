namespace PropertyServices.Search.Models
{
    public class SearchOptions
    {
        public SearchOptions()
        {
        }

        public SearchOptions(int pageIndex, int? pageSize, string city, bool hasGarden)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            City = city;
            HasGarden = hasGarden;
        }

        public int PageIndex { get; set; } 
        public int? PageSize { get; set; }
        public string City { get; set; }
        public bool HasGarden { get; set; }
    }
}
