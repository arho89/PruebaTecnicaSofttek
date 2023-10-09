using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prueba.Tecnica.Libreria.Entity.Autor;
using Prueba.Tecnica.Libreria.Entity.Genero;
using Prueba.Tecnica.Libreria.Entity.Libro;
using System.Net;
using System.Text;

namespace Prueba.Tecnica.Libreria.Web.Controllers
{
    public class LibrosController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://localhost:7021/";

        public LibrosController(IHttpClientFactory httpClientFactory)
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
                var libros = await GetAsync<LibroDTO>("api/Libros");
                return View(libros);
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
                var generosTask = GetAsync<GeneroDTO>("api/Generos");
                var autoresTask = GetAsync<AutorDTO>("api/Autores");

                await Task.WhenAll(generosTask, autoresTask);

                ViewBag.Generos = generosTask.Result;
                ViewBag.Autores = autoresTask.Result;

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
        public async Task<ActionResult> Create(LibroDTO libroDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(libroDTO), Encoding.UTF8, "application/json");

                    var response = await _httpClient.PostAsync("api/Libros", jsonContent);

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

                var generosTask = GetAsync<GeneroDTO>("api/Generos");
                var autoresTask = GetAsync<AutorDTO>("api/Autores");

                await Task.WhenAll(generosTask, autoresTask);

                ViewBag.Generos = generosTask.Result;
                ViewBag.Autores = autoresTask.Result;

                return View(libroDTO);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(libroDTO);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var response = await _httpClient.DeleteAsync("api/Libros?id=" + id.ToString());

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, $"Error al eliminar el libro: {errorMessage}");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error al eliminar el libro.");
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}