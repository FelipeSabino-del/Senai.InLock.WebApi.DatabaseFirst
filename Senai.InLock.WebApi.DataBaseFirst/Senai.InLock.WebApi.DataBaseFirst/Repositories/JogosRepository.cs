using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(Jogos jogoAtualizado, int id)
        {
            // Busca um jogo através do id
            Jogos jogoBuscado = ctx.Jogos.Find(id);

            // Atribui os novos valores ao campos existentes
            if (jogoAtualizado.NomeJogo != null)
            {
                jogoBuscado.NomeJogo = jogoAtualizado.NomeJogo;
            }
            if (jogoAtualizado.Descricao != null)
            {
                jogoBuscado.Descricao = jogoAtualizado.Descricao;
            }
            if (jogoAtualizado.DataLancamento != null)
            {
                jogoBuscado.DataLancamento = jogoAtualizado.DataLancamento;
            }
            if (jogoAtualizado.Valor != jogoBuscado.Valor)
            {
                jogoBuscado.Valor = jogoAtualizado.Valor;
            }
            if (jogoAtualizado.IdEstudio != null)
            {
                jogoBuscado.IdEstudio = jogoAtualizado.IdEstudio;
            }

            ctx.Jogos.Update(jogoBuscado);
            ctx.SaveChanges();
        }

        public Jogos BuscarPorId(int id)
        {
            return ctx.Jogos.FirstOrDefault(e => e.IdJogo == id);
        }

        public void Cadastrar(Jogos novoJogo)
        {
            ctx.Jogos.Add(novoJogo);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Jogos jogoDeletado = ctx.Jogos.Find(id);
            ctx.Jogos.Remove(jogoDeletado);
            ctx.SaveChanges();
        }

        public List<Jogos> Listar()
        {
            return ctx.Jogos.ToList();
        }

        public List<Jogos> ListarUmEstudio(int id)
        {
            return ctx.Jogos.Include(e => e.IdEstudioNavigation).ToList().FindAll(j => j.IdEstudio == id);
        }

        public List<Jogos> ListarComEstudios()
        {
            return ctx.Jogos.Include(e => e.IdEstudioNavigation).ToList();
        }
    }
}
