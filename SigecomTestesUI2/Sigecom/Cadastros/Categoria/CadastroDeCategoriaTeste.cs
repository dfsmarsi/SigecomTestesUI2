using SigecomTestesUI2.Pages.Cadastros.Categoria;
using SigecomTestesUI2.Services.DbSetup;
using SigecomTestesUI2.Sigecom.Cadastros.Categoria.Model;

namespace SigecomTestesUI2.Sigecom.Cadastros.Categoria
{
    public class CadastroDeCategoriaTeste : TesteBase
    {
        [Test(Description = "Cadastro de categoria somente campos obrigatorios - Balanca")]
        public void CadastroDeCategoriaSomenteCamposObrigatorios()
        {
            var page = new CadastroDeCategoriaPage(ManipuladorService);
            var dados = new CadastroDeCategoriaBalancaModel();
            CadastroDbSetup.LimparCategoriaPorNome(AcessoDB, dados.Nome);

            page.AcessarItemMenu();
            page.AcessarSubMenuCategorias();
            page.AbrirNovaCategoriaForm();
            page.PreencherCamposBase(dados.Nome, dados.Markup, dados.PosicaoTipo);
            page.AtivarToggleBalanca();
            page.GravarCategoria();
            page.VoltarParaListaComEsc();
            page.PesquisarCategoria(dados.Nome);
            Assert.IsTrue(page.VerificarCategoriaNaGrid(dados.Nome));
            page.FecharTela();

            CadastroDbSetup.LimparCategoriaPorNome(AcessoDB, dados.Nome);
        }

        [Test(Description = "Cadastro de categoria Combustivel")]
        public void CadastroDeCategoriaCombustivel()
        {
            var page = new CadastroDeCategoriaPage(ManipuladorService);
            var dados = new CadastroDeCategoriaCombustivelModel();
            CadastroDbSetup.LimparCategoriaPorNome(AcessoDB, dados.Nome);

            page.AcessarItemMenu();
            page.AcessarSubMenuCategorias();
            page.AbrirNovaCategoriaForm();
            page.PreencherCamposBase(dados.Nome, dados.Markup, dados.PosicaoTipo);
            page.AtivarToggleCombustivel();
            page.GravarCategoria();
            page.VoltarParaListaComEsc();
            page.PesquisarCategoria(dados.Nome);
            Assert.IsTrue(page.VerificarCategoriaNaGrid(dados.Nome));
            page.FecharTela();

            CadastroDbSetup.LimparCategoriaPorNome(AcessoDB, dados.Nome);
        }

        [Test(Description = "Cadastro de categoria Grade")]
        public void CadastroDeCategoriaGrade()
        {
            var page = new CadastroDeCategoriaPage(ManipuladorService);
            var dados = new CadastroDeCategoriaGradeModel();
            CadastroDbSetup.LimparCategoriaPorNome(AcessoDB, dados.Nome);

            page.AcessarItemMenu();
            page.AcessarSubMenuCategorias();
            page.AbrirNovaCategoriaForm();
            page.PreencherCamposBase(dados.Nome, dados.Markup, dados.PosicaoTipo);
            page.AtivarToggleGrade();
            page.AdicionarCaracteristicaDaGrade(dados.PosicaoCaracteristica1);
            page.AdicionarCaracteristicaDaGrade(dados.PosicaoCaracteristica2);
            page.GravarCategoria();
            page.VoltarParaListaComEsc();
            page.PesquisarCategoria(dados.Nome);
            Assert.IsTrue(page.VerificarCategoriaNaGrid(dados.Nome));
            page.FecharTela();

            CadastroDbSetup.LimparCategoriaPorNome(AcessoDB, dados.Nome);
        }

        [Test(Description = "Cadastro de categoria IMEI")]
        public void CadastroDeCategoriaImei()
        {
            var page = new CadastroDeCategoriaPage(ManipuladorService);
            var dados = new CadastroDeCategoriaImeiModel();
            CadastroDbSetup.LimparCategoriaPorNome(AcessoDB, dados.Nome);

            page.AcessarItemMenu();
            page.AcessarSubMenuCategorias();
            page.AbrirNovaCategoriaForm();
            page.PreencherCamposBase(dados.Nome, dados.Markup, dados.PosicaoTipo);
            page.AtivarToggleImei();
            page.GravarCategoria();
            page.VoltarParaListaComEsc();
            page.PesquisarCategoria(dados.Nome);
            Assert.IsTrue(page.VerificarCategoriaNaGrid(dados.Nome));
            page.FecharTela();

            CadastroDbSetup.LimparCategoriaPorNome(AcessoDB, dados.Nome);
        }

        [Test(Description = "Cadastro de categoria Medicamento")]
        public void CadastroDeCategoriaMedicamento()
        {
            var page = new CadastroDeCategoriaPage(ManipuladorService);
            var dados = new CadastroDeCategoriaMedicamentoModel();
            CadastroDbSetup.LimparCategoriaPorNome(AcessoDB, dados.Nome);

            page.AcessarItemMenu();
            page.AcessarSubMenuCategorias();
            page.AbrirNovaCategoriaForm();
            page.PreencherCamposBase(dados.Nome, dados.Markup, dados.PosicaoTipo);
            page.AtivarToggleMedicamento();
            page.GravarCategoria();
            page.VoltarParaListaComEsc();
            page.PesquisarCategoria(dados.Nome);
            Assert.IsTrue(page.VerificarCategoriaNaGrid(dados.Nome));
            page.FecharTela();

            CadastroDbSetup.LimparCategoriaPorNome(AcessoDB, dados.Nome);
        }
    }
}
