using Agro.Entities;
using Agro.Entities.Enums;

namespace AgroTeste.Builder
{
    public class UsuarioCadastrarBuilder
    {
        private readonly Usuario _instancia;

        public UsuarioCadastrarBuilder()
        {
            _instancia = new Usuario
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

        public Usuario Build()
        {
            return _instancia;
        }

    }
}
