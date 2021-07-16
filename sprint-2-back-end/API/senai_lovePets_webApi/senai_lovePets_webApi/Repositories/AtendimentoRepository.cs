using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        /// <summary>
        /// Instancia o objeto ctx com a classe lovePetsContext
        /// </summary>
        lovePetsContext ctx = new lovePetsContext();

        /// <summary>
        /// Altera o status de um atendimento
        /// </summary>
        /// <param name="idAtendimento">ID do atendimento que será alterado</param>
        /// <param name="idNovaSituacao">ID da nova situação</param>
        public void AlterarStatus(int idAtendimento, int idNovaSituacao)
        {
            Atendimento atendimentoBuscado = BuscarPorId(idAtendimento);

            if (idNovaSituacao == 1 || idNovaSituacao == 2 || idNovaSituacao == 3)
            {
                atendimentoBuscado.IdSituacao = idNovaSituacao;
            }

            ctx.Atendimentos.Update(atendimentoBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza um atendimento existente
        /// </summary>
        /// <param name="idAtendimento">ID do atendimento que será atualizado</param>
        /// <param name="atendimentoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int idAtendimento, Atendimento atendimentoAtualizado)
        {
            Atendimento atendimentoBuscado = BuscarPorId(idAtendimento);

            if (atendimentoAtualizado.IdPet > 0)
            {
                atendimentoBuscado.IdPet = atendimentoAtualizado.IdPet;
            }

            if (atendimentoAtualizado.IdVeterinario > 0)
            {
                atendimentoBuscado.IdVeterinario = atendimentoAtualizado.IdVeterinario;
            }

            if (atendimentoAtualizado.IdSituacao > 0)
            {
                atendimentoBuscado.IdSituacao = atendimentoAtualizado.IdSituacao;
            }

            if (atendimentoAtualizado.Descricao != null)
            {
                atendimentoBuscado.Descricao = atendimentoAtualizado.Descricao;
            }

            if (atendimentoAtualizado.DataAtendimento >= DateTime.Now)
            {
                atendimentoBuscado.DataAtendimento = atendimentoAtualizado.DataAtendimento;
            }

            ctx.Atendimentos.Update(atendimentoBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um atendimento através do seu ID
        /// </summary>
        /// <param name="idAtendimento">ID do atendimento que será buscado</param>
        /// <returns>Um atendimento encontrado</returns>
        public Atendimento BuscarPorId(int idAtendimento)
        {
            return ctx.Atendimentos.Find(idAtendimento);
        }

        /// <summary>
        /// Cadastra um novo atendimento
        /// </summary>
        /// <param name="novoAtendimento">Objeto com as novas informações</param>
        public void Cadastrar(Atendimento novoAtendimento)
        {
            ctx.Atendimentos.Add(novoAtendimento);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um atendimento existente
        /// </summary>
        /// <param name="idAtendimento">ID do atendimento que será deletado</param>
        public void Deletar(int idAtendimento)
        {
            ctx.Atendimentos.Remove(BuscarPorId(idAtendimento));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os atendimentos de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário que deseja visualizar seus atendimentos</param>
        /// <returns>Uma lista de atendimentos</returns>
        public List<Atendimento> ListarMeus(int idUsuario)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lista todos os atendimentos
        /// </summary>
        /// <returns>Uma lista de atendimentos</returns>
        public List<Atendimento> ListarTodos()
        {
            return ctx.Atendimentos.ToList();
        }
    }
}
