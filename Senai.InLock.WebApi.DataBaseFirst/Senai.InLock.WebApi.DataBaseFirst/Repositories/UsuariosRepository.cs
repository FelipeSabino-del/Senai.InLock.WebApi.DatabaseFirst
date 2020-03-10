using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(Usuarios usuarioAtualizado)
        {
            ctx.Usuarios.Update(usuarioAtualizado);
            ctx.SaveChanges();
        }

        public Usuarios BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastrar(Usuarios novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(Usuarios usuarioDeletado)
        {
            ctx.Usuarios.Remove(usuarioDeletado);
            ctx.SaveChanges();
        }

        public List<Usuarios> Listar()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
