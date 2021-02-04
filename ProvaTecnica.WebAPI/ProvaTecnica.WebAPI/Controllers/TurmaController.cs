using Microsoft.AspNetCore.Mvc;
using ProvaTecnica.Dominio;
using ProvaTecnica.Dominio.Helpers;
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
    public class TurmaController : ControllerBase
    {
        public readonly IEFCoreRepository _repository;

        public TurmaController(IEFCoreRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<TurmaController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            try
            {
                var turmas = await _repository.GetAllTurmas(pageParams);
                Response.AddPagination(turmas.CurrentPage, turmas.PageSize, turmas.TotalCount, turmas.TotalPages);
                return Ok(turmas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<TurmaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var turma = await _repository.GetTurmaById(id);
                return Ok(turma);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/<TurmaController>
        [HttpPost]
        public async Task<IActionResult> Post(Turma turma)
        {
            try
            {
                _repository.Add(turma);

                if (await _repository.SaveChangeAsync())
                {
                    return Ok("Turma inserida com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não foi possível inserir.");
        }

        // PUT api/<TurmaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Turma model)
        {
            try
            {
                var turma = await _repository.GetTurmaById(id);

                if (turma != null)
                {
                    _repository.Update(model);

                    if (await _repository.SaveChangeAsync())
                        return Ok("Turma alterada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não foi possível alterar.");
        }

        // DELETE api/<TurmaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var turma = await _repository.GetUsuarioById(id);

                if (turma != null)
                {
                    _repository.Delete(turma);

                    if (await _repository.SaveChangeAsync())
                        return Ok("Turma removida com sucesso!");
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
