using OpenQA.Selenium.Appium.Windows;

namespace SigecomTestesUI2.Pages.Vendas.Orcamento
{
    public class ConsultaDeOrcamentoPage : PageBase
    {
        public ConsultaDeOrcamentoPage(WindowsDriver<WindowsElement> driver) : base(driver)
        {            
        }

        private const string BotaoMenuVendas = "Vendas";
        private const string BotaoSubMenuConsultarOrcamentos = "Consultar orçamentos";
        private const string TelaConsultaDeOrcamentos = "Consulta de orçamentos";
        private const string BotaoNovoOrcamento = "Novo orçamento";
        private const string BotaoAlterar = "Alterar";
        private const string BotaoFaturar = "Faturar";

        public bool RealizarNovoOrçamento(string valorDoItem)
        {
            try
            {
                _manipuladorService.ClicarNoBotaoName(BotaoNovoOrcamento);
                _manipuladorService.TrocarParaProximaJanela();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
