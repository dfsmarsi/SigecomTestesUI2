using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

namespace SigecomTestesUI2.Services
{
    public class ManipuladorService
    {
        private readonly WindowsDriver<WindowsElement> _driver;

        public ManipuladorService(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }

        public void TrocarParaProximaJanela()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                var allWindowHandles = _driver.WindowHandles;

                if (allWindowHandles.Count > 0)
                {
                    _driver.SwitchTo().Window(allWindowHandles[0]);
                }
                else
                {
                    throw new WebDriverException("Não há janelas disponíveis para trocar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao trocar de janela: {ex.Message}");
            }
        }

        public void TrocarParaProximaJanelaLogin()
        {
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                var allWindowHandles = _driver.WindowHandles;

                if (allWindowHandles.Count > 0)
                {
                    _driver.SwitchTo().Window(allWindowHandles[0]);
                }
                else
                {
                    throw new WebDriverException("Não há janelas disponíveis para trocar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao trocar de janela: {ex.Message}");
            }
        }

        public WindowsElement EncontrarElementoId(string idElemento) =>
            _driver.FindElementByAccessibilityId(idElemento);

        public WindowsElement EncontrarElementoName(string nomeElemento) =>
            _driver.FindElementByName(nomeElemento);

        public WindowsElement EncontrarElementoXPath(string caminhoElemento) =>
            _driver.FindElementByXPath(caminhoElemento);

        public string ObterValorElementoId(string nomeElemento) =>
            _driver.FindElementByAccessibilityId(nomeElemento).Text;

        public string ObterValorElementoName(string nomeElemento) =>
            _driver.FindElementByName(nomeElemento).Text;

        public string PegarValorDaColunaDaGrid(string nomeColuna) =>
            _driver.FindElementByName($"{nomeColuna} row 0").Text;

        public string PegarValorDaColunaDaGridNaPosicao(string nomeColuna, string posicao) =>
            _driver.FindElementByName($"{nomeColuna} row {posicao}").Text;

        public void DigitarNoCampoId(string idElemento, string texto) =>
            _driver.FindElementByAccessibilityId(idElemento).SendKeys(texto);

        public void DigitarNoCampoName(string nomeElemento, string texto) =>
            _driver.FindElementByName(nomeElemento).SendKeys(texto);

        public void ClicarNoBotaoName(string nomeElemento)
        {
            EncontrarElementoName(nomeElemento).Click();
        }

        public bool VerificarSePossuiOValorNaTela(string nome)
        {
            var driverPageSource = _driver.PageSource;
            return driverPageSource.Contains(nome);
        }

        public void ConfirmarSeElementoExisteName(string valor)
        {
            var elemento = EncontrarElementoName(valor);
            Assert.AreEqual(elemento.Text, valor);
        }

        public void EsperarAcaoEmSegundos(int tempoEmSegundos) =>
            Thread.Sleep(TimeSpan.FromSeconds(tempoEmSegundos));

        public void ClicarNoBotaoId(string nomeBotao) =>
            _driver.FindElementByAccessibilityId(nomeBotao).Click();

        public void DarDuploCliqueNoBotaoName(string nomeBotao)
        {
            var botaoEncontrado = _driver.FindElementByName(nomeBotao);
            var acao = new Actions(_driver);
            acao.MoveToElement(botaoEncontrado);
            acao.DoubleClick();
            acao.Perform();
        }

        public void DarDuploCliqueNoBotaoId(string nomeBotao)
        {
            var botaoEncontrado = _driver.FindElementByAccessibilityId(nomeBotao);
            var acao = new Actions(_driver);
            acao.MoveToElement(botaoEncontrado);
            acao.DoubleClick();
            acao.Perform();
        }

        public void FecharJanelaComEscId(string idCampoParaFocar)
        {
            var campo = EncontrarElementoId(idCampoParaFocar);
            campo.SendKeys(Keys.Escape);
        }

        public void FecharJanelaComEscName(string nomeJanela)
        {
            RealizarAcaoDaTeclaDeAtalhoNaTelaName(nomeJanela, Keys.Escape);
        }

        public void RealizarAcaoDaTeclaDeAtalhoNaTelaName(string nomeJanela, string teclaDeAtalho) =>
            _driver.FindElementByName(nomeJanela).SendKeys(teclaDeAtalho);

        public void RealizarAcaoDaTeclaDeAtalhoNaTelaId(string nomeJanela, string teclaDeAtalho) =>
            _driver.FindElementByAccessibilityId(nomeJanela).SendKeys(teclaDeAtalho);

        public void RealizarAcaoDaTeclaDeAtalhoCtrlAltCombinadaNaTela(string nomeJanela, string teclaDeAtalho) =>
            _driver.FindElementByName(nomeJanela).SendKeys(Keys.Control + Keys.Alt + teclaDeAtalho);

        public void DigitarNoCampoComTeclaDeAtalhoIdComThread(string idElemento, string texto, string teclaDeAtalho)
        {
            var elemento = _driver.FindElementByAccessibilityId(idElemento);
            elemento.SendKeys(texto);
            Thread.Sleep(TimeSpan.FromSeconds(4));
            elemento.SendKeys(teclaDeAtalho);
        }

        public void DigitarNoCampoIdEApertarEnterEF5(string idElemento, string texto) =>
            DigitarNoCampoEUsarTeclaDeAtalhoId(idElemento, texto, Keys.Enter).SendKeys(Keys.F5);

        public void DigitarNoCampoIdEApertarEnter(string idElemento, string texto) =>
            DigitarNoCampoEUsarTeclaDeAtalhoId(idElemento, texto, Keys.Enter);

        public void DigitarNoCampoIdEApertarEnter3x(string idElemento, string texto)
        {
            var elemento = DigitarNoCampoEUsarTeclaDeAtalhoId(idElemento, texto, Keys.Enter);
            elemento.SendKeys(Keys.Enter);
            elemento.SendKeys(Keys.Enter);
        }

        private WindowsElement DigitarNoCampoEUsarTeclaDeAtalhoId(string idElemento, string texto, string teclaDeAtalho)
        {
            var elemento = _driver.FindElementByAccessibilityId(idElemento);
            elemento.SendKeys(texto);
            elemento.SendKeys(teclaDeAtalho);
            return elemento;
        }

        public void RealizarSelecaoDaAcao(string idElemento, int posicao) =>
            RealizarSelecaoDaFormaDePagamento(idElemento, posicao);

        public void RealizarSelecaoDaFormaDePagamentoSemEnter(string idElemento, int posicao) =>
            DigitarNoCampoId(idElemento, posicao.ToString());

        public void RealizarSelecaoDaFormaDePagamento(string idElemento, int posicao)
        {
            var elemento = _driver.FindElementByAccessibilityId(idElemento);
            var acao = new Actions(_driver);
            acao.MoveToElement(elemento);
            acao.SendKeys(posicao.ToString());
            acao.SendKeys(Keys.Enter);
            acao.Perform();
        }

        public void ClicarNoToggleSwitchPeloId(string nomeDoCampo) =>
            ClicarNoBotaoId(nomeDoCampo);

        public void EditarCampoComDuploCliqueNoBotaoId(string nomeBotao, string texto)
        {
            var botaoEncontrado = _driver.FindElementByAccessibilityId(nomeBotao);
            var acao = new Actions(_driver);
            acao.MoveToElement(botaoEncontrado);
            acao.DoubleClick();
            acao.Perform();
            botaoEncontrado.SendKeys(texto);
        }

        public bool VerificarSePossuiOValorNaGrid(string nomeColuna, string nome)
        {
            var campoDaGrid = ObterPosicaoDoElementoNaGrid(nomeColuna, nome);
            var elementoDaGridComName = ObterElementoDaGridComName(nomeColuna, campoDaGrid);
            return elementoDaGridComName.Text.Equals(nome);
        }

        public void CliqueNoElementoDaGridComVariosEVerificar(string nomeColuna, string nome)
        {
            var campoDaGrid = ObterPosicaoDoElementoNaGrid(nomeColuna, nome);
            var elementoDaGridComName = ObterElementoDaGridComName(nomeColuna, campoDaGrid);
            RealizarAcaoDeClicarNoCampoDaGrid(nome, elementoDaGridComName);
            Assert.AreEqual(elementoDaGridComName.Text, nome);
        }

        public void CliqueNoElementoDaGridComVarios(string nomeColuna, string nome)
        {
            var campoDaGrid = ObterPosicaoDoElementoNaGrid(nomeColuna, nome);

            RealizarAcaoDeClicarNoCampoDaGrid(nome, ObterElementoDaGridComName(nomeColuna, campoDaGrid));
        }

        public int RetornarPosicaoDoRegistroDesejado(string nomeColunaParaEncontrarValor, string valorParaSerEncontrado)
        {
            var campoDaGrid = ObterPosicaoDoElementoNaGrid(nomeColunaParaEncontrarValor, valorParaSerEncontrado);

            RealizarAcaoDeClicarNoCampoDaGrid(valorParaSerEncontrado, ObterElementoDaGridComName(nomeColunaParaEncontrarValor, campoDaGrid));
            return campoDaGrid;
        }

        public void EditarNaGridNaPosicao(string nomeColunaParaEditar, string valorParaEditar, int campoDaGrid)
        {
            var elementoEncontrado = _driver.FindElementByName($"{nomeColunaParaEditar} row {campoDaGrid}");
            var acao = new Actions(_driver);
            acao.MoveToElement(elementoEncontrado);
            acao.DoubleClick();
            acao.Perform();
            elementoEncontrado.SendKeys(valorParaEditar);
            elementoEncontrado.SendKeys(Keys.Tab);
        }

        private int ObterPosicaoDoElementoNaGrid(string nomeColuna, string nome)
        {
            var campoDaGrid = 0;

            while (!ObterElementoDaGridComName(nomeColuna, campoDaGrid).Text.Equals(nome))
                campoDaGrid++;

            return campoDaGrid;
        }

        private WindowsElement ObterElementoDaGridComName(string nomeColuna, int campoDaGrid) =>
            _driver.FindElementByName($"{nomeColuna} row {campoDaGrid}");

        private void RealizarAcaoDeClicarNoCampoDaGrid(string nome, IWebElement botaoEncontrado)
        {
            if (!botaoEncontrado.Text.Equals(nome)) return;
            var acao = new Actions(_driver);
            acao.Click(botaoEncontrado);
            acao.Perform();
        }

        public void SelecionarItemComboBoxSemEnter(string nomeCampo, int posicao)
        {
            var campo = _driver.FindElementByAccessibilityId(nomeCampo);
            SelecionarItens(posicao, campo);
        }

        public void SelecionarItemComboBox(string nomeCampo, int posicao)
        {
            var campo = _driver.FindElementByAccessibilityId(nomeCampo);
            ConcluirSelecionarItens(posicao, campo);
        }

        private static void ConcluirSelecionarItens(int posicao, IWebElement elementoEncontrado)
        {
            SelecionarItens(posicao, elementoEncontrado);
            elementoEncontrado.SendKeys(Keys.Enter);
        }

        public void SelecionarDoisItensDaGrid(string nomeCampo, int posicao)
        {
            var elementoEncontrado = _driver.FindElementByName(nomeCampo);
            ConcluirSelecionarItens(posicao, elementoEncontrado);
            elementoEncontrado.SendKeys(Keys.Tab);
        }

        private static void SelecionarItens(int posicao, IWebElement elementoEncontrado)
        {
            elementoEncontrado.Click();
            EncontrarElementoNaComboBox(posicao, elementoEncontrado);
            elementoEncontrado.SendKeys(Keys.Tab);
        }

        public void SelecionarItensDoDropDown(int posicao)
        {
            var acao = new Actions(_driver);
            for (var i = 1; i <= posicao; i++)
                acao.SendKeys(Keys.ArrowDown);
            acao.SendKeys(Keys.Enter);
            acao.Perform();
        }

        public void ClicarNoCheckEditDaGrid(string nomeCampo)
        {
            var elementoEncontrado = _driver.FindElementByName($"{nomeCampo} row 0");
            elementoEncontrado.Click();
            elementoEncontrado.SendKeys(Keys.Enter);
        }

        public void DigitarNovosItensNaGrid(string nomeCampo, string texto)
        {
            var elementoEncontrado = _driver.FindElementByName($"{nomeCampo} new item row");
            DigitarItensNaGrid(texto, elementoEncontrado);
        }

        public void EditarItensNaGrid(string nomeCampo, string texto)
        {
            var elementoEncontrado = _driver.FindElementByName($"{nomeCampo} row 0");
            DigitarItensNaGrid(texto, elementoEncontrado);
        }

        private static void DigitarItensNaGrid(string texto, IWebElement elementoEncontrado)
        {
            elementoEncontrado.SendKeys(texto);
            elementoEncontrado.SendKeys(Keys.Tab);
        }

        public void EditarItensNaGridComDuploClickComTab(string nomeCampo, string texto)
        {
            var elementoEncontrado = EditarItemDaGridComDuploClick(nomeCampo, texto, "0");
            elementoEncontrado.SendKeys(Keys.Tab);
        }

        public void EditarItensNaGridComDuploClickComEnter(string nomeCampo, string texto)
        {
            var elementoEncontrado = EditarItemDaGridComDuploClick(nomeCampo, texto, "0");
            elementoEncontrado.SendKeys(Keys.Enter);
        }

        public void EditarItensNaGridComDuploClickNaPosicaoDesejada(string nomeCampo, string texto, string posicao)
        {
            EditarItemDaGridComDuploClick(nomeCampo, texto, posicao);
        }

        public void EditarItensNaGridComDuploClickNaPosicaoDesejadaETab(string nomeCampo, string texto, string posicao)
        {
            EditarItemDaGridComDuploClick(nomeCampo, texto, posicao).SendKeys(Keys.Tab);

        }

        private WindowsElement EditarItemDaGridComDuploClick(string nomeCampo, string texto, string posicao)
        {
            var elementoEncontrado = _driver.FindElementByName($"{nomeCampo} row {posicao}");
            var acao = new Actions(_driver);
            acao.MoveToElement(elementoEncontrado);
            acao.DoubleClick();
            acao.Perform();
            elementoEncontrado.SendKeys(texto);
            return elementoEncontrado;
        }

        public void RemoverItensDaGridComBotaoDireito(string nomeCampo)
        {
            var elementoEncontrado = _driver.FindElementByAccessibilityId(nomeCampo);
            var acao = new Actions(_driver);
            acao.MoveToElement(elementoEncontrado);
            acao.Click();
            acao.Perform();
            elementoEncontrado.SendKeys(Keys.Delete);
        }

        private static void EncontrarElementoNaComboBox(int posicao, IWebElement campo)
        {
            for (var i = 1; i <= posicao; i++)
                campo.SendKeys(Keys.ArrowDown);
        }

        public void AbrirPesquisaComF9(string nomeJanela) =>
            RealizarAcaoDaTeclaDeAtalhoNaTelaName(nomeJanela, Keys.F9);

        public void ConfirmarPesquisa(string nomeJanela) =>
            RealizarAcaoDaTeclaDeAtalhoNaTelaName(nomeJanela, Keys.F5);

        public void AbrirFecharAbaDeFiltroTelaDeConsulta(string nomeJanela) =>
            RealizarAcaoDaTeclaDeAtalhoNaTelaName(nomeJanela, Keys.F3);

        public void FocarCampoName(string nomeCampo)
        {
            var campo = EncontrarElementoName(nomeCampo);
            campo.Click();
        }

        public bool VerificarSeCheckEstaMarcado(string idCampo)
        {
            var estaMarcado = ObterValorElementoName(idCampo);
            if (estaMarcado == "Checked")
                return true;
            return false;
        }
    }
}
