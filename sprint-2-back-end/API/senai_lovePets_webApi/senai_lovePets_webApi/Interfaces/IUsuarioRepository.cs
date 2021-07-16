using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();

        Usuario BuscarPorId(int id);

        void Cadastrar(Usuario NovoUsuario);

        void Deletar(int id);

        void Atualizar(Usuario NovoUsuario, int id);

        Usuario Login(string Email, string Senha);
    }
}
