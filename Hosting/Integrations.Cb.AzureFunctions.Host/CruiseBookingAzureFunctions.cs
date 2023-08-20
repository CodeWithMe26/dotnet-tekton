using System.Threading.Tasks;
using Integrations.Cb.Contracts.Interfaces.Business;
using Integrations.Cb.Contracts.Interfaces.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using WelkGroup.WeGo.Integrations.Core.Contracts.Interfaces.Business;
using Newtonsoft.Json;
using System;
using WelkGroup.WeGo.Integrations.Core.Contracts.Models.Business;
using System.Web.Http;
using System.Collections.Generic;
using Integrations.Cb.Dto;

namespace Integrations.Cb.AzureFunctions.Host
{
    public class CruiseBookingAzureFunctions
    {
        private readonly ICruiseBooking _cruiseBooking;
        private readonly IIntegrationAuditLogs _integrationAuditLogs;
        private readonly ILogger<CruiseBookingAzureFunctions> _logger;
        public CruiseBookingAzureFunctions(ICruiseBooking cruiseBooking, IIntegrationAuditLogs integrationAuditLogs, ILogger<CruiseBookingAzureFunctions> logger)
        {
            _cruiseBooking = cruiseBooking;
            _integrationAuditLogs = integrationAuditLogs;
            _logger = logger;
        }
        [FunctionName("GetCruiseBookingHeaderDetails")]
        public async Task<IActionResult> GetCruiseBookingHeaderDetails(
           [HttpTrigger(AuthorizationLevel.Function, "get", Route = AzureFunctionRoutes.GetCruiseBookingHeaderDetails)]
            HttpRequest request)
        {
            var startDate = DateTime.UtcNow;
            var ownerId = request.Query["OwnerId"];
            try
            {

                _logger.LogInformation("Get CruiseBooking Details for Requested OwnerId {0}", ownerId);
                if (string.IsNullOrWhiteSpace(ownerId))
                {
                    return new NotFoundResult();
                }
                var contractsStatus = await _cruiseBooking.GetCruiseBookingHeaderDetailsAsync(ownerId).ConfigureAwait(false);
                var contractsStatusDto = ModelAutoMapper.iMapper.Map<IEnumerable<ICruiseBookingHeader>, IEnumerable<CruiseBookingHeaderDto>>(contractsStatus);
                await LogIntegrationAudit("CruiseBooking-GetCruiseBookingHeaderDetails", JsonConvert.SerializeObject(ownerId), true, startDate);
                _logger.LogInformation("Get CruiseBooking Details Compleated for OwnerId  {0}", ownerId);
                return new OkObjectResult(contractsStatusDto);
            }
            catch (Exception e)
            {
                await LogIntegrationAudit("CruiseBooking-GetCruiseBookingHeaderDetails", JsonConvert.SerializeObject(ownerId), false, startDate, e);
                return new ExceptionResult(e, true);
            }
        }
        [FunctionName("GetCruiseLinesAsync")]
        public async Task<IActionResult> GetCruiseLinesAsync(
          [HttpTrigger(AuthorizationLevel.Function, "get", Route = AzureFunctionRoutes.GetCruiseLines)]
            HttpRequest request)
        {
            var startDate = DateTime.UtcNow;
            try
            {
                _logger.Log(LogLevel.Information, "CruiseBookingAzureFunctions", "GetCruiseLinesAsync");
                var cruiseLines = await _cruiseBooking.GetCruiseLinesAsync().ConfigureAwait(false);
                var cruiseLinesDto = ModelAutoMapper.iMapper.Map<IEnumerable<ICruiseLines>, IEnumerable<CruiseLinesDto>>(cruiseLines);
                await LogIntegrationAudit("CruiseBooking-GetCruiseLines", null, true, startDate);
                _logger.Log(LogLevel.Information, "CruiseBookingAzureFunctions", "GetCruiseLinesAsync");
                return new OkObjectResult(cruiseLinesDto);
            }
            catch (Exception e)
            {
                await LogIntegrationAudit("CruiseBooking-GetCruiseLines", null, false, startDate, e);
                return new ExceptionResult(e, true);
            }
        }
        private async Task LogIntegrationAudit(string integrationString, string ga1FilesRequest, bool isSuccess, DateTime startTime, Exception ex = null)
        {
            var integrationAudit = new IntegrationAudit()
            {
                Integration = integrationString,
                IsSucceed = isSuccess,
                StartTime = startTime,
                EndTime = DateTime.UtcNow,
                ErrorMessage = ex != null ? ex.Message : null,
                StackTrace = ex != null ? ex.StackTrace : null,
                RequestPayload = JsonConvert.SerializeObject(ga1FilesRequest)
            };
            await _integrationAuditLogs.AddLogAsync(integrationAudit);
        }

        [FunctionName("GetTourNamesAsync")]
        public async Task<IActionResult> GetTourNamesAsync(
          [HttpTrigger(AuthorizationLevel.Function, "get", Route = AzureFunctionRoutes.GetTourNames)]
            HttpRequest request)
        {
            var startDate = DateTime.UtcNow;
            try
            {
                _logger.Log(LogLevel.Information, "CruiseBookingAzureFunctions", "GetTourNamesAsync");
                var tourNames = await _cruiseBooking.GetTourNamesAsync().ConfigureAwait(false);
                var tourNamesDto = ModelAutoMapper.iMapper.Map<IEnumerable<ITourNames>, IEnumerable<TourNamesDto>>(tourNames);
                await LogIntegrationAudit("CruiseBooking-GetTourNames", null, true, startDate);
                _logger.Log(LogLevel.Information, "CruiseBookingAzureFunctions", "GetTourNamesAsync");
                return new OkObjectResult(tourNamesDto);
            }
            catch (Exception e)
            {
                await LogIntegrationAudit("CruiseBooking-GetTourNames", null, false, startDate, e);
                return new ExceptionResult(e, true);
            }
        }
    }
}