using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MidiasController : ControllerBase
    {
        MidiaRepository MidiaRepository = new MidiaRepository();

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return base.Ok(MidiaRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Midias midia)
        {
            try
            {
                MidiaRepository.Cadastrar(midia);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Não Funfou" + ex.Message });
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Midias midia = MidiaRepository.BuscarPorId(id);
            if (midia == null)
                return NotFound();
            return Ok(midia);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Midias midia, int id)
        {
            try
            {
                midia.IdMidia = id;
                Midias MidiaBuscada = MidiaRepository.BuscarPorId(midia.IdMidia);

                if (MidiaBuscada == null)
                    return NotFound();

                MidiaRepository.Atualizar(midia);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" + ex.Message });
            }
        }
    }
}