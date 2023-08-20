using AutoMapper;
using Integrations.Cb.Contracts.Interfaces.Business.Models;
using Integrations.Cb.Contracts.Models.Business;
using WelkGroup.WeGo.Integrations.Core.Contracts.Models.Repository;

namespace Integrations.Cb.DataAccess.Mapper
{
    public static class ModelAutoMapper
    {
        public static readonly IMapper Mapper;
        static ModelAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CruiseBookingHeaderDto, CruiseBookingHeader>();
                cfg.CreateMap<CruiseLinesDto, CruiseLines>();
                cfg.CreateMap<TourNamesDto, TourNames>();
            });
            Mapper = config.CreateMapper();
        }
    }
}
