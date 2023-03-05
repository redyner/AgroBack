using MySql.Data.MySqlClient;
using Agro.Entities;
using Agro.Entities.Enums;

namespace Agro.Interfaces
{
    public interface ICadastrarExecutor
    {
        string Cadastrar(Usuario usuario);
        void AtualizarCadastro(Usuario usuario);
        void ExcluirCadastro(long usuarioId);
        List<Usuario> BuscarCadastros(Paginacao paginacao);
        Usuario BuscarCadastroPorId(long usuarioId);
        
    }
}
