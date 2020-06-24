using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
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
        private TaxaJurosController _taxaJurosController;
        private Parametros _parametros;
        private decimal _taxaDeJuros;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _taxaDeJuros = _fixture.Create<decimal>();

            _parametros = new Parametros(_taxaDeJuros);

            _taxaJurosController = new TaxaJurosController(_parametros);
        }

        [Test]
        public void Retornar_taxa_de_juros_com_sucesso()
        {
            var contratoRespostaEsperado = new ContratoResposta(_taxaDeJuros);

            var retorno = _taxaJurosController.Get();
            var resultadoOk = retorno as OkObjectResult;

            retorno.Should().NotBeNull();
            resultadoOk.StatusCode.Should().Be((int)HttpStatusCode.OK);
            resultadoOk.Value.Should().BeEquivalentTo(contratoRespostaEsperado);
        }
    }
}