namespace SigecomTestesUI2.Services.DbSetup.Configuracao.Estacao
{
    public static class EstacaoOrcamentoDbSetup
    {
        public static void HabilitarFaturamentoDetalhado(AcessoDB acessoDB)
        {
            ConfigDbSetup.AlterarPropriedadeJson(acessoDB, "empresa_host_config", "geral_impressao",
                "FaturamentoRapido", true);
        }

        public static void DesabilitarFaturamentoDetalhado(AcessoDB acessoDB)
        {
            ConfigDbSetup.AlterarPropriedadeJson(acessoDB, "empresa_host_config", "geral_impressao",
                "FaturamentoRapido", false);
        }
    }
}
