namespace SigecomTestesUI2.Sigecom.Cadastros.Cliente.Model
{
    public class CadastroDeClienteCompletoModel
    {
        public string Nome => "CLIENTE COMPLETO";
        public string Cpf => "05042070087";
        public string Rg => "123456789";
        public string Apelido => "CLIENTE COMPLETO APELIDO";
        public int Sexo => 1;
        public string DataNascimento => "16041998";
        public int EstadoCivil => 1;
        public string Cep => "15700082";
        public string Numero => "123";
        public string Complemento => "CASA";
        public string ContatoPessoa => "JOAO DA FEIRA";
        public string DescontoPadrao => "10,00";
        public string Observacao => "OBSERVACAO TESTE";
        public int PosicaoGrupo => 2;
        public int PosicaoTipoContato => 3;
        public string Contato => "17991234567";
        public string ObservacaoContato => "CELULAR";
        public string AvisoDeVenda => "AVISO DE VENDA";
        public string SqlCadastroDeGrupoDeDesconto => "insert into pessoa_grupo (nomegrupo, desconto_maximo) values ('grupo teste', 15.00)";
    }
}
