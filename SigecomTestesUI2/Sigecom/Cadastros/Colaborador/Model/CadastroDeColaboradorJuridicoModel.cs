namespace SigecomTestesUI2.Sigecom.Cadastros.Colaborador.Model
{
    public class CadastroDeColaboradorJuridicoModel
    {
        public string Nome => "BRAS SUN DIGITAL LTDA";
        public string Cnpj => "21418205000161";
        public string Cidade => "JALES";
        public string Estado => "SÃO PAULO";
        public int PosicaoClassificacao => 1;
        public string ScriptPesquisaColaboradorPeloCnpj => "SELECT * FROM pessoa WHERE cpf = '21.418.205/0001-61';";
        public string ScriptDesativarColaboradorRepetido => "update pessoa set cpf = '', desativado = 'S' where cpf = '21.418.205/0001-61';";
    }
}
