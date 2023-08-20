using Integrations.Cb.Business;
using Integrations.Cb.DataAccess;
using Integrations.Cb.Contracts.Configuration;
using Integrations.Cb.Contracts.Interfaces.Business;
using Integrations.Cb.Contracts.Interfaces.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using WelkGroup.WeGo.Integrations.Core.AspNet.Configuration.DependencyInjection;



namespace Integrations.Cb.Bootstrap.Configuration.DependencyInjection
{
    public static class CruisePortalServiceCollectionExtensions
    {
       
        public static IServiceCollection AddCruiseBookingServices(this IServiceCollection services, CruisePortalConfigration cruisePortalConfigration, bool isDevelopment)
        {
            services.AddCommonServices(isDevelopment, cruisePortalConfigration.ConnectionStrings.CoreDataContext);
            AddCruiseBookingBuisnessBusinessServices(services);
            AddCruiseBookingDataAccessServices(services);
            return services;
        }
        private static void AddCruiseBookingBuisnessBusinessServices(IServiceCollection services)
        {

            services.AddTransient<ICruiseBooking, CruiseBooking>();

        }
        private static void AddCruiseBookingDataAccessServices(IServiceCollection services)
        {
            services.AddTransient<ICoreDatabaseDataAccess, CoreDatabaseDataAccess>();
        }
    }
}