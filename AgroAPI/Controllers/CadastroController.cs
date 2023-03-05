using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;
using Agro.Entities;
using Agro.Entities.Enums;
using Agro.Interfaces;
using Agro.Services;
using Method = RestSharp.Method;
using Agro.Exceptions;

namespace TechTestPaymentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class CadastroController : ControllerBase
    {
        private readonly IConexao _conexao;
        private readonly ICadastrarExecutor _cadastrarExecutor;

        public CadastroController(IConexao conexao, ICadastrarExecutor cadastrarExecutor)
        {
            _conexao = conexao;
            _cadastrarExecutor = cadastrarExecutor;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar([FromBody] UsuarioCadastrar usuario)
        {
                try
                {
                    string usuarioId = _cadastrarExecutor.Cadastrar(usuario);

                    return Ok("Usuario registrado com sucesso! Id: " + usuarioId);
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

        [HttpPut]
        [Route("AtualizarCadastro")]
        public IActionResult AtualizarCadastro([FromBody] UsuarioCadastrar usuario)
        {
            using (var connection = _conexao.Conectar())
            {
                try
                {
                    _cadastrarExecutor.AtualizarCadastro(usuario);

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
}