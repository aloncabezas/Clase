using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using Abstracciones.Modelos.Revision;

namespace Servicios
{

    public class RevisionServicio : IRevisionServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;
        public RevisionServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
        }

        public async Task<Revision> Obtener(string placa)
        {
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsRevision",
                "ObtenerRevision");
            var servicioRegistro = _httpClient.CreateClient("ServicioRevision");
            var respuesta = await servicioRegistro.GetAsync(string.Format
                (endPoint, placa));
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive
                = true
            };
            var resultadoDeserializado =
                JsonSerializer.Deserialize<List<Revision>>
                (resultado, opciones);
            return resultadoDeserializado?.FirstOrDefault();

        }
    }
}