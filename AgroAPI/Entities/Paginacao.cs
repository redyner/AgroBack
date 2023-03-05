using Agro.Entities.Enums;

namespace Agro.Entities
{
    public class Paginacao
    {
        public string Ordem { get; set; }
        public int Inicio { get; set; }
        public int Fim { get; set; }

        public Paginacao()
        {

        }
        public Paginacao(string ordem, int inicio, int fim)
        {
            Ordem = ordem;
            Inicio = inicio;
            Fim = fim;
        }
    }
}
