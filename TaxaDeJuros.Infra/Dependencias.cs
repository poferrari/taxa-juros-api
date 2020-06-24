using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxaDeJuros.Infra.Modulos;

namespace TaxaDeJuros.Infra
{
    public static class Dependencias
    {
        public static IServiceCollection ConfigurarContainer(this IServiceCollection services, IConfiguration configuration)
        {
            DominioConfig.Registrar(services, configuration);
            return services;
        }
    }
}
