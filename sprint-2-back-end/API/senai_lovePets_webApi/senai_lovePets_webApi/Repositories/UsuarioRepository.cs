using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        lovePetsContext ctx = new lovePetsContext();
        public void Atualizar(Usuario NovoUsuario, int id)
        {
            Usuario NovoUsuarioEncontrado = BuscarPorId(id);

            if (NovoUsuario.IdUsuario > 0)
            {
                NovoUsuarioEncontrado.IdUsuario = NovoUsuario.IdUsuario;
            }

            if (NovoUsuario.IdTipoUsuario > 0)
            {
                NovoUsuarioEncontrado.IdTipoUsuario = NovoUsuario.IdTipoUsuario;
            }

            if (NovoUsuario.Email != null)
            {
                NovoUsuarioEncontrado.Email = NovoUsuario.Email;
            }

            if (NovoUsuario.Senha != null)
            {
                NovoUsuarioEncontrado.Senha = NovoUsuario.Senha;
            }

            ctx.Usuarios.Update(NovoUsuarioEncontrado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario NovoUsuario)
        {
            ctx.Usuarios.Add(NovoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string Email, string Senha)
        {
            // Retorna o usuário encontrado através do email e da senha
            return ctx.Usuarios.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);
        }
    }
}
