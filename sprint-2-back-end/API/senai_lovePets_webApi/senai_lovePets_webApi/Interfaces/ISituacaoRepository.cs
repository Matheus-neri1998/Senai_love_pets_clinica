using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface ISituacaoRepository
    {
        List<Situacao> ListarTodos(); 
        
        Situacao BuscarPorId(int id); 
        
        void Cadastrar(Situacao NovaSituacao); 
        
        void Deletar(int id); 
        
        void Atualizar(Situacao NovaSituacao, int id);
    }
}
