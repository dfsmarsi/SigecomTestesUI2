using SigecomTestesUI2.Services;

namespace SigecomTestesUI2.Pages.Vendas.Orcamento
{
    public class OrcamentoPage : PageBase
    {
        public OrcamentoPage(ManipuladorService manipuladorService) : base(manipuladorService)
        {
        }

        private const string TelaDeOrcamentoName = "Orçamento";
        private const string BotaoMenuVendasName = "Vendas";
        private const string BotaoSubMenuOrcamentoName = "Orçamento";
        private const string LabelClienteId = "lblCliente";
        private const string LabelVendedorId = "lblVendedor";
        private const string CampoPesquisaDeProdutoId = "scProdutos";
        private const string CampoNomeProdutoNaGridName = "Descrição";
        private const string CampoQtdeProdutoNaGridName = "Qtde";
        private const string CampoTotalProdutoNaGridName = "Total";
        private const string BotaoAvancarName = ", Avançar";
        private const string CampoTipoOrcamentoId = "cbxTipo";
        private const string CampoStatusOrcamentoId = "cbxStatus";
        private const string CampoObservacaoId = "txtObservacao";
        private const string GridOpcaoConcluirOrcamentoId = "gridAcoes";
        private const string GridFormaPagamentoOrcamentoId = "gridFormasPagamento";

        public OrcamentoPage AbrirFluxoOrcamentoDock()
        {
            _manipuladorService.DarDuploCliqueNoBotaoName(BotaoMenuVendasName);
            _manipuladorService.ClicarNoBotaoName(BotaoSubMenuOrcamentoName);
            _manipuladorService.EsperarElementoName(TelaDeOrcamentoName);
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
                _manipuladorService.DigitarNoCampoIdEApertarEnter(CampoPesquisaDeProdutoId, nomeProdutoTestePadrao);
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
                _manipuladorService.EditarItensNaGridComDuploClickComEnter(CampoQtdeProdutoNaGridName, qtde);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao alterar a quantidade do produto na grid: {ex.Message}");
            }
        }

        public void ConferirQtdeDoProdutoNaGrid(string qtdeEsperada)
        {
            var qtdeNaGrid = _manipuladorService.PegarValorDaColunaDaGrid(CampoQtdeProdutoNaGridName);
            if (!qtdeNaGrid.Equals(qtdeEsperada))
            {
                throw new Exception($"Quantidade na grid ({qtdeNaGrid}) não corresponde à esperada ({qtdeEsperada}).");
            }
        }

        public string ObterValorTotalDoProdutoNaGrid()
        {
            return _manipuladorService.PegarValorDaColunaDaGrid(CampoTotalProdutoNaGridName);
        }

        public void AvancarParaProximaEtapa()
        {
            try
            {
                _manipuladorService.ClicarNoBotaoName(BotaoAvancarName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao avançar para a próxima etapa: {ex.Message}");
            }
        }

        public void SelecionarTipoOrcamento(int posicao)
        {
            try
            {
                _manipuladorService.SelecionarItemComboBoxSemEnter(CampoTipoOrcamentoId, posicao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao selecionar o tipo do orçamento: {ex.Message}");
            }
        }

        public void SelecionarStatusOrcamento(int posicao)
        {
            try
            {
                _manipuladorService.SelecionarItemComboBoxSemEnter(CampoStatusOrcamentoId, posicao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao selecionar o status do orçamento: {ex.Message}");
            }
        }

        public void DigitarObservacao(string observacao)
        {
            try
            {
                _manipuladorService.DigitarNoCampoId(CampoObservacaoId, observacao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao digitar a observação: {ex.Message}");
            }
        }

        public void ConcluirOrcamentoSemImpressao()
        {
            try
            {
                _manipuladorService.RealizarSelecaoDaAcao(GridOpcaoConcluirOrcamentoId, 2);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao concluir o orçamento sem impressão: {ex.Message}");
            }
        }

        public void FecharTelaDeOrcamentoComEsc(string nomeJanela)
        {
            try
            {
                _manipuladorService.FecharJanelaComEscName(nomeJanela);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao fechar tela do orçamento: {ex.Message}");
            }
        }

        internal void SelecionarPagamentoEmDinheiro()
        {
            try
            {
                _manipuladorService.RealizarSelecaoDaAcao(GridFormaPagamentoOrcamentoId, 1);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao selecionar pagamento em dinheiro: {ex.Message}");
            }
        }
    }
}
