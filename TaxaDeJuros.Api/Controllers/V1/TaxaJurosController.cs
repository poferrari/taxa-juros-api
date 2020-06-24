using Microsoft.AspNetCore.Mvc;
using TaxaDeJuros.Dominio.Configuracoes;
using TaxaDeJuros.Dominio.Util;

namespace TaxaDeJuros.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/taxaJuros")]
    public class TaxaJurosController : ControllerBase
    {
        private readonly Parametros _parametros;

        public TaxaJurosController(Parametros parametros)
        {
            _parametros = parametros;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var respota = new ContratoResposta(_parametros.TaxaDeJuros);
            return Ok(respota);
        }
    }
}
