using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace SigecomTestesUI2
{
    class AcessoDB
    {
        private FbConnection _connection;
        const string connectionString = "User=SYSDBA;Password=masterkey;Database=localhost:C:\\SISTEMASBR\\BANCOS\\TESTES\\UI.fdb;DataSource=localhost;Charset=NONE;";

        public AcessoDB()
        {
            _connection = new FbConnection(connectionString);
        }

        public void Connect()
        {
            try
            {
                _connection.Open();
                Console.WriteLine("Conexão com o banco de dados estabelecida.");
            }
            catch (FbException e)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {e.Message}");
            }
        }

        public void Disconnect()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                Console.WriteLine("Conexão com o banco de dados fechada.");
            }
        }

        public void ExecutarScript(string script)
        {
            try
            {
                using (var command = new FbCommand(script, _connection))
                {
                    Connect();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Script executado com sucesso.");
                }
            }
            catch (FbException e)
            {
                Console.WriteLine($"Erro ao executar o script: {e.Message}");
            }
            finally
            {
                Disconnect();
            }
        }

        public DataTable RealizarConsulta(string script)
        {
            DataTable dataTable = new DataTable();
            try
            {
                Connect();
                using (var command = new FbCommand(script, _connection))
                {
                    FbDataAdapter adapter = new FbDataAdapter(command);
                    adapter.Fill(dataTable);
                    Console.WriteLine("Consulta realizada com sucesso.");
                }
            }
            catch (FbException e)
            {
                Console.WriteLine($"Erro ao realizar consulta: {e.Message}");
            }
            finally
            {
                Disconnect();
            }
            return dataTable;
        }
    }
}
