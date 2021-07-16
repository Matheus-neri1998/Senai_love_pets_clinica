using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class RacaRepository : IRacaRepository
    {
        lovePetsContext ctx = new lovePetsContext();
        public void Atualizar(Raca NovaRaca, int id)
        {
            Raca RacaEncontrada = BuscarPorId(id);

            if (NovaRaca.IdRaca > 0)
            {
                RacaEncontrada.IdRaca = NovaRaca.IdRaca;
            }

            if (NovaRaca.NomeRaca != null)
            {
                RacaEncontrada.NomeRaca = NovaRaca.NomeRaca;
            }

            if (NovaRaca.IdTipoPet > 0)
            {
                RacaEncontrada.IdTipoPet = NovaRaca.IdTipoPet;
            }

            ctx.Racas.Update(RacaEncontrada);

            ctx.SaveChanges();
        }

        public Raca BuscarPorId(int id)
        {
            return ctx.Racas.Find(id);
        }

        public void Cadastrar(Raca NovaRaca)
        {
            ctx.Racas.Add(NovaRaca);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Racas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Raca> ListarTodos()
        {
            return ctx.Racas.ToList();
        }
    }
}
