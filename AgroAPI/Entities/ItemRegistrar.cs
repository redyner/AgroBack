namespace AgroAPI.Entities
{
    public class ItemRegistrar
    {
        public string Nome { get; set; }
        public double Preco { get; set; }

        public ItemRegistrar()
        {

        }

        public ItemRegistrar(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }
    }
}
