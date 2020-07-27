using System;

namespace PropertyServices.Persistence.Entities
{
    public class Property
    {
        public Property(Guid propertyId, string address, string city, long makelaarId, bool hasGarden)
        {
            PropertyId = propertyId;
            Address = address;
            City = city;
            MakelaarId = makelaarId;
            HasGarden = hasGarden;
        }

        public long Id { get; set; }
        public Guid PropertyId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public long MakelaarId { get; set; }
        public bool HasGarden { get; set; }
        public DateTime ImportDateTime { get; set; } = DateTime.UtcNow;
    }
}
