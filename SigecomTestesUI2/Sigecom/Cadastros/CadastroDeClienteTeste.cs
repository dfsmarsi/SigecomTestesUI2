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
            var clienteSimplesDados = new CadastroDeClienteSimplesDados();

            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu();
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.ClicarNoBotaoNovoCadastroDeCliente();
            pageCadastro.PreencherCamposObrigatorios(clienteSimplesDados.nome, clienteSimplesDados.cidade, clienteSimplesDados.estado);
            pageCadastro.GravarCadastroDeCliente();
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.AbrirPesquisaDeCliente();
            pagePesquisa.PesquisarPessoa("cliente", clienteSimplesDados.nome);
            Assert.IsTrue(pagePesquisa.VerificarSeExistePessoaNaGrid(clienteSimplesDados.nome));
            pagePesquisa.FecharTelaDePesquisaDePessoa("cliente");
            ManipuladorService.TrocarParaProximaJanela();
            pageCadastro.FecharTelaDeCadastroDeClienteEsc();
        }

        [Test(Description = "Cadastro de cliente completo")]
        public void CadastroDeClienteCompleto()
        {
            var pageCadastro = new CadastroDeClientePage(Driver);
            var pagePesquisa = new PesquisaDePessoaPage(Driver);
            var clienteCompletoDados = new CadastroDeClienteCompletoDados();

            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu();
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.ClicarNoBotaoNovoCadastroDeCliente();
            pageCadastro.PreencherCadastroCompleto(clienteCompletoDados);
            pageCadastro.GravarCadastroDeCliente();
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.AbrirPesquisaDeCliente();
            pagePesquisa.PesquisarPessoa("cliente", clienteCompletoDados.nome);
            Assert.IsTrue(pagePesquisa.VerificarSeExistePessoaNaGrid(clienteCompletoDados.nome));
            pagePesquisa.FecharTelaDePesquisaDePessoa("cliente");
            ManipuladorService.TrocarParaProximaJanela();
            pageCadastro.FecharTelaDeCadastroDeClienteEsc();
        }

        [Test(Description = "Cadastro de cliente pessoa juridica")]
        public void CadastroDeClientePessoaJuridica()
        {
            var pageCadastro = new CadastroDeClientePage(Driver);
            var pagePesquisa = new PesquisaDePessoaPage(Driver);
            var clienteJuridicoDados = new CadastroDeClienteJuridicoDados();

            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu();
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.ClicarNoBotaoNovoCadastroDeCliente();
            pageCadastro.SelecionarClassificacao(clienteJuridicoDados.posicaoClassificacao);
            ManipuladorService.EsperarAcaoEmSegundos(1);
            pageCadastro.PreencherCadastroPessoaJuridica(clienteJuridicoDados.cnpj);
            pageCadastro.VerificarCamposObrigatorios(clienteJuridicoDados.nome, clienteJuridicoDados.cidade, clienteJuridicoDados.estado);
            pageCadastro.GravarCadastroDeCliente();
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.AbrirPesquisaDeCliente();
            pagePesquisa.PesquisarPessoa("cliente", clienteJuridicoDados.nome);
            Assert.IsTrue(pagePesquisa.VerificarSeExistePessoaNaGrid(clienteJuridicoDados.nome));
            pagePesquisa.FecharTelaDePesquisaDePessoa("cliente");
            ManipuladorService.TrocarParaProximaJanela();
            pageCadastro.FecharTelaDeCadastroDeClienteEsc();
        }
    }
}
