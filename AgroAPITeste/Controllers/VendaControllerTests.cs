using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTestPaymentAPI.Interfaces;

namespace TechTestPaymentAPI.Controllers.Tests
{
    [TestClass]
    public class VendaControllerTests
    {
        //private Mock<VendaController> _vendaController;
        private Mock<IConexao> _conexao;
        private Mock<IVendaRepository> _vendaRepository;
        private Mock<IUsuarioRepository> _vendedorRepository;
        private Mock<IItemRepository> _itemRepository;

        [TestInitialize]
        public void Inicialize()
        {
            _conexao = new Mock<IConexao>();
            _vendaRepository = new Mock<IVendaRepository>();
            _vendedorRepository = new Mock<IUsuarioRepository>();
            _itemRepository = new Mock<IItemRepository>();
            //_vendaController = new Mock<VendaController>();
        }

        [TestMethod]
        public async Task GetVendaPorId_Falha()
        {
            var mensagem = "Falha ao buscar item por id.";
            var mensagemEsperada = "Microsoft.AspNetCore.Mvc.BadRequestObjectResult";
                
            _vendaRepository.Setup(p => p.GetVendaPorId(It.IsAny<int>())).Throws(new Exception(mensagem));

            var controller = new CadastroController(_conexao.Object, 
                                                _vendaRepository.Object, 
                                                _vendedorRepository.Object, 
                                                _itemRepository.Object);

            var badRequest = controller.Buscar(1);

            //var exception = Assert.ThrowsException<Exception>(() => executeTask); 

            Assert.AreEqual(mensagemEsperada, badRequest.ToString());
        }
    }
}