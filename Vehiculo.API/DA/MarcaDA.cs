using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class MarcaDA : IMarcaDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlconnection;

        #region Constructor
        public MarcaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlconnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones
        public async Task<Guid> Agregar(MarcaRequest marca)
        {
            string query = @"AgregarMarca";
            var resultadoConsulta = await _sqlconnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                Nombre = marca.Nombre
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, MarcaRequest marca)
        {
            await VerificarMarcaExiste(Id);
            string query = @"EditarMarca";
            var resultadoConsulta = await _sqlconnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                Nombre = marca.Nombre
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await VerificarMarcaExiste(Id);
            string query = @"EliminarMarca";
            var resultadoConsulta = await _sqlconnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id
            });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<MarcaResponse>> Obtener()
        {
            string query = @"ObtenerMarcas";
            var resultadoConsulta = await _sqlconnection.QueryAsync<MarcaResponse>(query);
            return resultadoConsulta;
        }

        public async Task<MarcaResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerMarca";
            var resultadoConsulta = await _sqlconnection.QueryAsync<MarcaResponse>(query, new { Id = Id });
            return resultadoConsulta.FirstOrDefault();
        }
       
        #endregion

        #region Helpers
        private async Task VerificarMarcaExiste(Guid Id)
        {
            MarcaResponse? resultadoConsultaMarca = await Obtener(Id);
            if (resultadoConsultaMarca == null)
                throw new Exception("No se encontró la marca");
        }
        #endregion
    }
}

