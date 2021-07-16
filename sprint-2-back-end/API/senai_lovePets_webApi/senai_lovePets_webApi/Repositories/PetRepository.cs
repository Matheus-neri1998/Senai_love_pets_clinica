using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class PetRepository : IPetRepository
    {
        lovePetsContext ctx = new lovePetsContext();
        public void Atualizar(Pet NovoPet, int id)
        {
            Pet PetEncontrado = BuscarPorId(id);

            if (NovoPet.IdPet > 0)
            {
                PetEncontrado.IdPet = NovoPet.IdPet;
            }

            if (NovoPet.NomePet != null)
            {
                PetEncontrado.NomePet = NovoPet.NomePet;
            }

            if (NovoPet.IdRaca > 0)
            {
                PetEncontrado.IdRaca = NovoPet.IdRaca;
            }

            if (NovoPet.IdDono > 0)
            {
                PetEncontrado.IdDono = NovoPet.IdDono;
            }

            if (NovoPet.DataNascimento >= DateTime.Now)
            {
                PetEncontrado.DataNascimento = NovoPet.DataNascimento;
            }

            if (NovoPet.IdUsuario > 0)
            {
                PetEncontrado.IdUsuario = NovoPet.IdUsuario;
            }

            ctx.Pets.Update(PetEncontrado);

            ctx.SaveChanges();
        }

        public Pet BuscarPorId(int id)
        {
            return ctx.Pets.Find(id);
        }

        public void Cadastrar(Pet NovoPet)
        {
            ctx.Pets.Add(NovoPet);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Pets.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Pet> ListarTodos()
        {
            return ctx.Pets.ToList();
        }
    }
}
