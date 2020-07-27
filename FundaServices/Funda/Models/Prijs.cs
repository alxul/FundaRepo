namespace PropertyServices.Funda.Models
{
    public partial class Prijs
    {
        public bool GeenExtraKosten { get; set; }
        public string HuurAbbreviation { get; set; }
        public object Huurprijs { get; set; }
        public string HuurprijsOpAanvraag { get; set; }
        public object HuurprijsTot { get; set; }
        public string KoopAbbreviation { get; set; }
        public long? Koopprijs { get; set; }
        public string KoopprijsOpAanvraag { get; set; }
        public long? KoopprijsTot { get; set; }
        public object OriginelePrijs { get; set; }
        public string VeilingText { get; set; }
    }
}
