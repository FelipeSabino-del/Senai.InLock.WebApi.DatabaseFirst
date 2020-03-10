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
    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogosRepository;

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogosRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_jogosRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Jogos novoEstudio)
        {
            _jogosRepository.Cadastrar(novoEstudio);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _jogosRepository.Deletar(id);

            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Jogos jogoAtualizado, int id)
        {
            _jogosRepository.Atualizar(jogoAtualizado, id);

            return NoContent();
        }

        [HttpGet("Estudios/{id}")]
        public IActionResult GetJogosEstudios(int id)
        {
            return Ok(_jogosRepository.ListarUmEstudio(id));
        }

        [HttpGet("Estudios")]
        public IActionResult GetEstudios()
        {
            return Ok(_jogosRepository.ListarComEstudios());
        }
        
    }
}