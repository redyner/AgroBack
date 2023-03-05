using Dapper;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Agro.Entities;
using Agro.Interfaces;
using Agro.Entities.Enums;
using Org.BouncyCastle.Asn1.X509;
using System.Collections;

namespace Agro.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConexao _conexao;

        public UsuarioRepository(IConexao conexao)
        {
            _conexao = conexao;
        }

        public string SetUsuario(Usuario usuario)
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

        public void UpdateUsuario(Usuario usuario)
        {
            using (var connection = _conexao.Conectar())
            {

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

        public void DeleteUsuario(long usuarioId)
        {
            using (var connection = _conexao.Conectar())
            {                   
                    string sql = $@"DELETE FROM `agro`.`usuario` WHERE Id = {usuarioId};";

                    connection.ExecuteAsync(sql);
            }
        }

        public List<Usuario> GetUsuarios(Paginacao paginacao)
        {
            using (var connection = _conexao.Conectar())
            {

                string sql = $@"SELECT * 
                                FROM `agro`.`usuario` 
                                ORDER BY `{paginacao.Ordem}` 
                                LIMIT {paginacao.Inicio}, {paginacao.Fim}";

                var registros = connection.Query<Usuario>(sql).ToList();

                return registros;
            }
        }

        public Usuario GetUsuarioPorId(long usuarioId)
        {
            using (var connection = _conexao.Conectar())
            {

                string sql = $@"SELECT * 
                                FROM `agro`.`usuario` 
                                WHERE Id = {usuarioId}";

                var registro = connection.Query<Usuario>(sql).FirstOrDefault();

                return registro;
            }
        }

        public bool ValidaColunaTabela(string coluna)
        {
            using (var connection = _conexao.Conectar())
            {

                string sql = $@"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'agro' AND TABLE_NAME = 'usuario' AND COLUMN_NAME = '{coluna}'";

                var registro = connection.Query<string>(sql).FirstOrDefault();

                return !string.IsNullOrEmpty(registro) ? true : false;
            }
        }
    }
}
