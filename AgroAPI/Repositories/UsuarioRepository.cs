using Dapper;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Agro.Entities;
using Agro.Interfaces;
using Agro.Entities.Enums;

namespace Agro.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConexao _conexao;

        public UsuarioRepository(IConexao conexao)
        {
            _conexao = conexao;
        }

        public string SetUsuario(UsuarioCadastrar usuario)
        {
            using (var connection = _conexao.Conectar())
            {
                string sql = $@"select Id 
                                from usuario 
                                where CPF = '{usuario.CPF}'";

                string registro = connection.Query<string>(sql).FirstOrDefault();

                if (string.IsNullOrEmpty(registro))
                {
                    sql = $@"INSERT INTO `agro`.`usuario` (`Nome`, `DataNacimento`, `Estado`, `CPF`, `Celular`, `Telefone`, `Logradouro`, `Numero`, `Bairro`, `Cidade`, `Sexo`) VALUES('{usuario.Nome}', '{usuario.DataNacimento.ToString("yyyy-MM-dd")}', '{usuario.Endereco.Estado}', '{usuario.CPF}', '{usuario.Celular}','{usuario.Telefone}',' {usuario.Endereco.Logradouro}',' {usuario.Endereco.Numero}',' {usuario.Endereco.Bairro}',' {usuario.Endereco.Cidade}','{usuario.Sexo.ToString()}'); select last_insert_Id();";

                    registro = connection.Query<string>(sql).FirstOrDefault();
                }

                return registro;
            }

        }

        public void UpdateUsuario(UsuarioCadastrar usuario)
        {
            using (var connection = _conexao.Conectar())
            {
                usuario.CPF = usuario.CPF.Replace(".", "").Replace("-", "").Trim();

                string sql = $@"select Id 
                                from usuario 
                                where CPF = '{usuario.CPF}'";

                string registro = connection.Query<string>(sql).FirstOrDefault();

                if (string.IsNullOrEmpty(registro))
                {
                    sql = $@"UPDATE `agro`.`usuario` SET `Nome` = '{usuario.Nome}', `DataNacimento` = '{usuario.DataNacimento.ToString("yyyy-MM-dd")}', `Estado` = '{usuario.Endereco.Estado}', `CPF` = '{usuario.CPF}', `Celular` = '{usuario.Celular}', `Telefone` = '{usuario.Telefone}', `Logradouro` = ' {usuario.Endereco.Logradouro}', `Numero` = '{usuario.Endereco.Numero}', `Bairro` = '{usuario.Endereco.Bairro}', `Cidade` = '{usuario.Endereco.Cidade}', `Sexo` = '{usuario.Sexo.ToString()}' WHERE Id = {usuario.Id};";

                    connection.ExecuteAsync(sql);
                }
            }

        }
    }
}
