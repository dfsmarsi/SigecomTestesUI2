using System.Runtime.ConstrainedExecution;

namespace SigecomTestesUI2.Sigecom.Cadastros
{
    public class CadastroDeClienteSimplesDados
    {
        public string nome => "BRAIA";
        public string cidade => "VOTUPORANGA";
        public string estado => "SÃO PAULO";
    }

    public class CadastroDeClienteCompletoDados
    {
        public string nome => "CLIENTE COMPLETO";
        public string cpf => "05042070087";
        public string rg => "123456789";
        public string apelido => "CLIENTE COMPLETO APELIDO";
        public int sexo => 1;
        public string dataNascimento => "16041998";
        public int estadoCivil => 1;
        public string cep => "15700082";
        public string numero => "123";
        public string complemento => "CASA";
        public string contatoPessoa => "JOAO DA FEIRA";
        public string descontoPadrao => "10,00";
        public string observacao => "OBSERVACAO TESTE";
        public int posicaoGrupo => 2;
        public int posicaoTipoContato => 3;
        public string contato => "17991234567";
        public string observacaoContato => "CELULAR";
        public string avisoDeVenda => "AVISO DE VENDA";
        public string sqlCadastroDeGrupoDeDesconto => "insert into pessoa_grupo (nomegrupo, desconto_maximo) values ('grupo teste', 15.00)";
    }

    public class CadastroDeClienteJuridicoDados
    {
        public string nome => "PLUG4SALES ATIVIDADES DE INTERNET LTDA";
        public string cnpj => "40120973000189";
        public string cidade => "JALES";
        public string estado => "SÃO PAULO";
        public int posicaoClassificacao => 1;
    }
}
