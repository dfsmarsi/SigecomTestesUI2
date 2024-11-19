using OpenQA.Selenium.Appium.Windows;

namespace SigecomTestesUI2.Pages.Vendas.Orcamento
{
    public class OrcamentoPage : PageBase
    {
        public OrcamentoPage(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        private const string LabelCliente = "lblCliente";
        private const string LabelVendedor = "lblVendedor";
        private const string CampoPesquisaDeProduto = "scProduto";
        private const string CampoNomeProdutoNaGrid = "Descrição row ";
        private const string CampoQtdeProdutoNaGrid = "Qtde row ";
        private const string CampoTotalProdutoNaGrid = "Total row ";
        private const string BotaoAvancar = ", Avançar";
        private const string CampoTipoOrcamento = "cbxTipo";
        private const string CampoStatusOrcamento = "cbxStatus";
        private const string CampoObservacao = "txtObservação";
    }
}
