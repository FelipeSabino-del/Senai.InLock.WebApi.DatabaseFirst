using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using Senai.InLock.WebApi.DataBaseFirst.Repositories;

namespace Senai.InLock.WebApi.DataBaseFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepository _estudioRepository;

        public EstudiosController()
        {
            _estudioRepository = new EstudiosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estudioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_estudioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Estudios novoEstudio)
        {
           _estudioRepository.Cadastrar(novoEstudio);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _estudioRepository.Deletar(id);

            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Estudios estudioAtualizado, int id)
        {
            _estudioRepository.Atualizar(estudioAtualizado, id);

            return NoContent();
        }

        [HttpGet("Jogos")]
        public IActionResult GetComJogos()
        {
            return Ok(_estudioRepository.ListarComJogos());
        }
    }
}