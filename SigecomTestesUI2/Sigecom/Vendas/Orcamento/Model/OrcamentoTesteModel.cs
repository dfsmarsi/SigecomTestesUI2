namespace SigecomTestesUI2.Sigecom.Vendas.Orcamento.Model
{
    public class OrcamentoTesteModel
    {
        public string NomeCliente => "BRAIA";
        public string NomeProdutoTestePadrao => "PRODUTO TESTE PADRAO";
        public string NomeVendedor => "(F3) - Teste ui - qa";
        public string QtdeProduto => "2,00";
        public string Observacao { get; } = $"TESTE_UI_{DateTime.Now:yyyyMMddHHmmss}";
        public int PosicaoTipoOrcamento => 1;
        public int PosicaoStatusOrcamento => 1;
        public string StatusAposFaturamento => "APROVADO";
        public string TelaOrcamentoName => "Orçamento";
        public string TelaDeConsultaName => "Consulta de orçamentos";
    }
}
