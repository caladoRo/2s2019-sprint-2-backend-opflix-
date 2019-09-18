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
    public class NovidadesController : ControllerBase
    {

        NovidadeRepository NovidadeRepository = new NovidadeRepository();

        [Authorize]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(NovidadeRepository.Listar());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Novidades novidade = NovidadeRepository.BuscarPorId(id);
            if (novidade == null)
                return NotFound();
            return Ok(novidade);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Novidades novidade)
        {
            try
            {
                NovidadeRepository.Cadastrar(novidade);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro." + ex.Message });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Novidades novidade, int id)
        {
            try
            {
                novidade.IdNovidade = id;
                Novidades LancamentoBuscado = NovidadeRepository.BuscarPorId(novidade.IdNovidade);

                if (LancamentoBuscado == null)
                    return NotFound();

                NovidadeRepository.Atualizar(novidade);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" + ex.Message });
            }
        }

    }
}