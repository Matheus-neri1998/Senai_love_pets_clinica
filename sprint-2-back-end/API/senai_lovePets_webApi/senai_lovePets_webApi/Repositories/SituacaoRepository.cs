using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        lovePetsContext ctx = new lovePetsContext();
        public void Atualizar(Situacao NovaSituacao, int id)
        {
            Situacao SituacaoEncontrada = BuscarPorId(id);

            if (NovaSituacao.IdSituacao > 0)
            {
                SituacaoEncontrada.IdSituacao = NovaSituacao.IdSituacao;
            }

            if (NovaSituacao.NomeSituacao != null)
            {
                SituacaoEncontrada.NomeSituacao = NovaSituacao.NomeSituacao;
            }

            ctx.Situacaos.Update(SituacaoEncontrada);

            ctx.SaveChanges();
        }

        public Situacao BuscarPorId(int id)
        {
            return ctx.Situacaos.Find(id);
        }

        public void Cadastrar(Situacao NovaSituacao)
        {
            ctx.Situacaos.Add(NovaSituacao);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Situacaos.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Situacao> ListarTodos()
        {
            return ctx.Situacaos.ToList();
        }
    }
}
