using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    interface ITiposUsuariosRepository
    {
        List<TiposUsuarios> Listar();

        TiposUsuarios BuscarPorId(int id);

        void Cadastrar(TiposUsuarios novoTiposUsuarios);

        void Atualizar(TiposUsuarios tipoUsuarioAtualizado);

        void Deletar(TiposUsuarios tipoUsuarioDeletado);
    }
}
