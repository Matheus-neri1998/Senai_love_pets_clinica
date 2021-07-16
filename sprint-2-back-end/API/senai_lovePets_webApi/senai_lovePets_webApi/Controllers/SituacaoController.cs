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
    public class SituacaoController : ControllerBase
    {
        private ISituacaoRepository _situacaoRepository { get; set; }

        public SituacaoController()
        {
            _situacaoRepository = new SituacaoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_situacaoRepository.ListarTodos());
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
                return Ok(_situacaoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        } // Fim de BuscarPorId

        [HttpPost]
        public IActionResult Cadastrar(Situacao NovaSituacao)
        {
            try
            {
                _situacaoRepository.Cadastrar(NovaSituacao);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        } // Fim de Cadastrar

        [HttpPut("{id}")]
        public IActionResult Atualizar(Situacao NovaSituacao, int id)
        {
            try
            {
                _situacaoRepository.Atualizar(NovaSituacao, id);

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
                _situacaoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        } // Fim de Deletar
    }
}
