namespace AgroAPI.Entities
{
    public class Item : ItemRegistrar
    {
        public int Id { get; set; }

        public Item()
        {

        }

        public Item(int id, string nome, double preco) : base(nome,preco)
        {
            Id = id;
        }
    }
}
