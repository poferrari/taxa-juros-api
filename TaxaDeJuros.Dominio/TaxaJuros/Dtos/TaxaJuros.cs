using System;
using TaxaDeJuros.Dominio.Configuracoes;

namespace TaxaDeJuros.Dominio.TaxaJuros.Dtos
{
    public class TaxaJuros
    {
        public virtual decimal Valor { get; set; }

        public TaxaJuros() { }

        public TaxaJuros(decimal valor)
            => Valor = valor;

        public virtual void ValidarTaxa()
        {
            if (Valor <= 0)
            {
                throw new InvalidOperationException(Constantes.MENSAGEM_TAXA_JUROS_INVALIDA);
            }
        }
    }
}
