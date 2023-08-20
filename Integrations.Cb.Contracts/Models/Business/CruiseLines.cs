using Integrations.Cb.Contracts.Interfaces.Business.Models;

namespace Integrations.Cb.Contracts.Models.Business
{
    public class CruiseLines : ICruiseLines
    {
        public long CruiseLinesId { get; set; }
        public string CruiseLinesName { get; set; }
    }
}
