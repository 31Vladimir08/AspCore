namespace BusinessLogic.MapRegistry
{
    using Microsoft.Extensions.DependencyInjection;
    using StructureMap;
    using System;

    public static class MapContainer
    {
        public static IServiceProvider AddServicesContainer(this IServiceCollection services)
        {
            var container = new Container();

            container.Configure(config =>
            {
                config.AddRegistry(new StructureMapRegistry());
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }
    }
}
