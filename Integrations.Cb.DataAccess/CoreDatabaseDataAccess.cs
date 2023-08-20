using System.Collections.Generic;
using System.Threading.Tasks;
using Integrations.Cb.Contracts.Interfaces.Business.Models;
using Integrations.Cb.Contracts.Interfaces.DataAccess;
using Integrations.Cb.Contracts.Models.Business;
using Integrations.Cb.DataAccess.Mapper;
using Microsoft.Extensions.Logging;
using WelkGroup.WeGo.Integrations.Core.Contracts.Interfaces.Repositories;
using WelkGroup.WeGo.Integrations.Core.Contracts.Models.Repository;
using WelkGroup.WeGo.Integrations.Core.Utils;

namespace Integrations.Cb.DataAccess
{
    public class CoreDatabaseDataAccess : ICoreDatabaseDataAccess
    {
        private readonly ICruiseBookingRepository _cruiseBookingRepository;
        private readonly ILogger<CoreDatabaseDataAccess> _logger;

        public CoreDatabaseDataAccess(
            ICruiseBookingRepository cruiseBookingRepository,
            ILogger<CoreDatabaseDataAccess> logger)
        {
            _cruiseBookingRepository = cruiseBookingRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<ICruiseBookingHeader>> GetCruiseBookingHeaderDetailsAsync(string ownerId)
        {
            _logger.LogArgument(LogLevel.Information, "CoreDatabaseDataAccess", "GetCruiseBookingHeaderDetailsAsync", ownerId);
            var cruiseBookingHeaderDto = await _cruiseBookingRepository.GetCruiseBookingHeaderDetailsAsync(ownerId);
            return ModelAutoMapper.Mapper.Map<IEnumerable<CruiseBookingHeaderDto>, IEnumerable<CruiseBookingHeader>>(cruiseBookingHeaderDto);
        }
        public async Task<IEnumerable<ICruiseLines>> GetCruiseLinesAsync()
        {
            _logger.Log(LogLevel.Information, "CoreDatabaseDataAccess", "GetCruiseLinesAsync");
            var cruiseLinesDto = await _cruiseBookingRepository.GetCruiseLinesAsync();
            return ModelAutoMapper.Mapper.Map<IEnumerable<CruiseLinesDto>, IEnumerable<CruiseLines>>(cruiseLinesDto);
        }
        public async Task<IEnumerable<ITourNames>> GetTourNamesAsync()
        {
            _logger.Log(LogLevel.Information, "CoreDatabaseDataAccess", "GetTourNamesAsync");
            var tourNamesDto = await _cruiseBookingRepository.GetTourNamesAsync();
            return ModelAutoMapper.Mapper.Map<IEnumerable<TourNamesDto>, IEnumerable<TourNames>>(tourNamesDto);
        }
    }
}
