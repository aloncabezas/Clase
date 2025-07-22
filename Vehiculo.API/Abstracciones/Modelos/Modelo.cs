using System;
using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class ModeloBase
    {
        [Required(ErrorMessage = "El nombre del modelo es requerido")]
        [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres")]
        [StringLength(100, ErrorMessage = "El nombre debe tener menos de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La marca del modelo es requerida")]
        public Guid IdMarca { get; set; }
    }

    public class ModeloRequest : ModeloBase
    {
    }

    public class ModeloResponse : ModeloBase
    {
        public Guid Id { get; set; }
    }
}
