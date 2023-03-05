using MySql.Data.MySqlClient;
using Agro.Interfaces;

namespace Agro.Services
{
    public class MysqlConnection : IConexao
    {
        private readonly IConfiguration _configuration;

        public MysqlConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MySqlConnection Conectar()
        {
            return new MySqlConnection(_configuration.GetConnectionString("MysqlConnection"));
        }
    }
}
