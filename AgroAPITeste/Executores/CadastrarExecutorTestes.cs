using Agro.Executores;
using Agro.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AgroTeste.Builder;
using Agro.Entities;
using Agro.Constants;
using System;
using Agro.Exceptions;

namespace AgroTeste.Executores
{
    [TestClass]
    public class CadastrarExecutorTestes
    {
        private Mock<IUsuarioRepository> _usuarioRepository;
        private Mock<IEnderecoRepository> _enderecoRepository;

        [TestInitialize]
        public void Inicialize()
        {
            _usuarioRepository = new Mock<IUsuarioRepository>();
            _enderecoRepository = new Mock<IEnderecoRepository>();
        }

        [TestMethod]
        public async Task CadastrarExecutor_Cadastrar_Sucesso()
        {
            // _vendaRepository.Setup(p => p.GetVendaPorId(It.IsAny<int>())).Throws(new Exception(mensagem));

            var idCadastrado = "1";

            _usuarioRepository.Setup(p => p.SetUsuario(It.IsAny<Usuario>())).Returns(idCadastrado);

            var usuario = new UsuarioCadastrarBuilder().Build();

            var executor = new CadastrarExecutor(_usuarioRepository.Object,_enderecoRepository.Object);

            var result = executor.Cadastrar(usuario);

            //var exception = Assert.ThrowsException<Exception>(() => executeTask); 

            //Assert.AreEqual(mensagemEsperada, badRequest.ToString());
            Assert.AreEqual(result, idCadastrado);
        }

        [TestMethod]
        public async Task CadastrarExecutor_CpfInvalido_Erro()
        {

            var usuario = new UsuarioCadastrarBuilder().Build();

            usuario.CPF = "1";

            var executor = new CadastrarExecutor(_usuarioRepository.Object, _enderecoRepository.Object);

            //var executeTask = executor.Cadastrar(usuario);

            var exception = Assert.ThrowsException<CadastroException>(() => executor.Cadastrar(usuario)); 

            Assert.AreEqual(exception.Message, Mensagens.Cpf_Invalido);
        }

        [TestMethod]
        public async Task CadastrarExecutor_CelularInvalido_Erro()
        {

            var usuario = new UsuarioCadastrarBuilder().Build();

            usuario.Celular = "1";

            var executor = new CadastrarExecutor(_usuarioRepository.Object, _enderecoRepository.Object);

            //var executeTask = executor.Cadastrar(usuario);

            var exception = Assert.ThrowsException<CadastroException>(() => executor.Cadastrar(usuario));

            Assert.AreEqual(exception.Message, Mensagens.Celular_Invalido);
        }

        [TestMethod]
        public async Task CadastrarExecutor_TelefoneInvalido_Erro()
        {

            var usuario = new UsuarioCadastrarBuilder().Build();

            usuario.Telefone = "1";

            var executor = new CadastrarExecutor(_usuarioRepository.Object, _enderecoRepository.Object);

            var exception = Assert.ThrowsException<CadastroException>(() => executor.Cadastrar(usuario));

            Assert.AreEqual(exception.Message, Mensagens.Telefone_Invalido);
        }

        [TestMethod]
        public async Task Validador_AjusteCpf_Sucesso()
        {

            var usuario = new UsuarioCadastrarBuilder().Build();

            usuario.CPF = "075.848.266-36";

            var executor = new CadastrarExecutor(_usuarioRepository.Object, _enderecoRepository.Object);

            executor.ValidadorUsuario(usuario);

            Assert.AreEqual(usuario.CPF, "07584826636");
        }

        [TestMethod]
        public async Task CadastrarExecutor_MetodosVoid_Sucesso()
        {
            var usuario = new UsuarioCadastrarBuilder().Build();

            var executor = new CadastrarExecutor(_usuarioRepository.Object, _enderecoRepository.Object);

            executor.AtualizarCadastro(usuario);
            executor.BuscarCadastros();
            executor.BuscarCadastroPorId(usuario.Id);
            executor.ExcluirCadastro(usuario.Id);

        }        
    }
}