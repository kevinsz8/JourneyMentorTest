using Microsoft.Extensions.DependencyInjection;

namespace JourneyMentor.AirportService.Business
{
    public static class AirportHandlers
    {
        public static IServiceCollection AddAirportHandlersModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AirportHandlers).Assembly));
            return serviceCollection;
        }
    }
}