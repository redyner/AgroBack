using AgroAPI.Entities.Enums;

namespace AgroAPI.Entities
{
    public class EnderecoRegistrar
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public EnderecoRegistrar()
        {

        }

        public EnderecoRegistrar(string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
