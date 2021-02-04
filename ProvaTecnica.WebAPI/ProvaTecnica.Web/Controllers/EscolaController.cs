using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProvaTecnica.Web.Helper;
using ProvaTecnica.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProvaTecnica.Web.Controllers
{
    public class EscolaController : Controller
    {
        BaseAPI _api = new BaseAPI();

        public async Task<IActionResult> Index()
        {
            List<Escola> lstEscolas = new List<Escola>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/escola");

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                lstEscolas = JsonConvert.DeserializeObject<List<Escola>>(results);
            }

            return View(lstEscolas);
        }

        public async Task<IActionResult> Details(int id)
        {
            var escola = new Escola();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/escola/{id}");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                escola = JsonConvert.DeserializeObject<Escola>(result);
            }

            return View(escola);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Escola escola)
        {
            HttpClient client = _api.Initial();

            var post = client.PostAsJsonAsync<Escola>("api/escola", escola);
            post.Wait();

            var result = post.Result;

            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var escola = new Escola();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/escola/{id}");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                escola = JsonConvert.DeserializeObject<Escola>(result);
            }

            return View(escola);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Escola escola)
        {
            HttpClient client = _api.Initial();

            HttpResponseMessage res = await client.PutAsJsonAsync<Escola>($"api/escola/{escola.IdEscola}", escola);

            if (res.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var escola = new Escola();
            HttpClient client = _api.Initial();
            HttpResponseMessage responseMessage = await client.DeleteAsync($"api/escola/{id}");

            return RedirectToAction("Index");
        }
    }
}
