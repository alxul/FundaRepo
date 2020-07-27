using System.Threading.Tasks;

namespace PropertyServices.FundaImport
{
    public interface IFundaImportService
    {
        Task ImportFromFundaForLocation(string location, bool hasGarden);
    }
}
