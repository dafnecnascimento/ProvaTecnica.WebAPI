using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProvaTecnica.Web.Helper;
using ProvaTecnica.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Web.Controllers
{
    public class TurmaController : Controller
    {
        BaseAPI _api = new BaseAPI();

        public async Task<IActionResult> Index()
        {
            List<Turma> lstTurmas = new List<Turma>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/turma");
           
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                lstTurmas = JsonConvert.DeserializeObject<List<Turma>>(results);
            }

            return View(lstTurmas);
        }

        public async Task<IActionResult> Details(int id)
        {
            var turma = new Turma();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/turma/{id}");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                turma = JsonConvert.DeserializeObject<Turma>(result);
            }

            //Média das Notas dos Alunos por Turma
            turma.MediaNotas = (turma.Alunos.Sum(a => a.NotaAluno)) / turma.Alunos.Count();

            return View(turma);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Turma turma)
        {
            HttpClient client = _api.Initial();

            var post = client.PostAsJsonAsync<Turma>("api/turma", turma);
            post.Wait();

            var result = post.Result;

            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var turma = new Turma();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/turma/{id}");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                turma = JsonConvert.DeserializeObject<Turma>(result);
            }

            return View(turma);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Turma turma)
        {
            HttpClient client = _api.Initial();

            HttpResponseMessage res = await client.PutAsJsonAsync<Turma>($"api/turma/{turma.IdTurma}", turma);

            if (res.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var turma = new Turma();
            HttpClient client = _api.Initial();
            HttpResponseMessage responseMessage = await client.DeleteAsync($"api/turma/{id}");

            return RedirectToAction("Index");
        }
    }
}
