using SigecomTestesUI2.Pages.Cadastros.Pessoa;
using SigecomTestesUI2.Pages.Pesquisas;
using SigecomTestesUI2.Services.DbSetup.Cadastros;
using SigecomTestesUI2.Sigecom.Cadastros.Cliente.Model;

namespace SigecomTestesUI2.Sigecom.Cadastros.Cliente
{
    public class CadastroDeClienteTeste : TesteBase
    {
        [Test(Description = "Cadastro de cliente campos obrigatorios")]
        public void CadastroDeClienteCamposObrigatorios()
        {
            var pageCadastro = new CadastroDePessoaPage(ManipuladorService);
            var pagePesquisa = new PesquisaDePessoaPage(ManipuladorService);
            var clienteSimplesDados = new CadastroDeClienteSimplesModel();

            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu(Enum.TipoPessoa.Cliente);
            pageCadastro.ClicarNoBotaoNovoCadastroDePessoa();
            ManipuladorService.EsperarAteQue(() => ManipuladorService.VerificarSePossuiOValorNaTela("Cadastro de clientes"));
            pageCadastro.PreencherCamposObrigatorios(clienteSimplesDados.Nome, clienteSimplesDados.Cidade, clienteSimplesDados.Estado);
            pageCadastro.GravarCadastroDePessoa();
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
            var pageCadastro = new CadastroDePessoaPage(ManipuladorService);
            var pagePesquisa = new PesquisaDePessoaPage(ManipuladorService);
            var clienteCompletoModel = new CadastroDeClienteCompletoModel();

            CadastroDbSetup.GarantirGrupoDeDescontoExiste(AcessoDB, "grupo teste", 15.00m);

            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu(Enum.TipoPessoa.Cliente);
            pageCadastro.ClicarNoBotaoNovoCadastroDePessoa();
            ManipuladorService.EsperarAteQue(() => ManipuladorService.VerificarSePossuiOValorNaTela("Cadastro de clientes"));
            pageCadastro.PreencherCadastroCompleto(clienteCompletoModel);
            pageCadastro.GravarCadastroDePessoa();
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
            var pageCadastro = new CadastroDePessoaPage(ManipuladorService);
            var pagePesquisa = new PesquisaDePessoaPage(ManipuladorService);
            var clienteJuridicoDados = new CadastroDeClienteJuridicoModel();

            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu(Enum.TipoPessoa.Cliente);
            pageCadastro.ClicarNoBotaoNovoCadastroDePessoa();
            ManipuladorService.EsperarAteQue(() => ManipuladorService.VerificarSePossuiOValorNaTela("Cadastro de clientes"));
            pageCadastro.SelecionarClassificacao(clienteJuridicoDados.PosicaoClassificacao);
            pageCadastro.PreencherCadastroPessoaJuridica(clienteJuridicoDados.Cnpj);
            Assert.IsTrue(pageCadastro.VerificarCamposObrigatorios(clienteJuridicoDados.Nome, clienteJuridicoDados.Cidade, clienteJuridicoDados.Estado));
            pageCadastro.GravarCadastroDePessoa();
            pageCadastro.AbrirPesquisaDePessoa();
            pagePesquisa.PesquisarPessoa(Enum.TipoPessoa.Cliente, clienteJuridicoDados.Nome);
            Assert.IsTrue(pagePesquisa.VerificarSeExistePessoaNaGrid(clienteJuridicoDados.Nome));
            pagePesquisa.FecharTelaDePesquisaDePessoa(Enum.TipoPessoa.Cliente);
            ManipuladorService.TrocarParaProximaJanela();
            pageCadastro.FecharTelaDeCadastroDePessoaEsc(Enum.TipoPessoa.Cliente);
        }
    }
}
