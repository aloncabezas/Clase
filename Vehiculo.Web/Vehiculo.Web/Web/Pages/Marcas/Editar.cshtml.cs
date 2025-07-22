using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Marcas
{
    public class EditarModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public EditarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        [BindProperty]
        public MarcaResponse marcaResponse { get; set; }

        public async Task<IActionResult> OnGet(Guid? id)
        {
            if (id == null || id == Guid.Empty)
                return NotFound();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerMarca");
            using var cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(string.Format(endpoint, id));

            if (!respuesta.IsSuccessStatusCode)
                return NotFound();

            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            marcaResponse = JsonSerializer.Deserialize<MarcaResponse>(resultado, opciones);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "EditarMarca");

            using var cliente = new HttpClient();
            var respuesta = await cliente.PutAsJsonAsync(string.Format(endpoint, marcaResponse.Id), new MarcaRequest
            {
                Id = marcaResponse.Id,
                Nombre = marcaResponse.Nombre
            });

            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("./Index");
        }
    }
}
