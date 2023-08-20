using System;
using System.Collections.Generic;
using System.Text;
using Integrations.Cb.Contracts.Interfaces.Business.Models;
using System.Threading.Tasks;

namespace Integrations.Cb.Contracts.Interfaces.Business
{
    public  interface ICruiseBooking
    {
        Task<IEnumerable<ICruiseBookingHeader>> GetCruiseBookingHeaderDetailsAsync(string ownerId);
        Task<IEnumerable<ICruiseLines>> GetCruiseLinesAsync();
        Task<IEnumerable<ITourNames>> GetTourNamesAsync();
    }
}
