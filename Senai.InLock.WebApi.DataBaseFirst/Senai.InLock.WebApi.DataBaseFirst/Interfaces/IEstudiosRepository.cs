using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    interface IEstudiosRepository
    {
        List<Estudios> Listar();

        Estudios BuscarPorId(int id);

        void Cadastrar(Estudios novoEstudio);

        void Atualizar(Estudios estudioAtualizado, int id);

        void Deletar(int id);

        List<Estudios> ListarComJogos();
    }
}
