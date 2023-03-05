using Agro.Entities;
using Agro.Interfaces;
using Agro.Constants;
using Agro.Services;

namespace Agro.Executores
{
    public class CadastrarExecutor : ICadastrarExecutor
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public CadastrarExecutor(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public string Cadastrar(UsuarioCadastrar usuario)
        {
            Validador(usuario);

            return _usuarioRepository.SetUsuario(usuario);
        }

        public void AtualizarCadastro(UsuarioCadastrar usuario)
        {
            Validador(usuario);            

            _usuarioRepository.UpdateUsuario(usuario);
        }

        public void Validador(UsuarioCadastrar usuario)
        {
            if (!ValidarCPF.IsCpf(usuario.CPF))
                throw new Exception(Constants.Mensagens.Cpf_Invalido);

            if (!ValidarTelefone.IsTelefone(usuario.Celular))
                throw new Exception(Constants.Mensagens.Celular_Invalido);

            if (!ValidarTelefone.IsTelefone(usuario.Telefone))
                throw new Exception(Constants.Mensagens.Telefone_Invalido);

            usuario.CPF = usuario.CPF.Replace(".", "").Replace("-", "").Trim();
        }
    }
}
