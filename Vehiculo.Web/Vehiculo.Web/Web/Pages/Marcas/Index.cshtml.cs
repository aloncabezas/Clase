using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abstracciones.Interfaces.Reglas;
using System.Net;
using Abstracciones.Modelos;
using System.Text.Json;

namespace Web.Pages.Marcas
{
    public class IndexModel : PageModel
    {
        private IConfiguracion _configuracion;
        public IList<Marca> marcas { get; set; } = default!;

        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task OnGet()
        {
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerMarcas");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);

            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                marcas = JsonSerializer.Deserialize<List<Marca>>(resultado, opciones);
            }
        }
    }
}