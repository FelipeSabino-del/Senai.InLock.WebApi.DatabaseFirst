using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(Estudios estudioAtualizado, int id)
        {
            Estudios estudioBuscado = ctx.Estudios.Find(id);

            if (estudioAtualizado.NomeEstudio != null)
            {
                estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;
            }


            ctx.Update(estudioBuscado);
            ctx.SaveChanges();
        }

        public Estudios BuscarPorId(int id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudios novoEstudio)
        {
            ctx.Estudios.Add(novoEstudio);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Estudios estudioDeletado = ctx.Estudios.Find(id);
            ctx.Estudios.Remove(estudioDeletado);
            ctx.SaveChanges();
        }

        public List<Estudios> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public List<Estudios> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
