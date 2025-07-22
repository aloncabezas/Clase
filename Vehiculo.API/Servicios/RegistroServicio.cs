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

namespace Servicios
{
    
   public class RegistroServicio : IRegistroServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;
        public RegistroServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
        }

        public async Task<Propietario> Obtener(string placa) 
        {
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsRegistro",
                "ObtenerPropietario");
            var servicioRegistro=_httpClient.CreateClient("ServicioRegistro");
            var respuesta = await servicioRegistro.GetAsync(string.Format
                (endPoint,placa));
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones= new JsonSerializerOptions { PropertyNameCaseInsensitive
                = true
            };
            var resultadoDeserializado = 
                JsonSerializer.Deserialize<List<Propietario>>(resultado, opciones);
            return resultadoDeserializado?.FirstOrDefault();
                
        }
    }
}
