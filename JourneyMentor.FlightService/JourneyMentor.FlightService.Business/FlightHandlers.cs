using Microsoft.Extensions.DependencyInjection;

namespace JourneyMentor.FlightService.Business
{
    public static class FlightHandlers
    {
        public static IServiceCollection AddFlightHandlersModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(FlightHandlers).Assembly));
            return serviceCollection;
        }
    }
}