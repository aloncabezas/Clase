using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.API
{
    public interface IModeloController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid id);
        Task<IActionResult> Agregar(ModeloRequest modelo);
        Task<IActionResult> Editar(Guid id, ModeloRequest modelo);
        Task<IActionResult> Eliminar(Guid id);
    }
}
