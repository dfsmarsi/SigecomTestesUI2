using SigecomTestesUI2.Services;

namespace SigecomTestesUI2.Pages.Vendas.Orcamento
{
    public class ConsultaDeOrcamentoPage : PageBase
    {
        public ConsultaDeOrcamentoPage(ManipuladorService manipuladorService) : base(manipuladorService)
        {
        }

        private const string BotaoMenuVendas = "Vendas";
        private const string BotaoSubMenuConsultarOrcamentos = "Consultar orçamentos";
        private const string TelaConsultaDeOrcamentos = "Consulta de orçamentos";
        private const string BotaoNovoOrcamento = "Novo orçamento";
        private const string BotaoAlterar = "Alterar";
        private const string BotaoFaturar = "Faturar";
        private const string BotaoFiltroAvancadoName = ", Avançado";
        private const string BotaoFiltroName = "Filtro";
        private const string CampoObservacaoFiltroId = "txtObservacao";
        private const string ColunaObservacaoNaGridName = "Observação";
        private const string ColunaStatusNaGridName = "Status";
        private const string ColunaValorNaGridName = "Total";

        public ConsultaDeOrcamentoPage AcessarTelaDeConsultaDeOrcamento()
        {
            _manipuladorService.ClicarNoBotaoName(BotaoMenuVendas);
            _manipuladorService.ClicarNoBotaoName(BotaoSubMenuConsultarOrcamentos);
            _manipuladorService.EsperarElementoName(TelaConsultaDeOrcamentos);
            return this;
        }

        public void AbrirFiltroAvancado()
        {
            try
            {
                _manipuladorService.ClicarNoBotaoName(BotaoFiltroAvancadoName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao abrir o filtro avançado: {ex.Message}");
            }
        }

        public void PesquisarPorObservacao(string observacao)
        {
            try
            {
                _manipuladorService.DigitarNoCampoIdEApertarEnter(CampoObservacaoFiltroId, observacao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao pesquisar por observação: {ex.Message}");
            }
        }

        public string ObterObservacaoDaGrid()
        {
            return _manipuladorService.PegarValorDaColunaDaGrid(ColunaObservacaoNaGridName);
        }

        public string ObterValorTotalDaGrid()
        {
            return _manipuladorService.PegarValorDaColunaDaGrid(ColunaValorNaGridName);
        }

        public string ObterStatusDaGridAposFaturamento(string observacao)
        {
            var posicao = _manipuladorService.RetornarPosicaoDoRegistroDesejado(ColunaObservacaoNaGridName, observacao);
            return _manipuladorService.PegarValorDaColunaDaGridNaPosicao(ColunaStatusNaGridName, posicao.ToString());
        }

        public void SelecionarOrcamentoNaGrid(string observacao)
        {
            try
            {
                _manipuladorService.ClicarNoElementoDaGridComVarios(ColunaObservacaoNaGridName, observacao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao selecionar o orçamento na grid: {ex.Message}");
            }
        }

        public void ClicarEmFaturarOrcamento()
        {
            try
            {
                _manipuladorService.ClicarNoBotaoName(BotaoFaturar);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao faturar o orçamento: {ex.Message}");
            }
        }

        public bool RealizarNovoOrcamento(string valorDoItem)
        {
            try
            {
                _manipuladorService.ClicarNoBotaoName(BotaoNovoOrcamento);
                _manipuladorService.TrocarParaProximaJanela();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void FecharTelaDeConsultaDeOrcamentoComEsc(string telaDeConsultaName)
        {
            try
            {
                _manipuladorService.FecharJanelaComEscName(telaDeConsultaName);   
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao fechar a tela de consulta de orçamento: {ex.Message}");
            }
        }

        internal void AbrirFiltroLateral()
        {
            try
            {
                _manipuladorService.ClicarNoBotaoName(BotaoFiltroName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao abrir o filtro lateral: {ex.Message}");
            }
        }
    }
}
