using SigecomTestesUI2.Services;

namespace SigecomTestesUI2.Pages.Vendas.Orcamento
{
    public class OrcamentoPage : PageBase
    {
        public OrcamentoPage(ManipuladorService manipuladorService) : base(manipuladorService)
        {
        }
        
        private const string TelaDeOrcamento = "Orçamento";
        private const string BotaoMenuVendas = "Vendas";
        private const string BotaoSubMenuOrcamento = "Orçamento";
        private const string LabelClienteId = "lblCliente";
        private const string LabelVendedorId = "lblVendedor";
        private const string CampoPesquisaDeProduto = "scProdutos";
        private const string CampoNomeProdutoNaGrid = "Descrição";
        private const string CampoQtdeProdutoNaGrid = "Qtde";
        private const string CampoTotalProdutoNaGrid = "Total";
        private const string BotaoAvancar = ", Avançar";
        private const string CampoTipoOrcamento = "cbxTipo";
        private const string CampoStatusOrcamento = "cbxStatus";
        private const string CampoObservacao = "txtObservação";

        public OrcamentoPage AbrirFluxoOrcamentoDock()
        {
            _manipuladorService.DarDuploCliqueNoBotaoName(BotaoMenuVendas);
            _manipuladorService.ClicarNoBotaoName(BotaoSubMenuOrcamento);
            _manipuladorService.EsperarElementoName(TelaDeOrcamento);
            _manipuladorService.TrocarParaProximaJanela();
            return new OrcamentoPage(_manipuladorService);
        }

        public void AbrirPesquisaDeCliente()
        {
            try
            {
                _manipuladorService.ClicarNoBotaoId(LabelClienteId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao clicar para abrir a pesquisa de cliente: {ex.Message}");
            }
        }

        public void DigitarNomeDoProdutoNaPesquisa(string nomeProdutoTestePadrao)
        {
            try
            {
                _manipuladorService.DigitarNoCampoIdEApertarEnter(CampoPesquisaDeProduto, nomeProdutoTestePadrao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao digitar o nome do produto na pesquisa: {ex.Message}");
            }
        }

        public void ConferirVendedorSelecionado(object nomeVendedor)
        {
            var vendedorSelecionado = _manipuladorService.ObterValorElementoId(LabelVendedorId);
            if (!vendedorSelecionado.Equals(nomeVendedor))
            {
                throw new Exception($"Vendedor selecionado ({vendedorSelecionado}) não corresponde ao esperado ({nomeVendedor}).");
            }
        }

        public void AlterarQtdeDoProdutoNaGrid(string qtde)
        {
            try
            {
                _manipuladorService.EditarItensNaGridComDuploClickComEnter(CampoQtdeProdutoNaGrid, qtde);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao alterar a quantidade do produto na grid: {ex.Message}");
            }
        }
    }
}
