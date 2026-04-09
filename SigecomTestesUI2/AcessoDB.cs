using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace SigecomTestesUI2
{
    public class AcessoDB : IDisposable
    {
        private FbConnection? _connection;

        public AcessoDB()
        {
            _connection = new FbConnection(Configuracao.Instancia["Database:ConnectionString"]);
        }

        public void ExecutarScript(string script)
        {
            _connection!.Open();
            try
            {
                using var command = new FbCommand(script, _connection);
                command.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
        }

        public DataTable RealizarConsulta(string script)
        {
            var dataTable = new DataTable();
            _connection!.Open();
            try
            {
                using var command = new FbCommand(script, _connection);
                var adapter = new FbDataAdapter(command);
                adapter.Fill(dataTable);
            }
            finally
            {
                _connection.Close();
            }
            return dataTable;
        }

        public void Dispose()
        {
            _connection?.Dispose();
            _connection = null;
        }
    }
}
