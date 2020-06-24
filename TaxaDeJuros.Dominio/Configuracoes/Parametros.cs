namespace TaxaDeJuros.Dominio.Configuracoes
{
    public class Parametros
    {
        public virtual decimal TaxaDeJuros { get; set; }

        public Parametros() { }

        public Parametros(decimal taxaDeJuros)
        {
            TaxaDeJuros = taxaDeJuros;
        }
    }
}
