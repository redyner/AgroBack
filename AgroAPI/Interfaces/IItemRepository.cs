using MySql.Data.MySqlClient;
using AgroAPI.Entities;
using AgroAPI.Entities.Enums;

namespace AgroAPI.Interfaces
{
    public interface IItemRepository
    {
        void SetItens(string vendaId, List<ItemRegistrar> itens);
        List<Item> GetItensPorVendaId(int vendaId);

    }
}
