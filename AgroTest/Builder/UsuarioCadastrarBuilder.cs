using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestPaymentAPI.Entities;
using TechTestPaymentAPI.Entities.Enums;

namespace TechTestPaymentAPITests.Builder
{
    public class UsuarioCadastrarBuilder
    {
        private readonly Venda _instancia;

        public UsuarioCadastrarBuilder()
        {
            _instancia = new Venda
            {
                Id = 1,
                Identificador = "identificador",
                DataVenda = DateTime.Now,
                StatusVenda = StatusVenda.AguardandoPagamento,
                Vendedor = null,
                Itens = null
            };
        }
    }
}
