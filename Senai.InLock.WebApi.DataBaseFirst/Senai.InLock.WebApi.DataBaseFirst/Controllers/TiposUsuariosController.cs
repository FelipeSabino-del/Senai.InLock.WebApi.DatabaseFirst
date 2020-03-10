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
    public class TiposUsuariosController : ControllerBase
    {
        private ITiposUsuariosRepository _tiposUsuariosRepository;

        public TiposUsuariosController()
        {
            _tiposUsuariosRepository = new TiposUsuariosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tiposUsuariosRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tiposUsuariosRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(TiposUsuarios novoEstudio)
        {
            _tiposUsuariosRepository.Cadastrar(novoEstudio);
            return StatusCode(201);
        }
    }
}