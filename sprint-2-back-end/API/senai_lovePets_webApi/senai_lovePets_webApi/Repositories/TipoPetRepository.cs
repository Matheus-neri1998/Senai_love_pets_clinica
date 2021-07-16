using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class TipoPetRepository : ITipoPetRepository
    {
        lovePetsContext ctx = new lovePetsContext();
        public void Atualizar(TipoPet NovoTipoPet, int id)
        {
            TipoPet TipoPetEncontrado = BuscarPorId(id);

            if (NovoTipoPet.IdTipoPet > 0)
            {
                TipoPetEncontrado.IdTipoPet = NovoTipoPet.IdTipoPet;
            }

            if (NovoTipoPet.NomeTipoPet != null)
            {
                TipoPetEncontrado.NomeTipoPet = NovoTipoPet.NomeTipoPet;
            }

            ctx.TipoPets.Update(TipoPetEncontrado);

            ctx.SaveChanges();
        }

        public TipoPet BuscarPorId(int id)
        {
            return ctx.TipoPets.Find(id);
        }

        public void Cadastrar(TipoPet NovoTipoPet)
        {
            ctx.TipoPets.Add(NovoTipoPet);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TipoPets.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<TipoPet> ListarTodos()
        {
            return ctx.TipoPets.ToList();
        }
    }
}
