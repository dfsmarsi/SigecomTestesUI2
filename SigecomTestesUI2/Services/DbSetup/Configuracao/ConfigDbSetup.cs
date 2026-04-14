using System.Text.Json;
using System.Text.Json.Nodes;

namespace SigecomTestesUI2.Services.DbSetup.Configuracao
{
    public static class ConfigDbSetup
    {
        public static void AlterarPropriedadeJson(AcessoDB acessoDB, string tabela, string coluna,
            string propriedade, JsonNode valor, string? filtro = null)
        {
            var where = string.IsNullOrEmpty(filtro) ? "" : $" WHERE {filtro}";
            var jsonAtual = acessoDB
                .RealizarConsulta($"SELECT {coluna} FROM {tabela}{where}")
                .Rows[0][0].ToString()!;

            var json = JsonNode.Parse(jsonAtual)!;
            json[propriedade] = valor;
            var jsonAtualizado = json.ToJsonString(new JsonSerializerOptions { WriteIndented = false });

            acessoDB.ExecutarScript(
                $"UPDATE {tabela} SET {coluna} = '{jsonAtualizado}'{where}");
        }

        public static bool VerificarPropriedadeJson(AcessoDB acessoDB, string tabela, string coluna,
            string propriedade, JsonNode valorEsperado, string? filtro = null)
        {
            var where = string.IsNullOrEmpty(filtro) ? "" : $" WHERE {filtro}";
            var jsonAtual = acessoDB
                .RealizarConsulta($"SELECT {coluna} FROM {tabela}{where}")
                .Rows[0][0].ToString()!;

            var json = JsonNode.Parse(jsonAtual)!;
            var valorAtual = json[propriedade];

            return valorAtual is not null &&
                   valorAtual.ToJsonString() == valorEsperado.ToJsonString();
        }

    }
}
