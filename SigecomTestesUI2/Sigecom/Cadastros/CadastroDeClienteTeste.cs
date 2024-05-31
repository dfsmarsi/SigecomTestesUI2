using SigecomTestesUI2.Pages;

namespace SigecomTestesUI2.Sigecom.Cadastros
{
    public class CadastroDeClienteTeste : TesteBase
    {
        [Test(Description = "Cadastro de cliente campos obrigatorios")]
        public void CadastroDeClienteCamposObrigatorios()
        {
            var pageCadastro = new CadastroDeClientePage(Driver);
            var pagePesquisa = new PesquisaDePessoaPage(Driver);

            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu();
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.ClicarNoBotaoNovoCadastroDeCliente();
            pageCadastro.PreencherCamposObrigatorios("BRAIA", "Votuporanga", "São Paulo");
            pageCadastro.GravarCadastroDeCliente();
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.AbrirPesquisaDeCliente();
            pagePesquisa.PesquisarPessoa("cliente", "BRAIA");
            Assert.IsTrue(pagePesquisa.VerificarSeExistePessoaNaGrid("BRAIA"));
            pagePesquisa.FecharTelaDePesquisaDePessoa("cliente");
            ManipuladorService.TrocarParaProximaJanela();
            pageCadastro.FecharTelaDeCadastroDeClienteEsc();
        }
    }
}
