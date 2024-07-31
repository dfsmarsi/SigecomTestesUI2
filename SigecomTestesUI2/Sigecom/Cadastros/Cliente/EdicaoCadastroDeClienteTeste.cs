using SigecomTestesUI2.Pages.Cadastros.Pessoa;
using SigecomTestesUI2.Pages.Pesquisas;
using SigecomTestesUI2.Sigecom.Cadastros.Cliente.Model;

namespace SigecomTestesUI2.Sigecom.Cadastros.Cliente
{
    public class EdicaoCadastroDeClienteTeste : TesteBase
    {

        [Test(Description = "Edição de cadastro de cliente somente campos obrigatórios")]
        public void EdicaoCadastroDeClienteCamposObrigatorios()
        {
            var dados = new EdicaoCadastroDeClienteModel();

            var db = new AcessoDB();
            var consulta = db.RealizarConsulta($"SELECT * FROM pessoa WHERE nome = '{dados.nomeOriginalCliente}' AND codigotipo = 1;");
            if (consulta.Rows.Count == 0)
            {
                db.ExecutarScript(dados.scriptCadastrarClienteSomenteCamposObrigatorios);
            }

            var pageCadastro = new CadastroDePessoaPage(Driver);
            var pagePesquisa = new PesquisaDePessoaPage(Driver);
            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu(Enum.TipoPessoa.Cliente);
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.AbrirPesquisaDePessoa();
            pagePesquisa.PesquisarPessoaEConfirmar(Enum.TipoPessoa.Cliente, dados.nomeOriginalCliente);
            Assert.AreEqual(dados.classificacaoPessoaFisica, pageCadastro.RetornarClassificacaoPessoa());
            pageCadastro.VerificarCamposObrigatorios(dados.nomeOriginalCliente, dados.cidadeOriginalCliente, dados.estadoOriginalCliente);
            pageCadastro.PreencherCamposObrigatorios(dados.nomeAlteradoCliente, dados.cidadeAlteradaCliente, dados.estadoAlteradoCliente);
            pageCadastro.VerificarCamposObrigatorios(dados.nomeAlteradoCliente, dados.cidadeAlteradaCliente, dados.estadoAlteradoCliente);
            pageCadastro.GravarCadastroDePessoa();
            pageCadastro.AbrirPesquisaDePessoa();
            pagePesquisa.PesquisarPessoa(Enum.TipoPessoa.Cliente, dados.nomeAlteradoCliente);
            Assert.IsTrue(pagePesquisa.VerificarSeExistePessoaNaGrid(dados.nomeAlteradoCliente));
            pagePesquisa.FecharTelaDePesquisaDePessoa(Enum.TipoPessoa.Cliente);
            pageCadastro.FecharTelaDeCadastroDePessoaEsc(Enum.TipoPessoa.Cliente);
        }
    }
}
