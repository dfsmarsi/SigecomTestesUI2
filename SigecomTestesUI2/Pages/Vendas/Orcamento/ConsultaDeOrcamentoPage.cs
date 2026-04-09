using SigecomTestesUI2.Services;

namespace SigecomTestesUI2.Pages.Vendas.Orcamento
{
    public class ConsultaDeOrcamentoPage : PageBase
    {
        public ConsultaDeOrcamentoPage(ManipuladorService manipuladorService) : base(manipuladorService)
        {
        }

        private const string BotaoMenuVendas = "Vendas";
        private const string BotaoSubMenuConsultarOrcamentos = "Consultar orçamentos";
        private const string TelaConsultaDeOrcamentos = "Consulta de orçamentos";
        private const string BotaoNovoOrcamento = "Novo orçamento";
        private const string BotaoAlterar = "Alterar";
        private const string BotaoFaturar = "Faturar";

        public OrcamentoPage AcessarTelaDeConsultaDeOrcamento()
        {
            _manipuladorService.ClicarNoBotaoName(BotaoMenuVendas);
            _manipuladorService.ClicarNoBotaoName(BotaoSubMenuConsultarOrcamentos);
            _manipuladorService.EsperarElementoName(TelaConsultaDeOrcamentos);
            return new OrcamentoPage(_manipuladorService);
        }

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
