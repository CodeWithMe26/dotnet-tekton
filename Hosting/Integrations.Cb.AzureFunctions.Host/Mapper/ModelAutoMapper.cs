using AutoMapper;
using Integrations.Cb.Contracts.Interfaces.Business;
using Integrations.Cb.Contracts.Interfaces.Business.Models;
using Integrations.Cb.Dto;

namespace Integrations.Cb.AzureFunctions.Host
{
    public static class ModelAutoMapper
    {
        public static readonly IMapper iMapper;

        static ModelAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ICruiseBookingHeader, CruiseBookingHeaderDto>(); 
                cfg.CreateMap<ICruiseLines, CruiseLinesDto>();
                cfg.CreateMap<ITourNames, TourNamesDto>();

            });
            iMapper = config.CreateMapper();
        }
    }
}