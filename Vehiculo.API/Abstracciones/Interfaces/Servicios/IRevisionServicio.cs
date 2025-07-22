using Abstracciones.Modelos.Revision;

namespace Abstracciones.Interfaces.Servicios
{
    public interface IRevisionServicio
    {
       public Task<Revision> Obtener(string placa);
    }
}
