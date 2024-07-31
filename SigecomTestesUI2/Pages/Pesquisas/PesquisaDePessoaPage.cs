using OpenQA.Selenium.Appium.Windows;
using SigecomTestesUI2.Enum;

namespace SigecomTestesUI2.Pages.Pesquisas
{
    public class PesquisaDePessoaPage : PageBase
    {
        public PesquisaDePessoaPage(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        private const string TelaPesquisaDeCliente = "Pesquisa de cliente";
        private const string TelaPesquisaDeColaborador = "Pesquisa de colaborador";
        private const string TelaPesquisaDeFornecedor = "Pesquisa de fornecedor";
        private const string CampoParametroDePesquisa = "textEditParametroDePesquisa";

        private static string RetornarTipoDeTelaDePesquisa(TipoPessoa tipo)
        {
            switch (tipo)
            {
                case TipoPessoa.Cliente:
                    return TelaPesquisaDeCliente;
                case TipoPessoa.Colaborador:
                    return TelaPesquisaDeColaborador;
                case TipoPessoa.Fornecedor:
                    return TelaPesquisaDeFornecedor;
                default:
                    throw new ArgumentException("Tipo desconhecido: " + tipo);
            }
        }
        public void PesquisarPessoa(TipoPessoa tipoPessoa, string nomePessoa)
        {
            _manipuladorService.ConfirmarSeElementoExisteName(RetornarTipoDeTelaDePesquisa(tipoPessoa));
            _manipuladorService.DigitarNoCampoIdEApertarEnter(CampoParametroDePesquisa, nomePessoa);
        }

        public void PesquisarPessoaEConfirmar(TipoPessoa tipoPessoa, string nomePessoa)
        {
            _manipuladorService.ConfirmarSeElementoExisteName(RetornarTipoDeTelaDePesquisa(tipoPessoa));
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

        public void FecharTelaDePesquisaDePessoa(TipoPessoa tipoPessoa)
        {
            _manipuladorService.FecharJanelaComEscName(RetornarTipoDeTelaDePesquisa(tipoPessoa));
        }
    }
}
