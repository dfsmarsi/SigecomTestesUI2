using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using SigecomTestesUI2.Services;
using System.Diagnostics;

namespace SigecomTestesUI2
{
    [TestFixture]
    public class TesteBase
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string WindowsAppId = @"C:\SIGECOM\Sigecom.exe";
        const string WinAppDriver = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";

        protected static WindowsDriver<WindowsElement> Driver;
        protected static ManipuladorService ManipuladorService;

        [SetUp]
        public static void Setup()
        {
            IniciarWinAppDriver();
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", WindowsAppId);
            Driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
            ManipuladorService = new ManipuladorService(Driver);

            LoginDados dadosLogin = new LoginDados();
            LoginPage login = new LoginPage(Driver);
            login.RealizarLogin(dadosLogin);
        }

        [TearDown]
        public static void TearDown()
        {
            FecharSistema();

            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }

        private static void IniciarWinAppDriver()
        {
            Process.Start(WinAppDriver);
        }

        private static void FecharSistema()
        {
            try
            {
                ManipuladorService.ClicarNoBotaoName("Sair/Login");
                ManipuladorService.TrocarParaProximaJanelaLogin();
                ManipuladorService.ConfirmarSeElementoExisteName("Sistema de gestão comercial"); //tela de login
                ManipuladorService.ClicarNoBotaoName("Fechar"); // X da tela de login
            }
            catch (Exception)
            {
                MatarProcessoSigecom();
            }
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
