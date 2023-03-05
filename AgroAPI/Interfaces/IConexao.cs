using MySql.Data.MySqlClient;
using Agro.Entities;
using Agro.Entities.Enums;

namespace Agro.Interfaces
{
    public interface IConexao
    {
        MySqlConnection Conectar();
    }
}
