using System;
using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class MarcaBase
    {
        [Required(ErrorMessage = "El nombre de la marca es requerido")]
        [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres")]
        [StringLength(50, ErrorMessage = "El nombre debe tener menos de 50 caracteres")]
        public string Nombre { get; set; }
    }

    public class MarcaRequest : MarcaBase
    {
    }

    public class MarcaResponse : MarcaBase
    {
        public Guid Id { get; set; }
    }
}

