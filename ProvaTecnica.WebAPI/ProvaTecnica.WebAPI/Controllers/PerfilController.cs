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
    public class PerfilController : ControllerBase
    {
        public readonly IEFCoreRepository _repository;

        public PerfilController(IEFCoreRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<PerfilController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var perfis = await _repository.GetAllPerfis();
                return Ok(perfis);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<PerfilController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var perfil = await _repository.GetPerfilById(id);
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/<PerfilController>
        [HttpPost]
        public async Task<IActionResult> Post(Perfil perfil)
        {
            try
            {
                _repository.Add(perfil);

                if(await _repository.SaveChangeAsync())
                {
                    return Ok("Perfil inserido com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não foi possível inserir.");
        }

        // PUT api/<PerfilController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Perfil model)
        {
            try
            {
                var perfil = await _repository.GetPerfilById(id);

                if (perfil != null)
                {
                    _repository.Update(model);

                    if (await _repository.SaveChangeAsync())
                        return Ok("Perfil alterado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não foi possível alterar.");
        }

        // DELETE api/<PerfilController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var perfil = await _repository.GetPerfilById(id);

                if(perfil != null)
                {
                    _repository.Delete(perfil);

                    if (await _repository.SaveChangeAsync())
                        return Ok("Perfil removido com sucesso!");
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
