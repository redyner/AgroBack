using MySql.Data.MySqlClient;
using Agro.Entities;
using Agro.Entities.Enums;
using Microsoft.Win32;

namespace Agro.Interfaces
{
    public interface IUsuarioRepository
    {
        string SetUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(long usuarioId);
        List<Usuario> GetUsuarios(Paginacao paginacao);
        Usuario GetUsuarioPorId(long usuarioId);
        bool ValidaColunaTabela(string coluna);

    }
}
