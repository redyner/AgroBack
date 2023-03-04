using MySql.Data.MySqlClient;
using AgroAPI.Entities;
using AgroAPI.Entities.Enums;

namespace AgroAPI.Interfaces
{
    public interface IConexao
    {
        MySqlConnection Conectar();
    }
}
