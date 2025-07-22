using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flujo
{
    public class ModeloFlujo : IModeloFlujo
    {
        private readonly IModeloDA _modeloDA;

        public ModeloFlujo(IModeloDA modeloDA)
        {
            _modeloDA = modeloDA;
        }

        public async Task<IEnumerable<ModeloResponse>> Obtener()
        {
            return await _modeloDA.Obtener();
        }

        public async Task<ModeloResponse> Obtener(Guid id) 
        {
            return await _modeloDA.Obtener(id);
        }

        public async Task<IEnumerable<ModeloResponse>> ObtenerPorMarca(Guid idMarca)
        {
            return await _modeloDA.ObtenerPorMarca(idMarca);
        }

        public async Task<Guid> Agregar(ModeloRequest modelo)
        {
            return await _modeloDA.Agregar(modelo);
        }

        public async Task<Guid> Editar(Guid id, ModeloRequest modelo)
        {
            return await _modeloDA.Editar(id, modelo);
        }

        public async Task<Guid> Eliminar(Guid id)
        {
            return await _modeloDA.Eliminar(id);
        }
    }
}
