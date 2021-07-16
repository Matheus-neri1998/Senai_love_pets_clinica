using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        lovePetsContext ctx = new lovePetsContext();
        public void Atualizar(Veterinario NovoVeterinario, int id)
        {
            Veterinario VeterinarioEncontrado = BuscarPorId(id);

            if (NovoVeterinario.IdVeterinario > 0)
            {
                VeterinarioEncontrado.IdVeterinario = NovoVeterinario.IdVeterinario;
            }

            if (NovoVeterinario.IdClinica > 0)
            {
                VeterinarioEncontrado.IdClinica = NovoVeterinario.IdClinica;
            }

            if (NovoVeterinario.Crmv != null)
            {
                VeterinarioEncontrado.Crmv = NovoVeterinario.Crmv;
            }

            if (NovoVeterinario.NomeVeterinario != null)
            {
                VeterinarioEncontrado.NomeVeterinario = NovoVeterinario.NomeVeterinario;
            }

            if (NovoVeterinario.IdUsuario > 0)
            {
                VeterinarioEncontrado.IdUsuario = NovoVeterinario.IdUsuario;
            }

            ctx.Veterinarios.Update(VeterinarioEncontrado);

            ctx.SaveChanges();
        }

        public Veterinario BuscarPorId(int id)
        {
            return ctx.Veterinarios.Find(id);
        }

        public void Cadastrar(Veterinario NovoVeterinario)
        {
            ctx.Veterinarios.Add(NovoVeterinario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Veterinarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Veterinario> ListarTodos()
        {
            return ctx.Veterinarios.ToList();
        }
    }
}
