using SigecomTestesUI2.Services;

namespace SigecomTestesUI2.Pages.Pesquisas
{
    public class PesquisaDeProdutoPage : PageBase
    {
        public PesquisaDeProdutoPage(ManipuladorService manipuladorService) : base(manipuladorService)
        {
        }

        public string IdCampoPesquisaDeProduto => "pesquisarTextEdit";
        public string NameBotaoConfirmarPesquisarProduto => "F5 - Confirmar";
        public string NameColunaNomeProdutoNaGrid => "Nome";

        public void ConfirmarItemPesquisaDeProdutoComEnter(string nomeProdutoTestePadrao)
        {
            VerificarProdutoDigitadoNoCampoDePesquisa(nomeProdutoTestePadrao);
            try
            {
                _manipuladorService.ClicarNoElementoDaGridComVariosEApertarEnter(NameColunaNomeProdutoNaGrid, nomeProdutoTestePadrao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao confirmar item na pesquisa de produto: {ex.Message}");
            }
        }

        private void VerificarProdutoDigitadoNoCampoDePesquisa(string nomeProdutoTestePadrao)
        {
            if (!_manipuladorService.ObterValorElementoId(IdCampoPesquisaDeProduto).Equals(nomeProdutoTestePadrao))
            {
                throw new Exception("O produto digitado no campo de pesquisa não corresponde ao esperado.");
            }
        }
    }
}
