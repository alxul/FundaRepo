namespace PropertyServices.Search.Models
{
    public class MakelaarDto
    {
        public MakelaarDto(long makelaarId, string makelaarName, int propertiesCount)
        {
            MakelaarId = makelaarId;
            MakelaarName = makelaarName;
            PropertiesCount = propertiesCount;
        }

        public long MakelaarId { get; }
        public string MakelaarName { get; }
        public int PropertiesCount { get; }
    }
}