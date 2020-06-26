namespace TaxaDeJuros.Api.Util
{
    public class ContratoResposta
    {
        public object Data { get; set; }
        public string Erro { get; set; }

        public ContratoResposta(object data, string erro = null)
        {
            Data = data;
            Erro = erro;
        }

        public static ContratoResposta CriarContratoRespostaSucesso(object data)
            => new ContratoResposta(data);

        public static ContratoResposta CriarContratoRespostaErro(string erro)
            => new ContratoResposta(null, erro);
    }
}
