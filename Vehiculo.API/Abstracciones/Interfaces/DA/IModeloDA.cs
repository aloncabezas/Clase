using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IModeloDA
    {
        Task<IEnumerable<ModeloResponse>> Obtener();
        Task<IEnumerable<ModeloResponse>> ObtenerPorMarca(Guid idMarca);
        Task<ModeloResponse> Obtener(Guid id);
        Task<Guid> Agregar(ModeloRequest modelo);
        Task<Guid> Editar(Guid id, ModeloRequest modelo);
        Task<Guid> Eliminar(Guid id);
    }
}
