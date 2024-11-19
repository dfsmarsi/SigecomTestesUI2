using OpenQA.Selenium.Appium.Windows;

namespace SigecomTestesUI2.Pages.Login
{
    public class LoginPage : PageBase
    {
        public LoginPage(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        private const string IdCampoUsuario = "txtUsuario";
        private const string IdCampoSenha = "txtSenha";
        private const string NomeBotaoAcessar = ", Acessar";
        private const string NomeFrmPrincipal = "SIGECOM - Sistema de Gestão Comercial - Teste Ui - Qa";
        private const string IdFrmLogin = "FrmLogin";

        public void RealizarLogin()
        {
            LoginDados dadosLogin = new LoginDados();
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
