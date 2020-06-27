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
using TaxaDeJuros.Dominio.Configuracoes.Dtos;
using dto = TaxaDeJuros.Dominio.TaxaJuros.Dtos;

namespace TaxaDeJuros.Tests.Controllers.V1
{
    [TestFixture]
    public class TaxaJurosControllerTests
    {
        private Fixture _fixture;
        private Mock<ILogger<TaxaJurosController>> _logger;
        private TaxaJurosController _taxaJurosController;
        private Mock<dto.TaxaJuros> _taxaJuros;
        private decimal _valorTaxaDeJuros;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _valorTaxaDeJuros = _fixture.Create<decimal>();

            _taxaJuros = new Mock<dto.TaxaJuros>(MockBehavior.Strict);
            _logger = new Mock<ILogger<TaxaJurosController>>();

            _taxaJurosController = new TaxaJurosController(_logger.Object, _taxaJuros.Object);
        }

        [Test]
        public void Retornar_taxa_de_juros_com_sucesso()
        {
            _taxaJuros.SetupGet(t => t.Valor)
                .Returns(_valorTaxaDeJuros);
            _taxaJuros.Setup(t => t.ValidarTaxa());

            var retorno = _taxaJurosController.Get();
            var resultadoOk = retorno as OkObjectResult;

            retorno.Should().NotBeNull();
            resultadoOk.StatusCode.Should().Be((int)HttpStatusCode.OK);
            resultadoOk.Value.As<dto.TaxaJuros>().Valor.Should().Be(_valorTaxaDeJuros);
            _taxaJuros.Verify();
        }

        [Test]
        public void Retornar_taxa_de_juros_com_problema()
        {
            var mensagemEsperada = Constantes.MENSAGEM_ERRO_TAXA_DE_JUROS;
            var excecao = new InvalidOperationException(Constantes.MENSAGEM_TAXA_JUROS_INVALIDA);
            _taxaJuros.Setup(t => t.ValidarTaxa())
                .Throws(excecao);
            var respostaEsperada = new RespostaErro(mensagemEsperada);

            var retorno = _taxaJurosController.Get();
            var resultadoBadRequest = retorno as BadRequestObjectResult;

            retorno.Should().NotBeNull();
            resultadoBadRequest.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            resultadoBadRequest.Value.Should().BeEquivalentTo(respostaEsperada);
            _taxaJuros.Verify();
            _logger.Invocations[0].Arguments[0].As<LogLevel>().Should().Be(LogLevel.Error);
        }
    }
}