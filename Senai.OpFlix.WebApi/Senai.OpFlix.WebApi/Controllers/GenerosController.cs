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
    [Produces("application/json")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        GeneroRepository GeneroRepository = new GeneroRepository();

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(GeneroRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Generos genero)
        {
            try
            {
                GeneroRepository.Cadastrar(genero);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Não funfou" + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Generos genero = GeneroRepository.BuscarPorId(id);
            if (genero == null)
                return NotFound();
            return Ok(genero);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Generos genero, int id)
        {
            try
            {
                genero.IdGenero = id;
                Generos GeneroBuscado = GeneroRepository.BuscarPorId(genero.IdGenero);

                if (GeneroBuscado == null)
                    return NotFound();

                GeneroRepository.Atualizar(genero);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" + ex.Message });
            }
        }
    }
}