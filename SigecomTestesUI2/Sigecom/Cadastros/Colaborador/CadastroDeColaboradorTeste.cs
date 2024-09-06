using SigecomTestesUI2.Pages.Cadastros.Pessoa;
using SigecomTestesUI2.Pages.Pesquisas;
using SigecomTestesUI2.Sigecom.Cadastros.Cliente.Model;
using SigecomTestesUI2.Sigecom.Cadastros.Colaborador.Model;

namespace SigecomTestesUI2.Sigecom.Cadastros.Colaborador
{
    public class CadastroDeColaboradorTeste : TesteBase
    {
        [Test(Description = "Cadastro de colaborador campos obrigatorios")]
        public void CadastroDeColaboradorCamposObrigatorios()
        {
            var pageCadastro = new CadastroDePessoaPage(Driver);
            var pagePesquisa = new PesquisaDePessoaPage(Driver);
            var colaboradorSimplesDados = new CadastroDeColaboradorSimplesModel();

            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu(Enum.TipoPessoa.Colaborador);
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.ClicarNoBotaoNovoCadastroDePessoa();
            pageCadastro.PreencherCamposObrigatorios(colaboradorSimplesDados.Nome, colaboradorSimplesDados.Cidade, colaboradorSimplesDados.Estado);
            pageCadastro.GravarCadastroDePessoa();
            ManipuladorService.EsperarAcaoEmSegundos(2);
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
            var pageCadastro = new CadastroDePessoaPage(Driver);
            var pagePesquisa = new PesquisaDePessoaPage(Driver);
            var colaboradorJuridicoDados = new CadastroDeColaboradorJuridicoModel();

            var db = new AcessoDB();
            var consulta = db.RealizarConsulta(colaboradorJuridicoDados.ScriptPesquisaColaboradorPeloCnpj);
            if (consulta.Rows.Count > 0)
            {
                db.ExecutarScript(colaboradorJuridicoDados.ScriptDesativarColaboradorRepetido);
            }

            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu(Enum.TipoPessoa.Colaborador);
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.ClicarNoBotaoNovoCadastroDePessoa();
            pageCadastro.SelecionarClassificacao(colaboradorJuridicoDados.PosicaoClassificacao);
            ManipuladorService.EsperarAcaoEmSegundos(1);
            pageCadastro.PreencherCadastroPessoaJuridica(colaboradorJuridicoDados.Cnpj);
            pageCadastro.VerificarCamposObrigatorios(colaboradorJuridicoDados.Nome, colaboradorJuridicoDados.Cidade, colaboradorJuridicoDados.Estado);
            pageCadastro.GravarCadastroDePessoa();
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.AbrirPesquisaDePessoa();
            pagePesquisa.PesquisarPessoa(Enum.TipoPessoa.Colaborador, colaboradorJuridicoDados.Nome);
            Assert.IsTrue(pagePesquisa.VerificarSeExistePessoaNaGrid(colaboradorJuridicoDados.Nome));
            pagePesquisa.FecharTelaDePesquisaDePessoa(Enum.TipoPessoa.Colaborador);
            ManipuladorService.TrocarParaProximaJanela();
            pageCadastro.FecharTelaDeCadastroDePessoaEsc(Enum.TipoPessoa.Colaborador);
        }
    }
}
