using MySql.Data.MySqlClient;
using Agro.Entities;
using Agro.Entities.Enums;
using Microsoft.Win32;

namespace Agro.Interfaces
{
    public interface IEnderecoRepository
    {
        string SetEndereco(Endereco endereco);
        void UpdateEndereco(Endereco endereco);
        void DeleteEndereco(long EnderecoId);
    }
}
