namespace SigecomTestesUI2.Services.DbSetup
{
    public static class ConfigDbSetup
    {
        private const string ScriptFaturamentoDetalhado = "update empresa_host_config set geral_impressao = '{\"ImpressaoDeColunasEmOsOrcamentoPedido\":0,\"ConfiguracaoDeColunasNaImpressaoTermica\":0,\"ImpressoraTermicaPadrao\":\"\",\"EtiquetadoraPadrao\":\"\",\"ExibirNomeInteiroDoProdutoNaImpressao\":false,\"FaturamentoRapido\":true}'";
        private const string ScriptFaturamentoNormal = "update empresa_host_config set geral_impressao = '{\"ImpressaoDeColunasEmOsOrcamentoPedido\":0,\"ConfiguracaoDeColunasNaImpressaoTermica\":0,\"ImpressoraTermicaPadrao\":\"\",\"EtiquetadoraPadrao\":\"\",\"ExibirNomeInteiroDoProdutoNaImpressao\":false,\"FaturamentoRapido\":false}'";

        public static string ObterGeralImpressao(AcessoDB acessoDB)
        {
            return acessoDB.RealizarConsulta("SELECT geral_impressao FROM empresa_host_config").Rows[0][0].ToString()!;
        }

        public static void HabilitarFaturamentoDetalhado(AcessoDB acessoDB)
        {
            acessoDB.ExecutarScript(ScriptFaturamentoDetalhado);
        }

        public static void DesabilitarFaturamentoDetalhado(AcessoDB acessoDB)
        {
            acessoDB.ExecutarScript(ScriptFaturamentoNormal);
        }

        public static void RestaurarGeralImpressao(AcessoDB acessoDB, string valorOriginal)
        {
            acessoDB.ExecutarScript($"UPDATE empresa_host_config SET geral_impressao = '{valorOriginal}'");
        }
    }
}
