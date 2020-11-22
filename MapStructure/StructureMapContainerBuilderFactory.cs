namespace MapStructure
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using StructureMap;

    public class StructureMapContainerBuilderFactory : IServiceProviderFactory<Container>
    {
        private IServiceCollection _services;

        public Container CreateBuilder(IServiceCollection services)
        {
            _services = services;
            return new Container();
        }

        public IServiceProvider CreateServiceProvider(Container containerBuilder)
        {
            containerBuilder.Configure(config =>
            {
                config.Populate(_services);
            });
            return containerBuilder.GetInstance<IServiceProvider>();
        }
    }
}
