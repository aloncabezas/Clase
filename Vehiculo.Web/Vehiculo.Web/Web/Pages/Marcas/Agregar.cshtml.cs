using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using System.Text.Json;

namespace Web.Pages.Marcas
{
    public class AgregarModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public AgregarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        [BindProperty]
        public MarcaRequest marca { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "AgregarMarca");
            using var cliente = new HttpClient();
            var respuesta = await cliente.PostAsJsonAsync(endpoint, marca);
            respuesta.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}
