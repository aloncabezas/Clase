using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase, IModeloController
    {
        private readonly IModeloFlujo _modeloFlujo;
        private readonly ILogger<ModeloController> _logger;

        public ModeloController(IModeloFlujo modeloFlujo, ILogger<ModeloController> logger)
        {
            _modeloFlujo = modeloFlujo;
            _logger = logger;
        }

        #region Operaciones

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] ModeloRequest modelo)
        {
            var resultado = await _modeloFlujo.Agregar(modelo);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id, [FromBody] ModeloRequest modelo)
        {
            if (!await VerificarModeloExiste(Id))
                return NotFound("El modelo no existe");

            var resultado = await _modeloFlujo.Editar(Id, modelo);
            return Ok(resultado);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid Id)
        {
            if (!await VerificarModeloExiste(Id))
                return NotFound("El modelo no existe");

            var resultado = await _modeloFlujo.Eliminar(Id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _modeloFlujo.Obtener();
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid Id)
        {
            var resultado = await _modeloFlujo.Obtener(Id);
            return Ok(resultado);
        }

        [HttpGet("PorMarca/{IdMarca}")]
        public async Task<IActionResult> ObtenerPorMarca([FromRoute] Guid IdMarca)
        {
            var resultado = await _modeloFlujo.ObtenerPorMarca(IdMarca);
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        #endregion Operaciones

        #region Helpers

        private async Task<bool> VerificarModeloExiste(Guid Id)
        {
            var resultadoValidacion = false;
            var resultadoModeloExiste = await _modeloFlujo.Obtener(Id);
            if (resultadoModeloExiste != null)
                resultadoValidacion = true;

            return resultadoValidacion;
        }

        #endregion Helpers
    }
}
