using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IPetRepository
    {
        List<Pet> ListarTodos();

        Pet BuscarPorId(int id);

        void Cadastrar(Pet NovoPet);

        void Deletar(int id);

        void Atualizar(Pet NovoPet, int id);
    }
}
