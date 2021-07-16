using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using senai_lovePets_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        private IVeterinarioRepository _veterinarioRepository { get; set; }

        public VeterinarioController()
        {
            _veterinarioRepository = new VeterinarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_veterinarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        } // Fim de ListarTodos

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(_veterinarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        } // Fim de BuscarPorId

        [HttpPost]
        public IActionResult Cadastrar(Veterinario NovoVeterinario)
        {
            try
            {
                _veterinarioRepository.Cadastrar(NovoVeterinario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        } // Fim de Cadastrar

        [HttpPut("{id}")]
        public IActionResult Atualizar(Veterinario NovoVeterinario, int id)
        {
            try
            {
                _veterinarioRepository.Atualizar(NovoVeterinario, id);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        } // Fim de Atualizar

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _veterinarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        } // Fim de Deletar

    }
}
