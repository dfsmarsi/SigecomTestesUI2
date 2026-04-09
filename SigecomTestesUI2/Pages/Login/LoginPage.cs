using SigecomTestesUI2.Services;

namespace SigecomTestesUI2.Pages.Login
{
    public class LoginPage : PageBase
    {
        private const string IdCampoUsuario = "txtUsuario";
        private const string IdCampoSenha = "txtSenha";
        private const string NomeBotaoAcessar = ", Acessar";
        private const string NomeFrmPrincipal = "SIGECOM - Sistema de Gestão Comercial - Teste Ui - Qa";
        private const string IdFrmLogin = "FrmLogin";

        public LoginPage(ManipuladorService manipuladorService) : base(manipuladorService)
        {
        }

        public void RealizarLogin()
        {
            LoginDados dadosLogin = new LoginDados();
            _manipuladorService.EditarCampoComDuploCliqueNoBotaoId(IdCampoUsuario, dadosLogin.Usuario);
            _manipuladorService.DigitarNoCampoIdEApertarEnter(IdCampoSenha, dadosLogin.Senha);
            _manipuladorService.TrocarParaProximaJanela();
        }

        public bool TelaDeLoginEstaAberta() =>
            _manipuladorService.ElementoExisteNaTela(IdFrmLogin);

        public bool LoginFoiRealizado() =>
            _manipuladorService.ElementoExisteNaTela(NomeFrmPrincipal);
    }
}
