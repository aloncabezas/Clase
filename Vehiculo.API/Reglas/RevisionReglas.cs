using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Revision;


namespace Reglas {
    public class RevisionReglas : IRevisionReglas
    {
        private readonly IRevisionServicio _revisionServicio;
        private readonly IConfiguracion _configuracion;

        public RevisionReglas(IRevisionServicio revisionServicio, IConfiguracion configuracion)
        {
            _revisionServicio = revisionServicio;
            _configuracion = configuracion;
        }

        public async Task<bool> RevisionEsValida(string placa)

        {
            var resultadoRevision = await _revisionServicio.Obtener(placa);
            if (ValidarEstado(resultadoRevision) && ValidarPeriodo(resultadoRevision.Periodo))

                return true;
                return false;
           

        }
        private bool ValidarEstado(Revision resultadoRevision)
        {
            string estadoRevision = _configuracion.ObtenerValor("EstadoRevisionSastifactorio");
            return resultadoRevision.Resultado == estadoRevision;

        }
        public static string ObtenerPeriodoActual()
        {
            return $"{DateTime.Now.Month}-{DateTime.Now.Year}";
        }
        private static bool ValidarPeriodo(string periodo)
        {
            var periodoActual = ObtenerPeriodoActual();
            return periodo == periodoActual;

        }
    }
}
