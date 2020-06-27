using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using System;
using TaxaDeJuros.Dominio.Configuracoes;
using dto = TaxaDeJuros.Dominio.TaxaJuros.Dtos;

namespace TaxaDeJuros.Tests.TaxaJuros.Dtos
{
    [TestFixture]
    public class TaxaJurosTests
    {
        private Fixture _fixture;
        private dto.TaxaJuros _taxaJuros;
        private decimal _valorTaxaDeJuros;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _valorTaxaDeJuros = _fixture.Create<decimal>();
        }


        [Test]
        public void Criar_taxa_de_juros_com_sucesso()
        {
            _taxaJuros = new dto.TaxaJuros(_valorTaxaDeJuros);

            _taxaJuros.Valor.Should().Be(_valorTaxaDeJuros);
        }

        [Test]
        public void Validar_taxa_de_juros_com_sucesso()
        {
            _taxaJuros = new dto.TaxaJuros(_valorTaxaDeJuros);

            Action act = () => _taxaJuros.ValidarTaxa();

            act.Should().NotThrow();
            _taxaJuros.Valor.Should().Be(_valorTaxaDeJuros);
        }

        [Test]
        public void Validar_taxa_de_juros_com_erro()
        {
            var taxaInvalida = -1;
            var excecaoEsperada = new InvalidOperationException(Constantes.MENSAGEM_TAXA_JUROS_INVALIDA);
            _taxaJuros = new dto.TaxaJuros(taxaInvalida);

            Action act = () => _taxaJuros.ValidarTaxa();

            act.Should().Throw<InvalidOperationException>().WithMessage(Constantes.MENSAGEM_TAXA_JUROS_INVALIDA);
        }
    }
}
