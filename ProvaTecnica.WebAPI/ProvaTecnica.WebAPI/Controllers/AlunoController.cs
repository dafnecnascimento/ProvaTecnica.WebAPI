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
    public class AlunoController : ControllerBase
    {
        public readonly IEFCoreRepository _repository;

        public AlunoController(IEFCoreRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
        {
            try
            {
                var alunos = await _repository.GetAllAlunos(pageParams);
                Response.AddPagination(alunos.CurrentPage, alunos.PageSize, alunos.TotalCount, alunos.TotalPages);

                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var aluno = await _repository.GetAlunoById(id);
                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/<AlunoController>
        [HttpPost]
        public async Task<IActionResult> Post(Aluno aluno)
        {
            try
            {
                _repository.Add(aluno);

                if (await _repository.SaveChangeAsync())
                {
                    return Ok("Aluno inserido com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não foi possível inserir.");
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Aluno model)
        {
            try
            {
                var aluno = await _repository.GetAlunoById(id);

                if (aluno != null)
                {
                    _repository.Update(model);

                    if (await _repository.SaveChangeAsync())
                        return Ok("Aluno alterado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não foi possível alterar.");
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var aluno = await _repository.GetAlunoById(id);

                if (aluno != null)
                {
                    _repository.Delete(aluno);

                    if (await _repository.SaveChangeAsync())
                        return Ok("Aluno removido com sucesso!");
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
