using SigecomTestesUI2.Pages.Cadastros.Pessoa;
using SigecomTestesUI2.Pages.Pesquisas;
using SigecomTestesUI2.Services.DbSetup;
using SigecomTestesUI2.Sigecom.Cadastros.Colaborador.Model;

namespace SigecomTestesUI2.Sigecom.Cadastros.Colaborador
{
    public class CadastroDeColaboradorTeste : TesteBase
    {
        [Test(Description = "Cadastro de colaborador campos obrigatorios")]
        public void CadastroDeColaboradorCamposObrigatorios()
        {
            var pageCadastro = new CadastroDePessoaPage(ManipuladorService);
            var pagePesquisa = new PesquisaDePessoaPage(ManipuladorService);
            var colaboradorSimplesDados = new CadastroDeColaboradorSimplesModel();

            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu(Enum.TipoPessoa.Colaborador);
            pageCadastro.ClicarNoBotaoNovoCadastroDePessoa();
            pageCadastro.PreencherCamposObrigatorios(colaboradorSimplesDados.Nome, colaboradorSimplesDados.Cidade, colaboradorSimplesDados.Estado);
            pageCadastro.GravarCadastroDePessoa();
            pageCadastro.AbrirPesquisaDePessoa();
            pagePesquisa.PesquisarPessoa(Enum.TipoPessoa.Colaborador, colaboradorSimplesDados.Nome);
            Assert.IsTrue(pagePesquisa.VerificarSeExistePessoaNaGrid(colaboradorSimplesDados.Nome));
            pagePesquisa.FecharTelaDePesquisaDePessoa(Enum.TipoPessoa.Colaborador);
            ManipuladorService.TrocarParaProximaJanela();
            pageCadastro.FecharTelaDeCadastroDePessoaEsc(Enum.TipoPessoa.Colaborador);
        }

        [Test(Description = "Cadastro de colaborador pessoa juridica")]
        public void CadastroDeColaboradorPessoaJuridica()
        {
            var pageCadastro = new CadastroDePessoaPage(ManipuladorService);
            var pagePesquisa = new PesquisaDePessoaPage(ManipuladorService);
            var colaboradorJuridicoDados = new CadastroDeColaboradorJuridicoModel();

            CadastroDbSetup.DesativarPessoaComCpfSeExistir(AcessoDB, colaboradorJuridicoDados.CnpjFormatado);

            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu(Enum.TipoPessoa.Colaborador);
            pageCadastro.ClicarNoBotaoNovoCadastroDePessoa();
            pageCadastro.SelecionarClassificacao(colaboradorJuridicoDados.PosicaoClassificacao);
            pageCadastro.PreencherCadastroPessoaJuridica(colaboradorJuridicoDados.Cnpj);
            Assert.IsTrue(pageCadastro.VerificarCamposObrigatorios(colaboradorJuridicoDados.Nome, colaboradorJuridicoDados.Cidade, colaboradorJuridicoDados.Estado));
            pageCadastro.GravarCadastroDePessoa();
            pageCadastro.AbrirPesquisaDePessoa();
            pagePesquisa.PesquisarPessoa(Enum.TipoPessoa.Colaborador, colaboradorJuridicoDados.Nome);
            Assert.IsTrue(pagePesquisa.VerificarSeExistePessoaNaGrid(colaboradorJuridicoDados.Nome));
            pagePesquisa.FecharTelaDePesquisaDePessoa(Enum.TipoPessoa.Colaborador);
            ManipuladorService.TrocarParaProximaJanela();
            pageCadastro.FecharTelaDeCadastroDePessoaEsc(Enum.TipoPessoa.Colaborador);
        }
    }
}
