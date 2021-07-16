using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        lovePetsContext ctx = new lovePetsContext();
        public void Atualizar(int id, Clinica NovaClinica)
        {
            Clinica ClinicaBuscada = BuscarPorId(id);

            if (NovaClinica.IdClinica > 0)
            {
                ClinicaBuscada.IdClinica = NovaClinica.IdClinica;
            }

            if (NovaClinica.Endereco != null)
            {
                ClinicaBuscada.Endereco = NovaClinica.Endereco;
            }

            if (NovaClinica.Cnpj != null)
            {
                ClinicaBuscada.Cnpj = NovaClinica.Cnpj;
            }

            if (NovaClinica.RazaoSocial != null)
            {
                ClinicaBuscada.RazaoSocial = NovaClinica.RazaoSocial;
            }

            ctx.Clinicas.Update(ClinicaBuscada);

            ctx.SaveChanges();

        }

        public Clinica BuscarPorId(int id)
        {
            return ctx.Clinicas.Find(id);
        }

        public void Cadastrar(Clinica NovaClinica)
        {
            ctx.Clinicas.Add(NovaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Clinicas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
