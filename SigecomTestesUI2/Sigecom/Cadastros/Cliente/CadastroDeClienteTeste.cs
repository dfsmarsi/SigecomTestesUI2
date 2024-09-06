using SigecomTestesUI2.Pages.Cadastros.Pessoa;
using SigecomTestesUI2.Pages.Pesquisas;
using SigecomTestesUI2.Sigecom.Cadastros.Cliente.Model;

namespace SigecomTestesUI2.Sigecom.Cadastros.Cliente
{
    public class CadastroDeClienteTeste : TesteBase
    {
        [Test(Description = "Cadastro de cliente campos obrigatorios")]
        public void CadastroDeClienteCamposObrigatorios()
        {
            var pageCadastro = new CadastroDePessoaPage(Driver);
            var pagePesquisa = new PesquisaDePessoaPage(Driver);
            var clienteSimplesDados = new CadastroDeClienteSimplesModel();

            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu(Enum.TipoPessoa.Cliente);
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.ClicarNoBotaoNovoCadastroDePessoa();
            pageCadastro.PreencherCamposObrigatorios(clienteSimplesDados.Nome, clienteSimplesDados.Cidade, clienteSimplesDados.Estado);
            pageCadastro.GravarCadastroDePessoa();
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.AbrirPesquisaDePessoa();
            pagePesquisa.PesquisarPessoa(Enum.TipoPessoa.Cliente, clienteSimplesDados.Nome);
            Assert.IsTrue(pagePesquisa.VerificarSeExistePessoaNaGrid(clienteSimplesDados.Nome));
            pagePesquisa.FecharTelaDePesquisaDePessoa(Enum.TipoPessoa.Cliente);
            ManipuladorService.TrocarParaProximaJanela();
            pageCadastro.FecharTelaDeCadastroDePessoaEsc(Enum.TipoPessoa.Cliente);
        }

        [Test(Description = "Cadastro de cliente completo")]
        public void CadastroDeClienteCompleto()
        {
            var pageCadastro = new CadastroDePessoaPage(Driver);
            var pagePesquisa = new PesquisaDePessoaPage(Driver);
            var clienteCompletoModel = new CadastroDeClienteCompletoModel();

            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu(Enum.TipoPessoa.Cliente);
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.ClicarNoBotaoNovoCadastroDePessoa();
            pageCadastro.PreencherCadastroCompleto(clienteCompletoModel);
            pageCadastro.GravarCadastroDePessoa();
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.AbrirPesquisaDePessoa();
            pagePesquisa.PesquisarPessoa(Enum.TipoPessoa.Cliente, clienteCompletoModel.Nome);
            Assert.IsTrue(pagePesquisa.VerificarSeExistePessoaNaGrid(clienteCompletoModel.Nome));
            pagePesquisa.FecharTelaDePesquisaDePessoa(Enum.TipoPessoa.Cliente);
            ManipuladorService.TrocarParaProximaJanela();
            pageCadastro.FecharTelaDeCadastroDePessoaEsc(Enum.TipoPessoa.Cliente);
        }

        [Test(Description = "Cadastro de cliente pessoa juridica")]
        public void CadastroDeClientePessoaJuridica()
        {
            var pageCadastro = new CadastroDePessoaPage(Driver);
            var pagePesquisa = new PesquisaDePessoaPage(Driver);
            var clienteJuridicoDados = new CadastroDeClienteJuridicoModel();

            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu(Enum.TipoPessoa.Cliente);
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.ClicarNoBotaoNovoCadastroDePessoa();
            pageCadastro.SelecionarClassificacao(clienteJuridicoDados.PosicaoClassificacao);
            ManipuladorService.EsperarAcaoEmSegundos(1);
            pageCadastro.PreencherCadastroPessoaJuridica(clienteJuridicoDados.Cnpj);
            pageCadastro.VerificarCamposObrigatorios(clienteJuridicoDados.Nome, clienteJuridicoDados.Cidade, clienteJuridicoDados.Estado);
            pageCadastro.GravarCadastroDePessoa();
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.AbrirPesquisaDePessoa();
            pagePesquisa.PesquisarPessoa(Enum.TipoPessoa.Cliente, clienteJuridicoDados.Nome);
            Assert.IsTrue(pagePesquisa.VerificarSeExistePessoaNaGrid(clienteJuridicoDados.Nome));
            pagePesquisa.FecharTelaDePesquisaDePessoa(Enum.TipoPessoa.Cliente);
            ManipuladorService.TrocarParaProximaJanela();
            pageCadastro.FecharTelaDeCadastroDePessoaEsc(Enum.TipoPessoa.Cliente);
        }
    }
}
