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
    public class DonoController : ControllerBase
    {
        private IDonoRepository _donoRepository { get; set;}

        public DonoController()
        {
            _donoRepository = new DonoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_donoRepository.ListarTodos());
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
                return Ok(_donoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        } // Fim de BuscarPorId

        [HttpPost]
        public IActionResult Cadastrar(Dono NovoDono)
        {
            try
            {
                _donoRepository.Cadastrar(NovoDono);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        } // Fim de Cadastrar

        [HttpPut("{id}")]
        public IActionResult Atualizar(Dono NovoDono, int id)
        {
            try
            {
                _donoRepository.Atualizar(NovoDono, id);

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
                _donoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        } // Fim de Deletar
    }
}
