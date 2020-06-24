namespace TaxaDeJuros.Dominio.Configuracoes
{
    public class Parametros
    {
        public decimal TaxaDeJuros { get; set; }

        public Parametros() { }

        public Parametros(decimal taxaDeJuros)
        {
            TaxaDeJuros = taxaDeJuros;
        }
    }
}
