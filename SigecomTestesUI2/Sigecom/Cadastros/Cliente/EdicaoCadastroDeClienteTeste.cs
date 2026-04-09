using SigecomTestesUI2.Pages.Cadastros.Pessoa;
using SigecomTestesUI2.Pages.Pesquisas;
using SigecomTestesUI2.Services.DbSetup;
using SigecomTestesUI2.Sigecom.Cadastros.Cliente.Model;

namespace SigecomTestesUI2.Sigecom.Cadastros.Cliente
{
    public class EdicaoCadastroDeClienteTeste : TesteBase
    {
        [Test(Description = "Edição de cadastro de cliente somente campos obrigatórios")]
        public void EdicaoCadastroDeClienteCamposObrigatorios()
        {
            var dados = new EdicaoCadastroDeClienteModel();

            CadastroDbSetup.GarantirClienteExistePorNome(AcessoDB, dados.NomeOriginalCliente);

            var pageCadastro = new CadastroDePessoaPage(ManipuladorService);
            var pagePesquisa = new PesquisaDePessoaPage(ManipuladorService);

            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu(Enum.TipoPessoa.Cliente);
            pageCadastro.AbrirPesquisaDePessoa();
            pagePesquisa.PesquisarPessoaEConfirmar(Enum.TipoPessoa.Cliente, dados.NomeOriginalCliente);
            Assert.That(pageCadastro.RetornarClassificacaoPessoa(), Is.EqualTo(dados.ClassificacaoPessoaFisica));
            Assert.IsTrue(pageCadastro.VerificarCamposObrigatorios(dados.NomeOriginalCliente, dados.CidadeOriginalCliente, dados.EstadoOriginalCliente));
            pageCadastro.PreencherCamposObrigatorios(dados.NomeAlteradoCliente, dados.CidadeAlteradaCliente, dados.EstadoAlteradoCliente);
            Assert.IsTrue(pageCadastro.VerificarCamposObrigatorios(dados.NomeAlteradoCliente, dados.CidadeAlteradaCliente, dados.EstadoAlteradoCliente));
            pageCadastro.GravarCadastroDePessoa();
            pageCadastro.AbrirPesquisaDePessoa();
            pagePesquisa.PesquisarPessoa(Enum.TipoPessoa.Cliente, dados.NomeAlteradoCliente);
            Assert.IsTrue(pagePesquisa.VerificarSeExistePessoaNaGrid(dados.NomeAlteradoCliente));
            pagePesquisa.FecharTelaDePesquisaDePessoa(Enum.TipoPessoa.Cliente);
            pageCadastro.FecharTelaDeCadastroDePessoaEsc(Enum.TipoPessoa.Cliente);
        }
    }
}
