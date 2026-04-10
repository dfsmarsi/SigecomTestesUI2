using SigecomTestesUI2.Enum;
using SigecomTestesUI2.Pages.Pesquisas;
using SigecomTestesUI2.Pages.Vendas.Orcamento;
using SigecomTestesUI2.Services.DbSetup;
using SigecomTestesUI2.Sigecom.Vendas.Orcamento.Model;

namespace SigecomTestesUI2.Sigecom.Vendas.Orcamento
{
    public class OrcamentoTeste : TesteBase
    {
        private IConfigBackup? _configBackup;

        [Test(Description = "Faturamento detalhado de orçamento")]
        public void FaturamentoDetalhadoDeOrcamento()
        {
            _configBackup = new EmpresaHostConfigBackup(AcessoDB);
            _configBackup.Salvar("geral_impressao");
            ConfigDbSetup.HabilitarFaturamentoDetalhado(AcessoDB);
            var orcamentoModel = new OrcamentoTesteModel();

            // Reabrir o sistema para carregar a config alterada
            RelogarNoSistema();

            // Criar orçamento
            var orcamentoPage = new OrcamentoPage(ManipuladorService).AbrirFluxoOrcamentoDock();

            orcamentoPage.AbrirPesquisaDeCliente();

            var pesquisaDeClientePage = new PesquisaDePessoaPage(ManipuladorService);
            pesquisaDeClientePage.PesquisarPessoaEConfirmar(TipoPessoa.Cliente, orcamentoModel.NomeCliente);

            orcamentoPage.ConferirVendedorSelecionado(orcamentoModel.NomeVendedor);
            orcamentoPage.DigitarNomeDoProdutoNaPesquisa(orcamentoModel.NomeProdutoTestePadrao);
            orcamentoPage.AlterarQtdeDoProdutoNaGrid(orcamentoModel.QtdeProduto);

            // Conferir quantidade e valor total do produto na grid
            orcamentoPage.ConferirQtdeDoProdutoNaGrid(orcamentoModel.QtdeProduto);
            var valorTotal = orcamentoPage.ObterValorTotalDoProdutoNaGrid();
            Assert.IsNotEmpty(valorTotal, "O valor total do produto não foi calculado.");

            // Avançar para informar tipo, status e observação
            orcamentoPage.AvancarParaProximaEtapa();
            orcamentoPage.SelecionarTipoOrcamento(orcamentoModel.PosicaoTipoOrcamento);
            orcamentoPage.SelecionarStatusOrcamento(orcamentoModel.PosicaoStatusOrcamento);
            orcamentoPage.DigitarObservacao(orcamentoModel.Observacao);

            // Avançar exibe os cards de ação, selecionar card 2 e concluir
            orcamentoPage.AvancarParaProximaEtapa();
            orcamentoPage.ConcluirOrcamentoSemImpressao();
            orcamentoPage.FecharTelaDeOrcamentoComEsc(orcamentoModel.TelaOrcamentoName);

            // Acessar tela de consulta de orçamentos
            var consultaPage = new ConsultaDeOrcamentoPage(ManipuladorService).AcessarTelaDeConsultaDeOrcamento();

            // Filtrar por observação no filtro avançado
            consultaPage.AbrirFiltroLateral();
            consultaPage.AbrirFiltroAvancado();
            consultaPage.PesquisarPorObservacao(orcamentoModel.Observacao);

            // Conferir se a observação na grid é a mesma do orçamento criado
            var observacaoNaGrid = consultaPage.ObterObservacaoDaGrid();
            Assert.AreEqual(orcamentoModel.Observacao, observacaoNaGrid,
                "A observação na grid não corresponde à do orçamento criado.");

            // Faturar o orçamento selecionado sem impressão
            consultaPage.SelecionarOrcamentoNaGrid(orcamentoModel.Observacao);
            consultaPage.FaturarOrcamentoSemImpressao();
            ManipuladorService.TrocarParaProximaJanela();
            orcamentoPage.AvancarParaProximaEtapa();
            orcamentoPage.ConcluirOrcamentoSemImpressao();
            orcamentoPage.SelecionarPagamentoEmDinheiro();

            ManipuladorService.EsperarSplashs();

            // Conferir se o status foi alterado para Faturado
            var statusAtual = consultaPage.ObterStatusDaGridAposFaturamento(orcamentoModel.Observacao);
            Assert.AreEqual(orcamentoModel.StatusAposFaturamento, statusAtual,
                "O status do orçamento não foi alterado após o faturamento.");

            consultaPage.FecharTelaDeConsultaDeOrcamentoComEsc(orcamentoModel.TelaDeConsultaName);
        }

        [TearDown]
        public new void TearDown()
        {
            try
            {
                _configBackup?.RestaurarTudo();
            }
            finally
            {
                base.TearDown();
            }
        }
    }
}
