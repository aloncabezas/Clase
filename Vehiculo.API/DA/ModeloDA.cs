using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DA
{
    public class ModeloDA : IModeloDA
    {
        private readonly IRepositorioDapper _repositorioDapper;
        private readonly SqlConnection _sqlConnection;

        #region Constructor
        public ModeloDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }
        #endregion

        #region Operaciones

        public async Task<Guid> Agregar(ModeloRequest modelo)
        {
            string query = "AgregarModelo";
            var idNuevo = Guid.NewGuid();

            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(
                query,
                new
                {
                    Id = idNuevo,
                    Nombre = modelo.Nombre,
                    IdMarca = modelo.IdMarca
                },
                commandType: CommandType.StoredProcedure);

            return resultado;
        }

        public async Task<Guid> Editar(Guid id, ModeloRequest modelo)
        {
            await VerificarModeloExiste(id);

            string query = "EditarModelo";

            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(
                query,
                new
                {
                    Id = id,
                    Nombre = modelo.Nombre,
                    IdMarca = modelo.IdMarca
                },
                commandType: CommandType.StoredProcedure);

            return resultado;
        }

        public async Task<Guid> Eliminar(Guid id)
        {
            await VerificarModeloExiste(id);

            string query = "EliminarModelo";

            var resultado = await _sqlConnection.ExecuteScalarAsync<Guid>(
                query,
                new { Id = id },
                commandType: CommandType.StoredProcedure);

            return resultado;
        }

        public async Task<IEnumerable<ModeloResponse>> Obtener()
        {
            string query = "ObtenerModelos";

            var resultado = await _sqlConnection.QueryAsync<ModeloResponse>(
                query,
                commandType: CommandType.StoredProcedure);

            return resultado;
        }

        public async Task<ModeloResponse> Obtener(Guid id) 
        {
            string query = "ObtenerModelo";

            var resultado = await _sqlConnection.QueryFirstOrDefaultAsync<ModeloResponse>(
                query,
                new { Id = id },
                commandType: CommandType.StoredProcedure);

            return resultado;
        }

        public async Task<IEnumerable<ModeloResponse>> ObtenerPorMarca(Guid idMarca)
        {
            string query = "ObtenerModelosPorMarca";

            var resultado = await _sqlConnection.QueryAsync<ModeloResponse>(
                query,
                new { IdMarca = idMarca },
                commandType: CommandType.StoredProcedure);

            return resultado;
        }

        #endregion

        #region Helpers

        private async Task VerificarModeloExiste(Guid id)
        {
            var modelo = await Obtener(id);
            if (modelo == null)
                throw new Exception("No se encontró el modelo.");
        }

        #endregion
    }
}
