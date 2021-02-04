using Microsoft.AspNetCore.Mvc;
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
    public class EscolaController : ControllerBase
    {
        public readonly IEFCoreRepository _repository;

        public EscolaController(IEFCoreRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<EscolaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var escolas = await _repository.GetAllEscolas();
                return Ok(escolas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<EscolaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var escola = await _repository.GetEscolaById(id);
                return Ok(escola);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/<EscolaController>
        [HttpPost]
        public async Task<IActionResult> Post(Escola escola)
        {
            try
            {
                _repository.Add(escola);

                if (await _repository.SaveChangeAsync())
                {
                    return Ok("Escola inserida com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não foi possível inserir.");
        }

        // PUT api/<EscolaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Escola model)
        {
            try
            {
                var escola = await _repository.GetEscolaById(id);

                if (escola != null)
                {
                    _repository.Update(model);

                    if (await _repository.SaveChangeAsync())
                        return Ok("Escola alterada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não foi possível alterar.");
        }

        // DELETE api/<EscolaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var escola = await _repository.GetEscolaById(id);

                if (escola != null)
                {
                    _repository.Delete(escola);

                    if (await _repository.SaveChangeAsync())
                        return Ok("Escola removida com sucesso!");
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
