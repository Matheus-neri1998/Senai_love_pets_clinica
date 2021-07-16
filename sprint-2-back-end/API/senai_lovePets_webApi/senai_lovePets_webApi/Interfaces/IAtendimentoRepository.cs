using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IAtendimentoRepository
    {
        /// <summary>
        /// Lista todos os atendimentos
        /// </summary>
        /// <returns>Uma lista de atendimentos</returns>
        List<Atendimento> ListarTodos();

        /// <summary>
        /// Busca um atendimento através do seu ID
        /// </summary>
        /// <param name="idAtendimento">ID do atendimento que será buscado</param>
        /// <returns>Um atendimento encontrado</returns>
        Atendimento BuscarPorId(int idAtendimento);

        /// <summary>
        /// Cadastra um novo atendimento
        /// </summary>
        /// <param name="novoAtendimento">Objeto com as novas informações</param>
        void Cadastrar(Atendimento novoAtendimento);

        /// <summary>
        /// Atualiza um atendimento existente
        /// </summary>
        /// <param name="idAtendimento">ID do atendimento que será atualizado</param>
        /// <param name="atendimentoAtualizado">Objeto com as novas informações</param>
        void Atualizar(int idAtendimento, Atendimento atendimentoAtualizado);

        /// <summary>
        /// Deleta um atendimento existente
        /// </summary>
        /// <param name="idAtendimento">ID do atendimento que será deletado</param>
        void Deletar(int idAtendimento);

        /// <summary>
        /// Lista todos os atendimentos de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário que deseja visualizar seus atendimentos</param>
        /// <returns>Uma lista de atendimentos</returns>
        List<Atendimento> ListarMeus(int idUsuario);

        /// <summary>
        /// Altera o status de um atendimento
        /// </summary>
        /// <param name="idAtendimento">ID do atendimento que será alterado</param>
        /// <param name="idNovaSituacao">ID da nova situação</param>
        void AlterarStatus(int idAtendimento, int idNovaSituacao);
    }
}
