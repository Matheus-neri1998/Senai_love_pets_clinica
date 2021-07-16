using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface ITipoPetRepository
    {
        List<TipoPet> ListarTodos(); 
        
        TipoPet BuscarPorId(int id); 
        
        void Cadastrar(TipoPet NovoTipoPet); 
        
        void Deletar(int id); 
        
        void Atualizar(TipoPet NovoTipoPet, int id); 
    }
}
