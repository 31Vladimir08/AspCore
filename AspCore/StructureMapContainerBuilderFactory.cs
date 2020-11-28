namespace AspCore
{
    using System;
    using AutoMapper;
    using BusinessLogic.AutoMapperProfile;
    using MapStructure.MapRegistry;
    using Microsoft.Extensions.DependencyInjection;
    using StructureMap;

    public class StructureMapContainerBuilderFactory : IServiceProviderFactory<Container>
    {
        private IServiceCollection _services;

        public Container CreateBuilder(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfileService), typeof(Startup));
            _services = services;
            return new Container();
        }

        public IServiceProvider CreateServiceProvider(Container containerBuilder)
        {
            containerBuilder.Configure(config =>
            {
                config.AddRegistry(new StructuremapServiceRegistry());
                config.AddRegistry(new StructuremapContextRegistry());
                config.AddRegistry(new StructuremapUnitOfWorkRegistry());
                config.Populate(_services);
            });
            return containerBuilder.GetInstance<IServiceProvider>();
        }
    }
}
