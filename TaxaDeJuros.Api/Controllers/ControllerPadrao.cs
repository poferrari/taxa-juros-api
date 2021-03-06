﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using TaxaDeJuros.Dominio.Configuracoes.Dtos;

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

        protected OkObjectResult RetornoSucesso<E>(E resposta)
        {
            return Ok(resposta);
        }

        protected BadRequestObjectResult RetornoErro(Exception ex, string mensagemErro)
        {
            _logger.LogError(ex, mensagemErro);

            var respota = new RespostaErro(mensagemErro);
            return BadRequest(respota);
        }
    }
}
