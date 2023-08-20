using Integrations.Cb.Contracts.Interfaces.Business.Models;
using System.Threading.Tasks;
using Integrations.Cb.Contracts.Interfaces.DataAccess;
using WelkGroup.WeGo.Integrations.Core.Utils;
using Integrations.Cb.Contracts.Interfaces.Business;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Integrations.Cb.Business
{
    public class CruiseBooking: ICruiseBooking
    {
        private readonly ICoreDatabaseDataAccess _coreDatabaseDataAccess;
        private readonly ILogger<CruiseBooking> _logger;
        public CruiseBooking(ICoreDatabaseDataAccess coreDatabaseDataAccess, ILogger<CruiseBooking> logger)
        {
            _coreDatabaseDataAccess = coreDatabaseDataAccess;
            _logger = logger;
        }
        public async Task<IEnumerable<ICruiseBookingHeader>> GetCruiseBookingHeaderDetailsAsync(string ownerId)
        {
            _logger.LogArgument(LogLevel.Information, "CruiseBooking", "GetCruiseBookingHeaderDetailsAsync", ownerId);
            var cruiseBookingHeaderResponse = await _coreDatabaseDataAccess.GetCruiseBookingHeaderDetailsAsync(ownerId);
            return cruiseBookingHeaderResponse;
        }
        public async Task<IEnumerable<ICruiseLines>> GetCruiseLinesAsync()
        {
            _logger.Log(LogLevel.Information, "CruiseBooking", "GetCruiseLinesAsync");
            return await _coreDatabaseDataAccess.GetCruiseLinesAsync();
        }
        public async Task<IEnumerable<ITourNames>> GetTourNamesAsync()
        {
            _logger.Log(LogLevel.Information, "CruiseBooking", "GetTourNamesAsync");
            return await _coreDatabaseDataAccess.GetTourNamesAsync();
        }
    }
}
