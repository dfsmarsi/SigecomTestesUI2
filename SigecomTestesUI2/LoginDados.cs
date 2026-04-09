namespace SigecomTestesUI2
{
    public class LoginDados
    {
        public string Usuario { get; } = Configuracao.Instancia["Login:Usuario"]!;
        public string Senha { get; } = Configuracao.Instancia["Login:Senha"]!;
    }
}
