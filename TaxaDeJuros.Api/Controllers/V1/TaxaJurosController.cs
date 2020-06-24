using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using TaxaDeJuros.Dominio.Configuracoes;

namespace TaxaDeJuros.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/taxaJuros")]
    public class TaxaJurosController : ControllerPadrao<TaxaJurosController>
    {
        private readonly Parametros _parametros;

        public TaxaJurosController(ILogger<TaxaJurosController> logger,
                                   Parametros parametros)
            : base(logger)
        {
            _parametros = parametros;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return RetornoSucesso(_parametros.TaxaDeJuros);
            }
            catch (Exception ex)
            {
                return RetornoErro(ex, Constantes.MENSAGEM_ERRO_TAXA_DE_JUROS);
            }
        }
    }
}
