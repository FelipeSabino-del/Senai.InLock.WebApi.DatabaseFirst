using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class TiposUsuariosRepository : ITiposUsuariosRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(TiposUsuarios tipoUsuarioAtualizado)
        {
            ctx.TiposUsuarios.Update(tipoUsuarioAtualizado);
            ctx.SaveChanges();
        }

        public TiposUsuarios BuscarPorId(int id)
        {
            return ctx.TiposUsuarios.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastrar(TiposUsuarios novoTiposUsuarios)
        {
            ctx.TiposUsuarios.Add(novoTiposUsuarios);
            ctx.SaveChanges();
        }

        public void Deletar(TiposUsuarios tipoUsuarioDeletado)
        {
            ctx.TiposUsuarios.Remove(tipoUsuarioDeletado);
            ctx.SaveChanges();
        }

        public List<TiposUsuarios> Listar()
        {
            return ctx.TiposUsuarios.ToList();
        }
    }
}
