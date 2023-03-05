using MySql.Data.MySqlClient;
using Agro.Entities;
using Agro.Entities.Enums;

namespace Agro.Interfaces
{
    public interface IUsuarioRepository
    {
        string SetUsuario(UsuarioCadastrar usuario);
        void UpdateUsuario(UsuarioCadastrar usuario);

    }
}
