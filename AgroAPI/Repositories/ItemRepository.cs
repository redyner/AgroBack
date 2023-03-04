using Dapper;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System.Globalization;
using AgroAPI.Entities;
using AgroAPI.Interfaces;

namespace AgroAPI.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IConexao _conexao;

        public ItemRepository(IConexao conexao)
        {
            _conexao = conexao;
        }

        public void SetItens(string vendaId, List<ItemRegistrar> itens)
        {
            using (var connection = _conexao.Conectar())
            {
                foreach (var item in itens)
                {
                    string sql = $@"insert into item (VendaId,Nome,Preco) values ('{vendaId}','{item.Nome}','{item.Preco.ToString("F2",CultureInfo.InvariantCulture)}');";
                    connection.Execute(sql);
                }
            }
        }

        public List<Item> GetItensPorVendaId(int vendaId)
        {
            using (var connection = _conexao.Conectar())
            {
                string sql = $@"select a.Id,
                            Nome,
                            Preco
                            from item a
                            join venda b on b.Id = a.VendaId
                            where b.Id = {vendaId}";

                return connection.Query<Item>(sql).ToList();
            }
        }
    }
}
