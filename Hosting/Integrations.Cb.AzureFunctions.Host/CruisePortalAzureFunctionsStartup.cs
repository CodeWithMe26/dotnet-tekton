using Integrations.Cb.AzureFunctions.Host;
using Integrations.Cb.Contracts.Configuration;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using WelkGroup.WeGo.Integrations.Core.AspNet;
using Integrations.Cb.Bootstrap.Configuration.DependencyInjection;

[assembly: FunctionsStartup(typeof(CruisePortalAzureFunctionsStartup))]

namespace Integrations.Cb.AzureFunctions.Host
{
    public class CruisePortalAzureFunctionsStartup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = WeGoFunctionAppBuilder.CreateFunctionAppConfiguration();
            builder.Services.Configure<CruisePortalConfigration>(configuration.GetSection("CruisePortalSettings"));
            builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<CruisePortalConfigration>>().Value);
            var cruiseBookingConfiguration = builder.Services.BuildServiceProvider().GetService<CruisePortalConfigration>();
            var hostingEnvironment = builder.Services.BuildServiceProvider().GetService<IHostingEnvironment>();
            builder.Services.AddCruiseBookingServices(cruiseBookingConfiguration, hostingEnvironment.IsDevelopment());
        }
    }
}
