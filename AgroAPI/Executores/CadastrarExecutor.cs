using Agro.Entities;
using Agro.Interfaces;
using Agro.Constants;
using Agro.Services;
using Agro.Exceptions;

namespace Agro.Executores
{
    public class CadastrarExecutor : ICadastrarExecutor
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public CadastrarExecutor(IUsuarioRepository usuarioRepository, IEnderecoRepository enderecoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _enderecoRepository = enderecoRepository;
        }

        public string Cadastrar(Usuario usuario)
        {
            //ValidadorUsuario(usuario);
            var enderecoId = _enderecoRepository.SetEndereco(usuario.Endereco);

            usuario.Endereco.Id = long.Parse(enderecoId);

            return _usuarioRepository.SetUsuario(usuario);
        }

        public void AtualizarCadastro(Usuario usuario)
        {
            //ValidadorUsuario(usuario);
            _enderecoRepository.UpdateEndereco(usuario.Endereco);

            _usuarioRepository.UpdateUsuario(usuario);
        }

        public void ExcluirCadastro(long usuarioId)
        {
            _usuarioRepository.DeleteUsuario(usuarioId);
        }

        public List<Usuario> BuscarCadastros()
        {
            return _usuarioRepository.GetUsuarios();
        }

        public Usuario BuscarCadastroPorId(long usuarioId)
        {
            return _usuarioRepository.GetUsuarioPorId(usuarioId);
        }

        public void ValidadorUsuario(Usuario usuario)
        {
            if (!ValidarCPF.IsCpf(usuario.CPF))
                throw new CadastroException(Constants.Mensagens.Cpf_Invalido);

            if (!ValidarTelefone.IsTelefone(usuario.Celular))
                throw new CadastroException(Constants.Mensagens.Celular_Invalido);

            if (!ValidarTelefone.IsTelefone(usuario.Telefone))
                throw new CadastroException(Constants.Mensagens.Telefone_Invalido);

            usuario.CPF = usuario.CPF.Replace(".", "").Replace("-", "").Trim();
        }
    }
}
