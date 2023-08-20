using Integrations.Cb.Contracts.Interfaces.Business.Models;

namespace Integrations.Cb.Contracts.Models.Business
{
    public class TourNames : ITourNames
    {
        public int Id { get; set; }
        public string TourName { get; set; }
        public string TourType { get; set; }
    }
}
