using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxaDeJuros.Dominio.Configuracoes;
using TaxaDeJuros.Dominio.TaxaJuros.Dtos;

namespace TaxaDeJuros.Infra.Modulos
{
    public static class DominioConfig
    {
        public static void Registrar(IServiceCollection services, IConfiguration configuration)
        {
            var taxaDeJuros = configuration.GetSection("Parametros:TaxaJuros").Get<TaxaJuros>() ?? new TaxaJuros(Constantes.TAXA_DE_JUROS_PADRAO);
            services.AddSingleton(taxaDeJuros);
        }
    }
}
