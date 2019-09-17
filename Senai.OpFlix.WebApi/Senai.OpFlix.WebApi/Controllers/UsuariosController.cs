using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        UsuarioRepository UsuarioRepository = new UsuarioRepository();

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(UsuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Cadastros Usuario)
        {
            try
            {
                UsuarioRepository.Cadastrar(Usuario);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Erro" + ex.Message });
            }
        }
    }
}