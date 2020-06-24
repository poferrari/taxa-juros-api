using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxaDeJuros.Dominio.Configuracoes;

namespace TaxaDeJuros.Infra.Modulos
{
    public static class DominioConfig
    {
        public static void Registrar(IServiceCollection services, IConfiguration configuration)
        {
            var parametros = configuration.GetSection("Parametros").Get<Parametros>() ?? new Parametros(Constantes.TAXA_DE_JUROS_PADRAO);
            services.AddSingleton(parametros);
        }
    }
}
