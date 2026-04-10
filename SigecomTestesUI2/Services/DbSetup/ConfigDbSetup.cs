using System.Text.Json;
using System.Text.Json.Nodes;

namespace SigecomTestesUI2.Services.DbSetup
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

        public static void HabilitarFaturamentoDetalhado(AcessoDB acessoDB)
        {
            AlterarPropriedadeJson(acessoDB, "empresa_host_config", "geral_impressao",
                "FaturamentoRapido", true);
        }

        public static void DesabilitarFaturamentoDetalhado(AcessoDB acessoDB)
        {
            AlterarPropriedadeJson(acessoDB, "empresa_host_config", "geral_impressao",
                "FaturamentoRapido", false);
        }
    }
}
