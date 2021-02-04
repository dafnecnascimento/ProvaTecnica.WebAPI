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
    public class PerfilController : Controller
    {
        BaseAPI _api = new BaseAPI();

        public async Task<IActionResult> Index()
        {
            List<Perfil> lstPerfis = new List<Perfil>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/perfil");

            if(res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                lstPerfis = JsonConvert.DeserializeObject<List<Perfil>>(results);
            }

            return View(lstPerfis);
        }
    }
}
