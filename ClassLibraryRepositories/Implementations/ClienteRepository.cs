using ClassLibraryRepositories.Contracts;
using ClassLibraryUtilities.Contracts;
using ClassLibraryEntities;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibraryRepositories.Implementations
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMConfiguration _IMConfiguration;

        public ClienteRepository(IMConfiguration MConfiguration)
        {
            _IMConfiguration = MConfiguration ?? throw new ArgumentNullException(nameof(MConfiguration));
        }

        public IEnumerable<Cliente> ObtenerCliente(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int32);

            SqlConnection conn = new SqlConnection(_IMConfiguration.GetClienteStrCon());
            return conn.Query<Cliente>("CCLPR_GetCliente", parameters, commandType: CommandType.StoredProcedure);
        }

        public void InsertCliente(Cliente cli)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", cli.Id, DbType.Int32);
            parameters.Add("Nombre", cli.Nombre, DbType.String);
            parameters.Add("Apellido", cli.Apellido, DbType.String);

            SqlConnection conn = new SqlConnection(_IMConfiguration.GetClienteStrCon());
            conn.Query("CCLPR_InsertCliente", parameters, commandType: CommandType.StoredProcedure);
        }

        public void UpdateCliente(Cliente cli)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", cli.Id, DbType.Int32);
            parameters.Add("Nombre", cli.Nombre, DbType.String);
            parameters.Add("Apellido", cli.Apellido, DbType.String);

            SqlConnection conn = new SqlConnection(_IMConfiguration.GetClienteStrCon());
            conn.Query("CCLPR_UpdateCliente", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}