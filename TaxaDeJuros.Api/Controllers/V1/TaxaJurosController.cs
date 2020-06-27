using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using TaxaDeJuros.Dominio.Configuracoes;
using TaxaDeJuros.Dominio.TaxaJuros.Dtos;

namespace TaxaDeJuros.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/taxaJuros")]
    public class TaxaJurosController : ControllerPadrao<TaxaJurosController>
    {
        private readonly TaxaJuros _taxaJuros;

        public TaxaJurosController(ILogger<TaxaJurosController> logger,
                                   TaxaJuros taxaJuros)
            : base(logger)
        {
            _taxaJuros = taxaJuros;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _taxaJuros.ValidarTaxa();

                return RetornoSucesso(_taxaJuros);
            }
            catch (Exception ex)
            {
                return RetornoErro(ex, Constantes.MENSAGEM_ERRO_TAXA_DE_JUROS);
            }
        }
    }
}
