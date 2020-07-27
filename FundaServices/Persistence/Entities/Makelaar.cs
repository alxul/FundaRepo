namespace PropertyServices.Persistence.Entities
{
    public class Makelaar
    {
        public Makelaar(long makelaarId, string name)
        {
            MakelaarId = makelaarId;
            Name = name;
        }

        public long Id { get; set; }
        public long MakelaarId { get; set; }
        public string Name { get; set; }

    }
}