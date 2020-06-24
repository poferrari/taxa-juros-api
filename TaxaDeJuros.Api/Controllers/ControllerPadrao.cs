using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using TaxaDeJuros.Dominio.Util;

namespace TaxaDeJuros.Api.Controllers
{
    [ApiController]
    public abstract class ControllerPadrao<T> : ControllerBase
    {
        protected readonly ILogger<T> _logger;

        protected ControllerPadrao(ILogger<T> logger)
        {
            _logger = logger;
        }

        protected OkObjectResult RetornoSucesso(object data)
        {
            var respota = ContratoResposta.CriarContratoRespostaSucesso(data);
            return Ok(respota);
        }

        protected BadRequestObjectResult RetornoErro(Exception ex, string mensagemErro)
        {
            _logger.LogError(ex, mensagemErro);

            var respota = ContratoResposta.CriarContratoRespostaErro(mensagemErro);
            return BadRequest(respota);
        }
    }
}
