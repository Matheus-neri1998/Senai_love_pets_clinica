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
    public class AtendimentosController : ControllerBase
    {
        private IAtendimentoRepository _atendimentoRepository { get; set; }

        public AtendimentosController()
        {
            _atendimentoRepository = new AtendimentoRepository();
        }

        /// <summary>
        /// Lista todos os atendimentos
        /// </summary>
        /// <returns>Uma lista de atendimentos e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_atendimentoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um atendimento através do seu ID
        /// </summary>
        /// <param name="idAtendimento">ID do atendimento que será buscado</param>
        /// <returns>Um atendimento encontrado e um status code 200 - Ok</returns>
        [HttpGet("{idAtendimento}")]
        public IActionResult BuscarPorId(int idAtendimento)
        {
            try
            {
                return Ok(_atendimentoRepository.BuscarPorId(idAtendimento));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo atendimento
        /// </summary>
        /// <param name="novoAtendimento">Objeto com as novas informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Cadastrar(Atendimento novoAtendimento)
        {
            try
            {
                _atendimentoRepository.Cadastrar(novoAtendimento);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um atendimento existente
        /// </summary>
        /// <param name="idAtendimento">ID do atendimento que será atualizado</param>
        /// <param name="atendimentoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{idAtendimento}")]
        public IActionResult Atualizar(int idAtendimento, Atendimento atendimentoAtualizado)
        {
            try
            {
                _atendimentoRepository.Atualizar(idAtendimento, atendimentoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um atendimento existente
        /// </summary>
        /// <param name="idAtendimento">ID do atendimento que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{idAtendimento}")]
        public IActionResult Deletar(int idAtendimento)
        {
            try
            {
                _atendimentoRepository.Deletar(idAtendimento);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Altera o status de um atendimento
        /// </summary>
        /// <param name="atendimento">Objeto com o atendimento que será alterado e a nova situação</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPatch]
        public IActionResult AlterarStatus(Atendimento atendimento)
        {
            try
            {
                _atendimentoRepository.AlterarStatus(atendimento.IdAtendimento, atendimento.IdSituacao);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
