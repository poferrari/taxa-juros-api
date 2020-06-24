using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Net;
using TaxaDeJuros.Api.Controllers.V1;
using TaxaDeJuros.Dominio.Configuracoes;
using TaxaDeJuros.Dominio.Util;

namespace TaxaDeJuros.Tests.Controllers.V1
{
    [TestFixture]
    public class TaxaJurosControllerTests
    {
        private Fixture _fixture;
        private Mock<ILogger<TaxaJurosController>> _logger;
        private TaxaJurosController _taxaJurosController;
        private Mock<Parametros> _parametros;
        private decimal _taxaDeJuros;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _taxaDeJuros = _fixture.Create<decimal>();

            _parametros = new Mock<Parametros>();
            _logger = new Mock<ILogger<TaxaJurosController>>();

            _taxaJurosController = new TaxaJurosController(_logger.Object, _parametros.Object);
        }

        [Test]
        public void Retornar_taxa_de_juros_com_sucesso()
        {
            _parametros.SetupGet(t => t.TaxaDeJuros)
                .Returns(_taxaDeJuros);
            var contratoRespostaEsperado = ContratoResposta.CriarContratoRespostaSucesso(_taxaDeJuros);

            var retorno = _taxaJurosController.Get();
            var resultadoOk = retorno as OkObjectResult;

            retorno.Should().NotBeNull();
            resultadoOk.StatusCode.Should().Be((int)HttpStatusCode.OK);
            resultadoOk.Value.Should().BeEquivalentTo(contratoRespostaEsperado);
        }

        [Test]
        public void Retornar_taxa_de_juros_com_problema()
        {
            var mensagemEsperada = Constantes.MENSAGEM_ERRO_TAXA_DE_JUROS;
            var excecao = new Exception(mensagemEsperada);
            _parametros.SetupGet(t => t.TaxaDeJuros)
                .Throws(excecao);

            var contratoRespostaEsperado = ContratoResposta.CriarContratoRespostaErro(mensagemEsperada);

            var retorno = _taxaJurosController.Get();
            var resultadoBadRequest = retorno as BadRequestObjectResult;

            retorno.Should().NotBeNull();
            resultadoBadRequest.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            resultadoBadRequest.Value.Should().BeEquivalentTo(contratoRespostaEsperado);
            _logger.Invocations[0].Arguments[0].As<LogLevel>().Should().Be(LogLevel.Error);
        }
    }
}