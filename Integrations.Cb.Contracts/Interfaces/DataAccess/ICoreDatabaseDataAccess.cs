using Integrations.Cb.Contracts.Interfaces.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integrations.Cb.Contracts.Interfaces.DataAccess
{
    public interface ICoreDatabaseDataAccess
    {
        Task<IEnumerable<ICruiseBookingHeader>> GetCruiseBookingHeaderDetailsAsync(string ownerId);
        Task<IEnumerable<ICruiseLines>> GetCruiseLinesAsync();
        Task<IEnumerable<ITourNames>> GetTourNamesAsync();
    }
}
