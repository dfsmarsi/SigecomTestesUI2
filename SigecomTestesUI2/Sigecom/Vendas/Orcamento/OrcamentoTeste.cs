using SigecomTestesUI2.Enum;
using SigecomTestesUI2.Pages.Pesquisas;
using SigecomTestesUI2.Pages.Vendas.Orcamento;
using SigecomTestesUI2.Services.DbSetup.Configuracao;
using SigecomTestesUI2.Services.DbSetup.Configuracao.Backup;
using SigecomTestesUI2.Services.DbSetup.Configuracao.Estacao;
using SigecomTestesUI2.Sigecom.Vendas.Orcamento.Model;

namespace SigecomTestesUI2.Sigecom.Vendas.Orcamento
{
    public class OrcamentoTeste : TesteBase
    {
        private IConfigBackup? _configBackup;

        [Test(Description = "Faturamento detalhado de orçamento")]
        public void FaturamentoDetalhadoDeOrcamento()
        {
            _configBackup = new EmpresaHostConfigBackup(AcessoDB);
            _configBackup.Salvar("geral_impressao");
            EstacaoOrcamentoDbSetup.HabilitarFaturamentoDetalhado(AcessoDB);
            var orcamentoModel = new OrcamentoTesteModel();

            // Reabrir o sistema para carregar a config alterada
            RelogarNoSistema();

            // Criar orçamento
            var orcamentoPage = new OrcamentoPage(ManipuladorService).AbrirFluxoOrcamentoDock();

            orcamentoPage.AbrirPesquisaDeCliente();

            var pesquisaDeClientePage = new PesquisaDePessoaPage(ManipuladorService);
            pesquisaDeClientePage.PesquisarPessoaEConfirmar(TipoPessoa.Cliente, orcamentoModel.NomeCliente);

            orcamentoPage.ConferirVendedorSelecionado(orcamentoModel.NomeVendedor);
            orcamentoPage.DigitarNomeDoProdutoNaPesquisa(orcamentoModel.NomeProdutoTestePadrao);
            orcamentoPage.AlterarQtdeDoProdutoNaGrid(orcamentoModel.QtdeProduto);

            // Conferir quantidade e valor total do produto na grid
            orcamentoPage.ConferirQtdeDoProdutoNaGrid(orcamentoModel.QtdeProduto);
            var valorTotal = orcamentoPage.ObterValorTotalDoProdutoNaGrid();
            Assert.IsNotEmpty(valorTotal, "O valor total do produto não foi calculado.");

            // Avançar para informar tipo, status e observação
            orcamentoPage.AvancarParaProximaEtapa();
            orcamentoPage.SelecionarTipoOrcamento(orcamentoModel.PosicaoTipoOrcamento);
            orcamentoPage.SelecionarStatusOrcamento(orcamentoModel.PosicaoStatusOrcamento);
            orcamentoPage.DigitarObservacao(orcamentoModel.Observacao);

            // Avançar exibe os cards de ação, selecionar card 2 e concluir
            orcamentoPage.AvancarParaProximaEtapa();
            orcamentoPage.ConcluirOrcamentoSemImpressao();
            orcamentoPage.FecharTelaDeOrcamentoComEsc(orcamentoModel.TelaOrcamentoName);

            // Acessar tela de consulta de orçamentos
            var consultaPage = new ConsultaDeOrcamentoPage(ManipuladorService).AcessarTelaDeConsultaDeOrcamento();

            // Filtrar por observação no filtro avançado
            consultaPage.AbrirFiltroLateral();
            consultaPage.AbrirFiltroAvancado();
            consultaPage.PesquisarPorObservacao(orcamentoModel.Observacao);

            // Conferir se a observação na grid é a mesma do orçamento criado
            var observacaoNaGrid = consultaPage.ObterObservacaoDaGrid();
            Assert.AreEqual(orcamentoModel.Observacao, observacaoNaGrid,
                "A observação na grid não corresponde à do orçamento criado.");

            // Faturar o orçamento selecionado sem impressão
            consultaPage.SelecionarOrcamentoNaGrid(orcamentoModel.Observacao);
            consultaPage.ClicarEmFaturarOrcamento();
            ManipuladorService.TrocarParaProximaJanela();
            orcamentoPage.AvancarParaProximaEtapa();
            orcamentoPage.ConcluirOrcamentoSemImpressao();
            orcamentoPage.SelecionarPagamentoEmDinheiro();

            ManipuladorService.Esperar2Segundos();

            // Conferir se o status foi alterado para Faturado
            var statusAtual = consultaPage.ObterStatusDaGridAposFaturamento(orcamentoModel.Observacao);
            Assert.AreEqual(orcamentoModel.StatusAposFaturamento, statusAtual,
                "O status do orçamento não foi alterado após o faturamento.");

            consultaPage.FecharTelaDeConsultaDeOrcamentoComEsc(orcamentoModel.TelaDeConsultaName);
        }

        [Test(Description = "Faturamento simplificado de orçamento")]
        public void FaturamentoSimplificadoDeOrcamento()
        {
            var orcamentoModel = new OrcamentoTesteModel();

            if (!ConfigDbSetup.VerificarPropriedadeJson(AcessoDB, "empresa_host_config", "geral_impressao", "FaturamentoRapido", false))
            {
                _configBackup = new EmpresaHostConfigBackup(AcessoDB);
                _configBackup.Salvar("geral_impressao");
                EstacaoOrcamentoDbSetup.DesabilitarFaturamentoDetalhado(AcessoDB);
                RelogarNoSistema();
            }

            // Criar orçamento
            var orcamentoPage = new OrcamentoPage(ManipuladorService).AbrirFluxoOrcamentoDock();

            orcamentoPage.AbrirPesquisaDeCliente();

            var pesquisaDeClientePage = new PesquisaDePessoaPage(ManipuladorService);
            pesquisaDeClientePage.PesquisarPessoaEConfirmar(TipoPessoa.Cliente, orcamentoModel.NomeCliente);

            orcamentoPage.ConferirVendedorSelecionado(orcamentoModel.NomeVendedor);
            orcamentoPage.DigitarNomeDoProdutoNaPesquisa(orcamentoModel.NomeProdutoTestePadrao);
            orcamentoPage.AlterarQtdeDoProdutoNaGrid(orcamentoModel.QtdeProduto);

            orcamentoPage.ConferirQtdeDoProdutoNaGrid(orcamentoModel.QtdeProduto);
            var valorTotal = orcamentoPage.ObterValorTotalDoProdutoNaGrid();
            Assert.IsNotEmpty(valorTotal, "O valor total do produto não foi calculado.");

            // Avançar para informar tipo, status e observação
            orcamentoPage.AvancarParaProximaEtapa();
            orcamentoPage.SelecionarTipoOrcamento(orcamentoModel.PosicaoTipoOrcamento);
            orcamentoPage.SelecionarStatusOrcamento(orcamentoModel.PosicaoStatusOrcamento);
            orcamentoPage.DigitarObservacao(orcamentoModel.Observacao);

            // Avançar exibe os cards de ação, selecionar card 2 e concluir
            orcamentoPage.AvancarParaProximaEtapa();
            orcamentoPage.ConcluirOrcamentoSemImpressao();
            orcamentoPage.FecharTelaDeOrcamentoComEsc(orcamentoModel.TelaOrcamentoName);

            // Acessar tela de consulta de orçamentos
            var consultaPage = new ConsultaDeOrcamentoPage(ManipuladorService).AcessarTelaDeConsultaDeOrcamento();

            // Filtrar por observação no filtro avançado
            consultaPage.AbrirFiltroLateral();
            consultaPage.AbrirFiltroAvancado();
            consultaPage.PesquisarPorObservacao(orcamentoModel.Observacao);

            var observacaoNaGrid = consultaPage.ObterObservacaoDaGrid();
            Assert.AreEqual(orcamentoModel.Observacao, observacaoNaGrid,
                "A observação na grid não corresponde à do orçamento criado.");

            // Faturar o orçamento no fluxo simplificado (apenas forma de pagamento)
            consultaPage.SelecionarOrcamentoNaGrid(orcamentoModel.Observacao);
            ManipuladorService.Esperar2Segundos();
            consultaPage.ClicarEmFaturarOrcamento();
            orcamentoPage.SelecionarPagamentoEmDinheiro();

            ManipuladorService.Esperar2Segundos();

            // Conferir se o status foi alterado para Faturado
            var statusAtual = consultaPage.ObterStatusDaGridAposFaturamento(orcamentoModel.Observacao);
            Assert.AreEqual(orcamentoModel.StatusAposFaturamento, statusAtual,
                "O status do orçamento não foi alterado após o faturamento.");

            consultaPage.FecharTelaDeConsultaDeOrcamentoComEsc(orcamentoModel.TelaDeConsultaName);
        }

        [Test(Description = "Orçamento com desconto em reais e faturamento rápido")]
        public void OrcamentoComDescontoEmReaisEFaturamentoRapido()
        {
            var dados = new OrcamentoComDescontoTesteModel();

            if (!ConfigDbSetup.VerificarPropriedadeJson(AcessoDB, "empresa_host_config", "geral_impressao", "FaturamentoRapido", false))
            {
                _configBackup = new EmpresaHostConfigBackup(AcessoDB);
                _configBackup.Salvar("geral_impressao");
                EstacaoOrcamentoDbSetup.DesabilitarFaturamentoDetalhado(AcessoDB);
                RelogarNoSistema();
            }

            // Criar orçamento
            var orcamentoPage = new OrcamentoPage(ManipuladorService).AbrirFluxoOrcamentoDock();

            orcamentoPage.AbrirPesquisaDeCliente();

            var pesquisaDeClientePage = new PesquisaDePessoaPage(ManipuladorService);
            pesquisaDeClientePage.PesquisarPessoaEConfirmar(TipoPessoa.Cliente, dados.NomeCliente);

            orcamentoPage.ConferirVendedorSelecionado(dados.NomeVendedor);
            orcamentoPage.DigitarNomeDoProdutoNaPesquisa(dados.NomeProdutoTestePadrao);

            // Alterar valor unitário para garantir que seja maior que o desconto
            orcamentoPage.AlterarValorUnitarioDoProdutoNaGrid(dados.ValorUnitario);

            // Aplicar desconto de R$ 2,55 (quantidade permanece 1)
            orcamentoPage.AlterarDescontoDoProdutoNaGrid(dados.DescontoReais);

            // Conferir total na grid do orçamento
            var valorTotalNaGrid = orcamentoPage.ObterValorTotalDoProdutoNaGrid();
            Assert.AreEqual(dados.ValorTotalEsperado, valorTotalNaGrid,
                "O valor total do produto não corresponde ao esperado após aplicar o desconto.");

            // Avançar para informar tipo, status e observação
            orcamentoPage.AvancarParaProximaEtapa();
            orcamentoPage.SelecionarTipoOrcamento(dados.PosicaoTipoOrcamento);
            orcamentoPage.SelecionarStatusOrcamento(dados.PosicaoStatusOrcamento);
            orcamentoPage.DigitarObservacao(dados.Observacao);

            // Avançar e concluir sem impressão
            orcamentoPage.AvancarParaProximaEtapa();
            orcamentoPage.ConcluirOrcamentoSemImpressao();
            orcamentoPage.FecharTelaDeOrcamentoComEsc(dados.TelaOrcamentoName);

            // Acessar tela de consulta de orçamentos
            var consultaPage = new ConsultaDeOrcamentoPage(ManipuladorService).AcessarTelaDeConsultaDeOrcamento();

            // Filtrar por observação no filtro avançado
            consultaPage.AbrirFiltroLateral();
            consultaPage.AbrirFiltroAvancado();
            consultaPage.PesquisarPorObservacao(dados.Observacao);

            var observacaoNaGrid = consultaPage.ObterObservacaoDaGrid();
            Assert.AreEqual(dados.Observacao, observacaoNaGrid,
                "A observação na grid não corresponde à do orçamento criado.");

            // Conferir se o valor na consulta corresponde ao total com desconto
            var valorNaConsulta = consultaPage.ObterValorTotalDaGrid();
            Assert.AreEqual(dados.ValorTotalEsperadoConsulta, valorNaConsulta,
                "O valor do orçamento na consulta não corresponde ao esperado com o desconto aplicado.");

            // Faturar o orçamento (fluxo rápido)
            consultaPage.SelecionarOrcamentoNaGrid(dados.Observacao);
            ManipuladorService.Esperar2Segundos();
            consultaPage.ClicarEmFaturarOrcamento();
            ManipuladorService.Esperar2Segundos();
            orcamentoPage.SelecionarPagamentoEmDinheiro();

            ManipuladorService.Esperar2Segundos();

            // Conferir se o status foi alterado para Faturado
            var statusAtual = consultaPage.ObterStatusDaGridAposFaturamento(dados.Observacao);
            Assert.AreEqual(dados.StatusAposFaturamento, statusAtual,
                "O status do orçamento não foi alterado após o faturamento.");

            consultaPage.FecharTelaDeConsultaDeOrcamentoComEsc(dados.TelaDeConsultaName);
        }

        [TearDown]
        public new void TearDown()
        {
            try
            {
                _configBackup?.RestaurarTudo();
            }
            finally
            {
                base.TearDown();
            }
        }
    }
}
