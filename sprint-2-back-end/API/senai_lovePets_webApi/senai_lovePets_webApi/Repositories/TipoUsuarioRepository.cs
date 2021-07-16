using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        lovePetsContext ctx = new lovePetsContext();
        public void Atualizar(TipoUsuario NovoTipoUsuario, int id)
        {
            TipoUsuario TipoUsuarioEncontrado = BuscarPorId(id);

            if (NovoTipoUsuario.IdTipoUsuario > 0)
            {
                TipoUsuarioEncontrado.IdTipoUsuario = NovoTipoUsuario.IdTipoUsuario;
            }

            if (NovoTipoUsuario.NomeTipoUsuario != null)
            {
                TipoUsuarioEncontrado.NomeTipoUsuario = NovoTipoUsuario.NomeTipoUsuario;
            }

            ctx.TipoUsuarios.Update(TipoUsuarioEncontrado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.Find(id);
        }

        public void Cadastrar(TipoUsuario NovoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(NovoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TipoUsuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodos()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
