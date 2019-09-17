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
    public class PlataformasController : ControllerBase
    {
        PlataformaRepository PlataformaRepository = new PlataformaRepository();

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(PlataformaRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Plataformas plataforma = PlataformaRepository.BuscarPorId(id);
            if (plataforma == null)
                return NotFound();
            return Ok(plataforma);
        }

        [HttpPost]
        public IActionResult Cadastrar(Plataformas plataforma)
        {
            try
            {
                PlataformaRepository.Cadastrar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro." + ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Plataformas plataforma, int id)
        {
            try
            {
                plataforma.IdPlataforma = id;
                Plataformas PlataformaBuscada = PlataformaRepository.BuscarPorId(plataforma.IdPlataforma);

                if (PlataformaBuscada == null)
                    return NotFound();

                PlataformaRepository.Atualizar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "numfoi" + ex.Message });
            }
        }
    }
}