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
                                from AgroUsuario 
                                where CPF = '{usuario.CPF}'";

                string registro = connection.Query<string>(sql).FirstOrDefault();

                if (string.IsNullOrEmpty(registro))
                {
                    sql = $@"INSERT INTO `testedb`.`AgroUsuario` (`Nome`, `DataNacimento`, `CPF`, `Celular`, `Telefone`, `Sexo` , `EnderecoId`) VALUES('{usuario.Nome}', '{usuario.DataNacimento.ToString("yyyy-MM-dd")}', '{usuario.CPF}', '{usuario.Celular}','{usuario.Telefone}','{usuario.Sexo.ToString()}', '{usuario.Endereco.Id}'); select last_insert_Id();";

                    registro = connection.Query<string>(sql).FirstOrDefault();
                }

                return registro;
            }

        }

        public void UpdateUsuario(Usuario usuario)
        {
            using (var connection = _conexao.Conectar())
            {
                string sql = $@"UPDATE `testedb`.`AgroUsuario` SET `Nome` = '{usuario.Nome}', `DataNacimento` = '{usuario.DataNacimento.ToString("yyyy-MM-dd")}', `CPF` = '{usuario.CPF}', `Celular` = '{usuario.Celular}', `Telefone` = '{usuario.Telefone}', `Sexo` = '{usuario.Sexo.ToString()}' WHERE Id = {usuario.Id};";

                connection.ExecuteAsync(sql);
            }
        }

        public void DeleteUsuario(long usuarioId)
        {
            using (var connection = _conexao.Conectar())
            {
                string sql = $@"DELETE FROM `testedb`.`AgroUsuario` WHERE Id = {usuarioId};";

                connection.ExecuteAsync(sql);
            }
        }

        public List<Usuario> GetUsuarios()
        {
            using (var connection = _conexao.Conectar())
            {

                /*              string sql = $@"SELECT * 
                                                FROM `testedb`.`AgroUsuario` 
                                                ORDER BY `{paginacao.Ordem}` 
                                                LIMIT {paginacao.Inicio-1}, {paginacao.Fim}";*/

                string sql = $@"SELECT * 
                                FROM `testedb`.`AgroUsuario` a
                                JOIN `testedb`.`AgroEndereco` ae ON ae.Id = a.EnderecoId 
                                ORDER BY a.Id";

                var registros = connection.Query<Usuario>(sql, new[] { typeof(Usuario), typeof(Endereco) }, objects => { var usuarioObject = objects[0] as Usuario; var enderecoObject = objects[1] as Endereco; usuarioObject.Endereco = enderecoObject; return usuarioObject; }).ToList();

                return registros;
            }
        }

        public Usuario GetUsuarioPorId(long usuarioId)
        {
            using (var connection = _conexao.Conectar())
            {

                string sql = $@"SELECT * 
                                FROM `testedb`.`AgroUsuario` a
                                JOIN `testedb`.`AgroEndereco` ae ON ae.Id = a.EnderecoId 
                                WHERE a.Id = {usuarioId}";

                var registro = connection.Query<Usuario>(sql, new[] { typeof(Usuario), typeof(Endereco)}, objects => { var usuarioObject = objects[0] as Usuario; var enderecoObject = objects[1] as Endereco; usuarioObject.Endereco = enderecoObject; return usuarioObject; }).FirstOrDefault();

                return registro;
            }
        }

        public bool ValidaColunaTabela(string coluna)
        {
            using (var connection = _conexao.Conectar())
            {

                string sql = $@"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'testedb' AND TABLE_NAME = 'AgroUsuario' AND COLUMN_NAME = '{coluna}'";

                var registro = connection.Query<string>(sql).FirstOrDefault();

                return !string.IsNullOrEmpty(registro) ? true : false;
            }
        }
    }
}

