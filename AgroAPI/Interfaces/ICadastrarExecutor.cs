using MySql.Data.MySqlClient;
using Agro.Entities;
using Agro.Entities.Enums;

namespace Agro.Interfaces
{
    public interface ICadastrarExecutor
    {
        string Cadastrar(UsuarioCadastrar usuario);

        void AtualizarCadastro(UsuarioCadastrar usuario);

    }
}
