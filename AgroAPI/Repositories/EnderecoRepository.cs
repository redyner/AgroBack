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
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly IConexao _conexao;

        public EnderecoRepository(IConexao conexao)
        {
            _conexao = conexao;
        }

        public string SetEndereco(Endereco endereco)
        {
            using (var connection = _conexao.Conectar())
            {
                    string sql = $@"INSERT INTO `testedb`.`AgroEndereco` (`Logradouro`, `Numero`, `Bairro`, `Cidade`, `Estado`) VALUES('{endereco.Logradouro}', '{endereco.Numero}', '{endereco.Bairro}','{endereco.Cidade}', '{endereco.Estado}'); select last_insert_Id();";

                    string registro = connection.Query<string>(sql).FirstOrDefault();

                return registro;
            }

        }

        public void UpdateEndereco(Endereco endereco)
        {
            using (var connection = _conexao.Conectar())
            {
                    string sql = $@"UPDATE `testedb`.`AgroEndereco` SET `Logradouro` = '{endereco.Logradouro}', `Numero` = '{endereco.Numero}', `Bairro` = '{endereco.Estado}', `Cidade` = '{endereco.Cidade}', `Estado` = '{endereco.Estado}' WHERE Id = {endereco.Id};";

                    connection.ExecuteAsync(sql);
            }
        }

        public void DeleteEndereco(long enderecoId)
        {
            using (var connection = _conexao.Conectar())
            {                   
                    string sql = $@"DELETE FROM `testedb`.`AgroEndereco` WHERE Id = {enderecoId};";

                    connection.ExecuteAsync(sql);
            }
        }
    }
}
