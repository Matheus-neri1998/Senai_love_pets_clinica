using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class DonoRepository : IDonoRepository
    {
        lovePetsContext ctx = new lovePetsContext();
        public void Atualizar(Dono NovoDono, int id)
        {
            Dono DonoEscontrado = BuscarPorId(id);

            if (NovoDono.IdDono > 0)
            {
                DonoEscontrado.IdDono = NovoDono.IdDono;
            }

            if (NovoDono.NomeDono != null)
            {
                DonoEscontrado.NomeDono = NovoDono.NomeDono;
            }

            ctx.Donos.Update(DonoEscontrado);

            ctx.SaveChanges();
        }

        public Dono BuscarPorId(int id)
        {
            return ctx.Donos.Find(id);
        }

        public void Cadastrar(Dono NovoDono)
        {
            ctx.Donos.Add(NovoDono);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Donos.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Dono> ListarTodos()
        {
            return ctx.Donos.ToList();
        }
    }
}
