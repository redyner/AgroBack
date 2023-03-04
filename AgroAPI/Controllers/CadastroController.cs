using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;
using AgroAPI.Entities;
using AgroAPI.Entities.Enums;
using AgroAPI.Interfaces;
using AgroAPI.Repositories.Exceptions;
using AgroAPI.Services;
using Method = RestSharp.Method;

namespace TechTestPaymentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class CadastroController : ControllerBase
    {
        private readonly IConexao _conexao;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IItemRepository _itemRepository;

        public CadastroController(IConexao conexao, IUsuarioRepository usuario, IItemRepository item)
        {
            _conexao = conexao;
            _usuarioRepository = usuario;
            _itemRepository = item;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] UsuarioCadastrar usuario)
        {
            try
            {
                if (!ValidarCPF.IsCpf(usuario.CPF))
                    throw new VendaException("O CPF do vendedor é inválido!");

                if (!ValidarTelefone.IsTelefone(usuario.Telefone))
                    throw new VendaException("O Telefone do vendedor é inválido!");

                    string usuarioId = _usuarioRepository.SetUsuario(usuario);

                return Ok("Usuario registrado com sucesso! Id: "+usuarioId);
            }
            catch(VendaException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Ocorreu um erro inesperado: " + e.Message);
            }

        }

        [HttpPut]
        [Route("AtualizarCadastro")]
        public IActionResult AtualizarCadastro([FromBody] UsuarioCadastrar usuario)
        {
            try
            {
                if (!ValidarCPF.IsCpf(usuario.CPF))
                    throw new VendaException("O CPF do vendedor é inválido!");

                if (!ValidarTelefone.IsTelefone(usuario.Telefone))
                    throw new VendaException("O Telefone do vendedor é inválido!");

                _usuarioRepository.UpdateUsuario(usuario);

                return Ok("Usuario atualizado com sucesso! Id: " + usuario.Id);
            }
            catch (VendaException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Ocorreu um erro inesperado: " + e.Message);
            }

        }
    }
}