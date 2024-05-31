using SigecomTestesUI2.Pages;

namespace SigecomTestesUI2.Sigecom.Cadastros
{
    public class EdicaoCadastroDeClienteTeste : TesteBase
    {

        [Test(Description = "Edição de cadastro de cliente somente campos obrigatórios")]
        public void EdicaoCadastroDeClienteCamposObrigatorios()
        {
            var dados = new EdicaoCadastroDeClienteDados();

            var db = new AcessoDB();
            var consulta = db.RealizarConsulta($"SELECT * FROM pessoa WHERE nome = '{dados.nomeOriginalCliente}' AND codigotipo = 1;");
            if (consulta.Rows.Count == 0)
            {
                db.ExecutarScript(dados.scriptCadastrarClienteSomenteCamposObrigatorios);
            }

            var pageCadastro = new CadastroDeClientePage(Driver);
            var pagePesquisa = new PesquisaDePessoaPage(Driver);
            pageCadastro.AcessarItemMenu();
            pageCadastro.AcessarItemSubMenu();
            ManipuladorService.EsperarAcaoEmSegundos(2);
            pageCadastro.AbrirPesquisaDeCliente();
            pagePesquisa.PesquisarPessoaEConfirmar("cliente", dados.nomeOriginalCliente);
            Assert.AreEqual(dados.tipoPessoaFisica, pageCadastro.RetornarTipoPessoa());
            pageCadastro.VerificarCamposObrigatorios(dados.nomeOriginalCliente, dados.cidadeOriginalCliente, dados.estadoOriginalCliente);
            pageCadastro.PreencherCamposObrigatorios(dados.nomeAlteradoCliente, dados.cidadeAlteradaCliente, dados.estadoAlteradoCliente);
            pageCadastro.VerificarCamposObrigatorios(dados.nomeAlteradoCliente, dados.cidadeAlteradaCliente, dados.estadoAlteradoCliente);
            pageCadastro.GravarCadastroDeCliente();
            pageCadastro.AbrirPesquisaDeCliente();
            pagePesquisa.PesquisarPessoa("cliente", dados.nomeAlteradoCliente);
            Assert.IsTrue(pagePesquisa.VerificarSeExistePessoaNaGrid(dados.nomeAlteradoCliente));
            pagePesquisa.FecharTelaDePesquisaDePessoa("cliente");
            pageCadastro.FecharTelaDeCadastroDeClienteEsc();
        }
    }
}
