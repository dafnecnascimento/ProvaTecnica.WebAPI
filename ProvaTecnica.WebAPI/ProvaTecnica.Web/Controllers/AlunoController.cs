using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PagedList;
using ProvaTecnica.Web.Helper;
using ProvaTecnica.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProvaTecnica.Web.Controllers
{
    public class AlunoController : Controller
    {
        BaseAPI _api = new BaseAPI();

        public async Task<IActionResult> Index(string nomeAluno)
        {
            List<Aluno> lstAlunos = new List<Aluno>();
            List<Aluno> lstAlunosResult = new List<Aluno>();
            Pagination pagination = new Pagination();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/aluno");

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                var page = res.Headers.GetValues("Pagination").FirstOrDefault();
                pagination = JsonConvert.DeserializeObject<Pagination>(page);
                lstAlunos = JsonConvert.DeserializeObject<List<Aluno>>(results);
            }

            if (!string.IsNullOrEmpty(nomeAluno))
                lstAlunosResult = lstAlunos.Where(l => l.NomeAluno.Contains(nomeAluno)).ToList();
            else
                lstAlunosResult = lstAlunos.ToList();

            return View(lstAlunosResult.ToPagedList(pagination.CurrentPage, pagination.ItemsPerPage));
        }

        public async Task<IActionResult> Details(int id)
        {
            var aluno = new Aluno();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/aluno/{id}");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                aluno = JsonConvert.DeserializeObject<Aluno>(result);
            }

            return View(aluno);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var aluno = new Aluno();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/aluno/{id}");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                aluno = JsonConvert.DeserializeObject<Aluno>(result);
            }

            return View(aluno);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Aluno aluno)
        {
            HttpClient client = _api.Initial();

            HttpResponseMessage res = await client.PutAsJsonAsync<Aluno>($"api/aluno/{aluno.IdAluno}", aluno);
                        
            if (res.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public IActionResult Create(Aluno aluno)
        {
            HttpClient client = _api.Initial();

            var post = client.PostAsJsonAsync<Aluno>("api/aluno", aluno);
            post.Wait();

            var result = post.Result;

            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var aluno = new Aluno();
            HttpClient client = _api.Initial();
            HttpResponseMessage responseMessage = await client.DeleteAsync($"api/aluno/{id}");

            return RedirectToAction("Index");
        }
    }
}
