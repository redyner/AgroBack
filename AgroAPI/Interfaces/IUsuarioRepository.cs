using MySql.Data.MySqlClient;
using AgroAPI.Entities;
using AgroAPI.Entities.Enums;

namespace AgroAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        string SetUsuario(UsuarioCadastrar vendedor);
        void UpdateUsuario(UsuarioCadastrar vendedor);

    }
}
