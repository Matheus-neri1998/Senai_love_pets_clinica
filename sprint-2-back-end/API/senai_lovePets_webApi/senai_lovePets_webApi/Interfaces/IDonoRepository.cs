using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IDonoRepository
    {
        List<Dono> ListarTodos();

        Dono BuscarPorId(int id);

        void Cadastrar(Dono NovoDono);

        void Deletar(int id);

        void Atualizar(Dono NovoDono, int id);
       
    }
}
