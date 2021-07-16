using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IVeterinarioRepository
    {
        List<Veterinario> ListarTodos();

        Veterinario BuscarPorId(int id);

        void Cadastrar(Veterinario NovoVeterinario);

        void Deletar(int id);

        void Atualizar(Veterinario NovoVeterinario, int id);
    }
}
