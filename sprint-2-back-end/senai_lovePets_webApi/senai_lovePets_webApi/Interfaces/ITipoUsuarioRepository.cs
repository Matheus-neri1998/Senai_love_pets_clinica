using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {

        List<TipoUsuario> ListarTodos();

        TipoUsuario BuscarPorId(int id);

        void Cadastrar(TipoUsuario NovoTipoUsuario);

        void Deletar(int id);

        void Atualizar(TipoUsuario NovoTipoUsuario, int id);
    }
}
