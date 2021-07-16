using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IRacaRepository
    {
        List<Raca> ListarTodos(); 

        Raca BuscarPorId(int id); 

        void Cadastrar(Raca NovaRaca); 

        void Deletar(int id); 

        void Atualizar(Raca NovaRaca, int id); 
    }
}
