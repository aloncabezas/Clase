using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IModeloFlujo
    {
        Task<IEnumerable<ModeloResponse>> Obtener();
        Task<ModeloResponse> Obtener(Guid id);
        Task<IEnumerable<ModeloResponse>> ObtenerPorMarca(Guid idMarca);
        Task<Guid> Agregar(ModeloRequest modelo);
        Task<Guid> Editar(Guid id, ModeloRequest modelo);
        Task<Guid> Eliminar(Guid id);
    }
}
