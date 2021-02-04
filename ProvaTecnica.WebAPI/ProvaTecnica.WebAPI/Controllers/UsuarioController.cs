using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProvaTecnica.Dominio;
using ProvaTecnica.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProvaTecnica.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IEFCoreRepository _repository;

        public UsuarioController(IEFCoreRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuarios = await _repository.GetAllUsuarios();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var usuario = await _repository.GetUsuarioById(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            try
            {
                _repository.Add(usuario);

                if (await _repository.SaveChangeAsync())
                {
                    return Ok("Usuário inserido com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não foi possível inserir.");
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario model)
        {
            try
            {
                var usuario = await _repository.GetUsuarioById(id);

                if (usuario != null)
                {
                    _repository.Update(model);

                    if (await _repository.SaveChangeAsync())
                        return Ok("Usuário alterado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não foi possível alterar.");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuario = await _repository.GetUsuarioById(id);

                if (usuario != null)
                {
                    _repository.Delete(usuario);

                    if (await _repository.SaveChangeAsync())
                        return Ok("Usuário removido com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não foi possível remover.");
        }
    }
}
