using Agro.Entities.Enums;

namespace Agro.Entities
{
    public class UsuarioCadastrar
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNacimento { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public EnderecoRegistrar Endereco { get; set; }
        public Sexo Sexo { get; set; }

        public UsuarioCadastrar()
        {

        }

        public UsuarioCadastrar(long id, string nome, DateTime dataNacimento, string cPF, string celular, string telefone, string logradouro, EnderecoRegistrar endereco, Sexo sexo)
        {
            Id = id;
            Nome = nome;
            DataNacimento = dataNacimento;
            CPF = cPF;
            Celular = celular;
            Telefone = telefone;
            Endereco = endereco;
            Sexo = sexo;
        }
    }
}
