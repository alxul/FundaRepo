using System;

namespace PropertyServices.Funda.Models
{
    public partial class FundaProperty
    {
        public string AangebodenSindsTekst { get; set; }
        public DateTime AanmeldDatum { get; set; }
        public object AantalBeschikbaar { get; set; }
        public long? AantalKamers { get; set; }
        public object AantalKavels { get; set; }
        public string Aanvaarding { get; set; }
        public string Adres { get; set; }
        public long? Afstand { get; set; }
        public string BronCode { get; set; }
        public object[] ChildrenObjects { get; set; }
        public object DatumAanvaarding { get; set; }
        public object DatumOndertekeningAkte { get; set; }
        public Uri Foto { get; set; }
        public Uri FotoLarge { get; set; }
        public Uri FotoLargest { get; set; }
        public Uri FotoMedium { get; set; }
        public Uri FotoSecure { get; set; }
        public object GewijzigdDatum { get; set; }
        public long? GlobalId { get; set; }
        public Guid GroupByObjectType { get; set; }
        public bool Heeft360GradenFoto { get; set; }
        public bool HeeftBrochure { get; set; }
        public bool HeeftOpenhuizenTopper { get; set; }
        public bool HeeftOverbruggingsgrarantie { get; set; }
        public bool HeeftPlattegrond { get; set; }
        public bool HeeftTophuis { get; set; }
        public bool HeeftVeiling { get; set; }
        public bool HeeftVideo { get; set; }
        public object HuurPrijsTot { get; set; }
        public object Huurprijs { get; set; }
        public object HuurprijsFormaat { get; set; }
        public Guid Id { get; set; }
        public object InUnitsVanaf { get; set; }
        public bool IndProjectObjectType { get; set; }
        public object IndTransactieMakelaarTonen { get; set; }
        public bool IsSearchable { get; set; }
        public bool IsVerhuurd { get; set; }
        public bool IsVerkocht { get; set; }
        public bool IsVerkochtOfVerhuurd { get; set; }
        public long? Koopprijs { get; set; }
        public string KoopprijsFormaat { get; set; }
        public long? KoopprijsTot { get; set; }
        public string Land { get; set; }
        public long? MakelaarId { get; set; }
        public string MakelaarNaam { get; set; }
        public Uri MobileUrl { get; set; }
        public object Note { get; set; }
        public object[] OpenHuis { get; set; }
        public long? Oppervlakte { get; set; }
        public long? Perceeloppervlakte { get; set; }
        public string Postcode { get; set; }
        public Prijs Prijs { get; set; }
        public string PrijsGeformatteerdHtml { get; set; }
        public string PrijsGeformatteerdTextHuur { get; set; }
        public string PrijsGeformatteerdTextKoop { get; set; }
        public string[] Producten { get; set; }
        public Project Project { get; set; }
        public object ProjectNaam { get; set; }
        public PromoLabel PromoLabel { get; set; }
        public string PublicatieDatum { get; set; }
        public long? PublicatieStatus { get; set; }
        public object SavedDate { get; set; }
        public string SoortAanbod { get; set; }
        public long? ObjectSoortAanbod { get; set; }
        public object StartOplevering { get; set; }
        public object TimeAgoText { get; set; }
        public object TransactieAfmeldDatum { get; set; }
        public object TransactieMakelaarId { get; set; }
        public object TransactieMakelaarNaam { get; set; }
        public long? TypeProject { get; set; }
        public Uri Url { get; set; }
        public string VerkoopStatus { get; set; }
        public double Wgs84X { get; set; }
        public double Wgs84Y { get; set; }
        public long? WoonOppervlakteTot { get; set; }
        public long? Woonoppervlakte { get; set; }
        public string Woonplaats { get; set; }
        public long[] ZoekType { get; set; }
    }
}
