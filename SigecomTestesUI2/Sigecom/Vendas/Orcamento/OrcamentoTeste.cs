using SigecomTestesUI2.Pages.Login;
using SigecomTestesUI2.Sigecom.Vendas.Orcamento.Model;

namespace SigecomTestesUI2.Sigecom.Vendas.Orcamento
{
    public class OrcamentoTeste : TesteBase 
    {
        [Test(Description = "Faturamento detalhado de orçamento")]
        public void FaturamentoDetalhadoDeOrcamento() 
        {
            var dados = new FaturamentoDetalhadoOrcamentoModel();
            var db = new AcessoDB();
            db.ExecutarScript(dados.ScriptHabilitarFaturamentoDetalhado);

            //reabrir o sistema para carregar a config alterada
            RealizarSairLogin();
            ManipuladorService.EsperarAcaoEmSegundos(1);
            var login = new LoginPage(Driver);
            login.RealizarLogin();


            //fazer metodo na page que grava um novo orçamento, passando valor por parametro

            db.ExecutarScript(dados.ScriptDesabilitarFaturamentoDetalhado);
        }
    }
}
