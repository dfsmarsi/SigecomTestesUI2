using OpenQA.Selenium.Appium.Windows;
using SigecomTestesUI2.Services;

namespace SigecomTestesUI2
{
    public class LoginPage
    {
        private readonly ManipuladorService _manipuladorService;

        public LoginPage(WindowsDriver<WindowsElement> driver)
        {
            _manipuladorService = new ManipuladorService(driver);
        }

        private const string IdCampoUsuario = "txtUsuario";
        private const string IdCampoSenha = "txtSenha";
        private const string NomeBotaoAcessar = ", Acessar";
        private const string NomeFrmPrincipal = "SIGECOM - Sistema de Gestão Comercial - Teste Ui - Qa";
        private const string IdFrmLogin = "FrmLogin";

        public void RealizarLogin(LoginDados dadosLogin)
        {
            try
            {
                ValidarSeTelaDeLoginEstaAberta();
                _manipuladorService.DigitarNoCampoId(IdCampoUsuario, dadosLogin.Usuario);
                _manipuladorService.DigitarNoCampoId(IdCampoSenha, dadosLogin.Senha);
                _manipuladorService.ClicarNoBotaoName(NomeBotaoAcessar);
                _manipuladorService.TrocarParaProximaJanelaLogin();
                ValidarSeLoginFoiRealizado();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao fazer login: {ex.Message}");
            }
        }
        private void ValidarSeTelaDeLoginEstaAberta()
        {
            _manipuladorService.ObterValorElementoId(IdFrmLogin).Equals(IdFrmLogin);
        }

        private void ValidarSeLoginFoiRealizado()
        {
            _manipuladorService.ObterValorElementoName(NomeFrmPrincipal).Equals(NomeFrmPrincipal);
        }
    }
}
