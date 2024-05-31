using OpenQA.Selenium.Appium.Windows;

namespace SigecomTestesUI2.Pages
{
    public class PesquisaDePessoaPage : PageBase
    {
        public PesquisaDePessoaPage(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        private const string TelaPesquisaPessoaPrefixo = "Pesquisa de ";
        private const string CampoParametroDePesquisa = "textEditParametroDePesquisa";

        public void PesquisarPessoa(string tipoPessoa, string nomePessoa)
        {
            _manipuladorService.ConfirmarSeElementoExisteName(TelaPesquisaPessoaPrefixo + tipoPessoa);
            _manipuladorService.DigitarNoCampoIdEApertarEnter(CampoParametroDePesquisa, nomePessoa);
        }

        public void PesquisarPessoaEConfirmar(string tipoPessoa, string nomePessoa)
        {
            _manipuladorService.ConfirmarSeElementoExisteName(TelaPesquisaPessoaPrefixo + tipoPessoa);
            _manipuladorService.DigitarNoCampoIdEApertarEnterEF5(CampoParametroDePesquisa, nomePessoa);
        }

        public bool VerificarSeCarregouOsDadosDaPessoa(string campoDaPessoa, string nomeDaPessoa) =>
            _manipuladorService.ObterValorElementoId(campoDaPessoa).Equals(nomeDaPessoa);

        public bool VerificarSeExistePessoaNaGrid(string nomePessoa)
        {
            var nomePessoaNaGrid = _manipuladorService.PegarValorDaColunaDaGrid("Nome");
            return nomePessoa.Equals(nomePessoaNaGrid);
        }

        public bool VerificarSeExisteQualquerPessoaNaGrid() =>
            _manipuladorService.PegarValorDaColunaDaGrid("Nome").Any();

        public void FecharTelaDePesquisaDePessoa(string tipoPessoa)
        {
            _manipuladorService.FecharJanelaComEscName(TelaPesquisaPessoaPrefixo + tipoPessoa);
        }
    }
}
