namespace SigecomTestesUI2.Services.DbSetup
{
    public abstract class ConfigBackup : IConfigBackup
    {
        private readonly AcessoDB _acessoDB;
        private readonly Dictionary<string, string> _valoresOriginais = new();

        protected ConfigBackup(AcessoDB acessoDB)
        {
            _acessoDB = acessoDB;
        }

        protected abstract string Tabela { get; }
        protected virtual string Filtro => "";

        public void Salvar(string coluna)
        {
            if (_valoresOriginais.ContainsKey(coluna)) return;

            var where = string.IsNullOrEmpty(Filtro) ? "" : $" WHERE {Filtro}";
            var valor = _acessoDB
                .RealizarConsulta($"SELECT {coluna} FROM {Tabela}{where}")
                .Rows[0][0].ToString()!;

            _valoresOriginais[coluna] = valor;
        }

        public void RestaurarTudo()
        {
            var where = string.IsNullOrEmpty(Filtro) ? "" : $" WHERE {Filtro}";
            foreach (var (coluna, valor) in _valoresOriginais)
            {
                _acessoDB.ExecutarScript(
                    $"UPDATE {Tabela} SET {coluna} = '{valor}'{where}");
            }
            _valoresOriginais.Clear();
        }
    }
}
