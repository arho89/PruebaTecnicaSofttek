using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prueba.Tecnica.Libreria.Entity.Autor;
using System.Net;
using System.Text;

namespace Prueba.Tecnica.Libreria.Web.Controllers
{
    public class AutoresController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://localhost:7021/";

        public AutoresController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_apiBaseUrl);
        }

        private async Task<List<T>> GetAsync<T>(string apiEndpoint)
        {
            var response = await _httpClient.GetAsync(apiEndpoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(content);
            }
            else
            {
                throw new Exception($"Error al obtener los datos desde {apiEndpoint}");
            }
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var autores = await GetAsync<AutorDTO>("api/Autores");
                return View(autores);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        public async Task<ActionResult> Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AutorDTO autorDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(autorDTO), Encoding.UTF8, "application/json");

                    var response = await _httpClient.PostAsync("api/Autores", jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, $"Error al crear el libro: {errorMessage}");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error al crear el libro.");
                    }
                }

                return View(autorDTO);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(autorDTO);
            }
        }
    }
}
