using SigecomTestesUI2.Services;

namespace SigecomTestesUI2.Pages.Cadastros.Categoria
{
    public class CadastroDeCategoriaPage : PageBase
    {
        private const string BotaoMenuCadastro = "Cadastro";
        private const string BotaoSubMenuCategorias = "Categorias";
        private const string BotaoNovo = ", NOVO";
        private const string BotaoF2Novo = "F2-Novo";
        private const string BotaoGravar = "F5-Gravar";
        private const string TelaCadastroCategoria = "Cadastro de categorias";
        private const string CampoNome = "txtNome";
        private const string CampoMarkup = "txtMarkup";
        private const string CampoTipo = "cbxTipoGrupoProduto";
        private const string CampoPesquisa = "txtPequisa";
        private const string ToggleBalanca = "tglBalanca";
        private const string ToggleCombustivel = "tglCombustivel";
        private const string ToggleGrade = "gradeToggleSwitch";
        private const string ToggleImei = "registrosDoEstoqueToggleSwitch";
        private const string ToggleMedicamento = "toggleSwitchMedicamento";
        private const string GridCaracteristicas = "Caracteristicas new item row";
        private const string ColunaDescricao = "Descricao";

        public CadastroDeCategoriaPage(ManipuladorService manipuladorService) : base(manipuladorService)
        {
        }

        public void AcessarItemMenu()
        {
            _manipuladorService.DarDuploCliqueNoBotaoName(BotaoMenuCadastro);
        }

        public void AcessarSubMenuCategorias()
        {
            _manipuladorService.ClicarNoBotaoName(BotaoSubMenuCategorias);
            _manipuladorService.EsperarElementoName(TelaCadastroCategoria);
        }

        public void AbrirNovaCategoriaForm()
        {
            _manipuladorService.ClicarNoBotaoName(BotaoNovo);
            _manipuladorService.ClicarNoBotaoName(BotaoF2Novo);
        }

        public void PreencherCamposBase(string nome, string markup, int posicaoTipo)
        {
            _manipuladorService.DigitarNoCampoId(CampoNome, nome);
            _manipuladorService.DigitarNoCampoId(CampoMarkup, markup);
            _manipuladorService.SelecionarItemComboBox(CampoTipo, posicaoTipo);
        }

        public void AtivarToggleBalanca() =>
            _manipuladorService.ClicarNoToggleSwitchPeloId(ToggleBalanca);

        public void AtivarToggleCombustivel() =>
            _manipuladorService.ClicarNoToggleSwitchPeloId(ToggleCombustivel);

        public void AtivarToggleGrade() =>
            _manipuladorService.ClicarNoToggleSwitchPeloId(ToggleGrade);

        public void AtivarToggleImei() =>
            _manipuladorService.ClicarNoToggleSwitchPeloId(ToggleImei);

        public void AtivarToggleMedicamento() =>
            _manipuladorService.ClicarNoToggleSwitchPeloId(ToggleMedicamento);

        public void AdicionarCaracteristicaDaGrade(int posicao)
        {
            _manipuladorService.SelecionarDoisItensDaGrid(GridCaracteristicas, posicao);
        }

        public void GravarCategoria()
        {
            _manipuladorService.ClicarNoBotaoName(BotaoGravar);
        }

        public void VoltarParaListaComEsc()
        {
            _manipuladorService.FecharJanelaComEscName(TelaCadastroCategoria);
        }

        public void PesquisarCategoria(string nome)
        {
            _manipuladorService.DigitarNoCampoId(CampoPesquisa, nome);
        }

        public bool VerificarCategoriaNaGrid(string nome) =>
            _manipuladorService.PegarValorDaColunaDaGrid(ColunaDescricao).Equals(nome);

        public void FecharTela()
        {
            _manipuladorService.FecharJanelaComEscName(TelaCadastroCategoria);
        }
    }
}
