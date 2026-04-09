using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using SigecomTestesUI2.Pages.Login;
using SigecomTestesUI2.Services;
using System.Diagnostics;

namespace SigecomTestesUI2
{
    [TestFixture]
    public class TesteBase
    {
        private static string WindowsApplicationDriverUrl => Configuracao.Instancia["Sigecom:WinAppDriverUrl"]!;
        private static string WindowsAppId => Configuracao.Instancia["Sigecom:AppPath"]!;
        private static string WinAppDriver => Configuracao.Instancia["Sigecom:WinAppDriverPath"]!;

        protected WindowsDriver<WindowsElement>? Driver;
        protected ManipuladorService ManipuladorService;
        protected AcessoDB AcessoDB;

        [SetUp]
        public void Setup()
        {
            IniciarWinAppDriver();
            var driverUrl = new Uri(WindowsApplicationDriverUrl);

            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", WindowsAppId);
            Driver = new WindowsDriver<WindowsElement>(driverUrl, appiumOptions);
            ManipuladorService = new ManipuladorService(Driver);
            AcessoDB = new AcessoDB();

            var login = new LoginPage(ManipuladorService);
            login.RealizarLogin();

            Driver = ReconectarAoFrmPrincipal(driverUrl);
            ManipuladorService = new ManipuladorService(Driver);
        }

        private WindowsDriver<WindowsElement> ReconectarAoFrmPrincipal(Uri driverUrl)
        {
            var desktopOptions = new AppiumOptions();
            desktopOptions.AddAdditionalCapability("app", "Root");
            using var desktopSession = new WindowsDriver<WindowsElement>(driverUrl, desktopOptions);

            WindowsElement? frmPrincipal = null;
            var limite = DateTime.UtcNow.AddSeconds(20);
            while (DateTime.UtcNow < limite)
            {
                try
                {
                    frmPrincipal = desktopSession.FindElementByName(
                        "SIGECOM - Sistema de Gestão Comercial - Teste Ui - Qa");
                    if (frmPrincipal != null) break;
                }
                catch { }
                Thread.Sleep(500);
            }

            if (frmPrincipal == null)
                throw new TimeoutException("frmPrincipal não abriu após o login.");

            var handleHex = frmPrincipal.GetAttribute("NativeWindowHandle");
            var handleInt = int.Parse(handleHex);
            var topLevelHandle = "0x" + handleInt.ToString("x");

            var appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("appTopLevelWindow", topLevelHandle);
            return new WindowsDriver<WindowsElement>(driverUrl, appOptions);
        }

        [TearDown]
        public void TearDown()
        {
            FecharSistema();

            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
                Driver = null;
            }

            AcessoDB?.Dispose();
        }

        private static void IniciarWinAppDriver()
        {
            Process.Start(WinAppDriver);
        }

        private void FecharSistema()
        {
            try
            {
                RealizarSairLogin();
                ManipuladorService.ClicarNoBotaoName("Fechar");
            }
            catch (Exception)
            {
                MatarProcessoSigecom();
            }
        }

        protected void RealizarSairLogin()
        {
            ManipuladorService.ClicarNoBotaoName("Sair/Login");
            ManipuladorService.TrocarParaProximaJanela();
        }

        protected void RelogarNoSistema()
        {
            RealizarSairLogin();
            var driverUrl = new Uri(WindowsApplicationDriverUrl);
            var login = new LoginPage(ManipuladorService);
            login.RealizarLogin();
            Driver = ReconectarAoFrmPrincipal(driverUrl);
            ManipuladorService = new ManipuladorService(Driver);
        }

        public static void MatarProcessoSigecom()
        {
            foreach (var process in Process.GetProcessesByName("Sigecom"))
            {
                process.Kill();
            }
        }
    }
}
