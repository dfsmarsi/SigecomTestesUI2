using SigecomTestesUI2.Enum;
using SigecomTestesUI2.Services;

namespace SigecomTestesUI2.Pages.Pesquisas
{
    public class PesquisaDePessoaPage : PageBase
    {
        public PesquisaDePessoaPage(ManipuladorService manipuladorService) : base(manipuladorService)
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
            _manipuladorService.ElementoExisteNaTela(RetornarTipoDeTelaDePesquisa(tipoPessoa));
            _manipuladorService.DigitarNoCampoIdEApertarEnter(CampoParametroDePesquisa, nomePessoa);
        }

        public void PesquisarPessoaEConfirmar(TipoPessoa tipoPessoa, string nomePessoa)
        {
            try
            {
                _manipuladorService.ElementoExisteNaTela(RetornarTipoDeTelaDePesquisa(tipoPessoa));
                _manipuladorService.DigitarNoCampoIdEApertarEnterEF5(CampoParametroDePesquisa, nomePessoa);
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao pesquisar {tipoPessoa} e confirmar! {ex.Message}");
            }
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
