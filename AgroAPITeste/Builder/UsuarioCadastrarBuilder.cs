using Agro.Entities;
using Agro.Entities.Enums;

namespace AgroTeste.Builder
{
    public class UsuarioCadastrarBuilder
    {
        private readonly UsuarioCadastrar _instancia;

        public UsuarioCadastrarBuilder()
        {
            _instancia = new UsuarioCadastrar
            {
                Id = 1,
                Nome = "Rediner Alves Vinhal",
                CPF = "07584826636",
                Celular = "31991993398",
                Telefone = "3133945713",
                DataNacimento = DateTime.Now,
                Sexo = Sexo.M
            };
        }

        public UsuarioCadastrar Build()
        {
            return _instancia;
        }

    }
}
