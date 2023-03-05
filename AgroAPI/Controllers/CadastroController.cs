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
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
                try
                {
                    string usuarioId = _cadastrarExecutor.Cadastrar(usuario);

                    return Ok("Usuario registrado com sucesso! Id: " + usuarioId);
                }
                catch (CadastroException e)
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
        public IActionResult AtualizarCadastro([FromBody] Usuario usuario)
        {
            using (var connection = _conexao.Conectar())
            {
                try
                {
                    _cadastrarExecutor.AtualizarCadastro(usuario);

                    return Ok("Usuario atualizado com sucesso! Id: " + usuario.Id);
                }
                catch (CadastroException e)
                {
                    return BadRequest(e.Message);
                }
                catch (Exception e)
                {
                    return BadRequest("Ocorreu um erro inesperado: " + e.Message);
                }
            }
        }

        [HttpDelete]
        [Route("ExcluirCadastro")]
        public IActionResult ExcluirCadastro(long usuarioId)
        {
            using (var connection = _conexao.Conectar())
            {
                try
                {
                    _cadastrarExecutor.ExcluirCadastro(usuarioId);

                    return Ok("Usuario excluído com sucesso! Id: " + usuarioId);
                }
                catch (CadastroException e)
                {
                    return BadRequest(e.Message);
                }
                catch (Exception e)
                {
                    return BadRequest("Ocorreu um erro inesperado: " + e.Message);
                }
            }
        }

        [HttpGet]
        [Route("BuscarCadastros")]
        public IActionResult BuscarCadastros()
        {
            using (var connection = _conexao.Conectar())
            {
                try
                {
                    return Ok(_cadastrarExecutor.BuscarCadastros());
                }
                catch (CadastroException e)
                {
                    return BadRequest(e.Message);
                }
                catch (Exception e)
                {
                    return BadRequest("Ocorreu um erro inesperado: " + e.Message);
                }
            }
        }

        [HttpGet]
        [Route("BuscarCadastroPorId")]
        public IActionResult BuscarCadastroPorId(long usuarioId)
        {
            using (var connection = _conexao.Conectar())
            {
                try
                {
                    return Ok(_cadastrarExecutor.BuscarCadastroPorId(usuarioId));
                }
                catch (CadastroException e)
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