using SigecomTestesUI2.Enum;
using SigecomTestesUI2.Pages.Pesquisas;
using SigecomTestesUI2.Pages.Vendas.Orcamento;
using SigecomTestesUI2.Services.DbSetup;
using SigecomTestesUI2.Sigecom.Vendas.Orcamento.Model;

namespace SigecomTestesUI2.Sigecom.Vendas.Orcamento
{
    public class OrcamentoTeste : TesteBase
    {
        private string? _configOriginal;

        [Test(Description = "Faturamento detalhado de orçamento")]
        public void FaturamentoDetalhadoDeOrcamento()
        {
            _configOriginal = ConfigDbSetup.ObterGeralImpressao(AcessoDB);
            ConfigDbSetup.HabilitarFaturamentoDetalhado(AcessoDB);
            var orcamentoModel = new OrcamentoTesteModel();
            
            // Reabrir o sistema para carregar a config alterada
            RelogarNoSistema();

            // Act
            var orcamentoPage = new OrcamentoPage(ManipuladorService).AbrirFluxoOrcamentoDock();
            
            orcamentoPage.AbrirPesquisaDeCliente();

            var pesquisaDeClientePage = new PesquisaDePessoaPage(ManipuladorService);
            pesquisaDeClientePage.PesquisarPessoaEConfirmar(TipoPessoa.Cliente, orcamentoModel.NomeCliente);

            orcamentoPage.ConferirVendedorSelecionado(orcamentoModel.NomeVendedor);
            orcamentoPage.DigitarNomeDoProdutoNaPesquisa(orcamentoModel.NomeProdutoTestePadrao);
            orcamentoPage.AlterarQtdeDoProdutoNaGrid("2");
            
        }

        [TearDown]
        public new void TearDown()
        {
            if (_configOriginal != null)
            {
                ConfigDbSetup.RestaurarGeralImpressao(AcessoDB, _configOriginal);
                _configOriginal = null;
            }
            base.TearDown();
        }
    }
}
