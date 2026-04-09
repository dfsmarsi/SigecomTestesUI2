using SigecomTestesUI2.Enum;
using SigecomTestesUI2.Services;
using SigecomTestesUI2.Sigecom.Cadastros.Cliente.Model;

namespace SigecomTestesUI2.Pages.Cadastros.Pessoa
{
    public class CadastroDePessoaPage : PageBase
    {
        public CadastroDePessoaPage(ManipuladorService manipuladorService) : base(manipuladorService)
        {
        }

        private const string TelaCadastroCliente = "Cadastro de clientes";
        private const string TelaCadastroColaborador = "Cadastro de colaboradores";
        private const string TelaCadastroFornecedor = "Cadastro de fornecedores";
        private const string BotaoMenuCadastro = "Cadastro";
        private const string BotaoSubMenuClientes = "Clientes";
        private const string BotaoSubMenuColaborador = "Colaboradores";
        private const string BotaoSubMenuFornecedor = "Fornecedores";
        private const string BotaoNovo = "F2 - Novo";
        private const string BotaoGravar = "F5 - Gravar";
        private const string BotaoPesquisar = "F9 - Pesquisar";
        private const string BotaoContato = "btnAddContato";
        private const string CampoClassificacaoPessoa = "cbxPessoaClassificacao";
        private const string CampoNacionalidade = "cbxNacionalidade";
        private const string CampoNome = "txtNome";
        private const string CampoCpf = "cpfCnpjButtonEdit";
        private const string CampoCep = "txtCEP";
        private const string CampoNumero = "txtNumero";
        private const string CampoEndereco = "txtEndereco";
        private const string CampoCidade = "cbxCidade";
        private const string CampoEstado = "cbxEstado";
        private const string CampoContatos = "txtContatos";
        private const string CampoIdentificador = "txtIdentificador";
        private const string CampoInscricaoSuframa = "txtInscricaoSuframa";
        private const string CampoRg = "txtRG";
        private const string CampoApelido = "txtApelido";
        private const string CampoDataDeNascimento = "txtDataNascimento";
        private const string CampoComplemento = "txtComplemento";
        private const string CampoProfissao = "txtProfissao";
        private const string CampoObservacao = "txtObservacao";
        private const string CampoContatoDoCliente = "txtContato";
        private const string CampoObsContatoDoCliente = "txtObsContato";
        private const string CampoSexo = "cbxSexo";
        private const string CampoEstadoCivil = "cbxEstadoCivil";
        private const string CampoAvisoDeVenda = "txtAvisoDeVenda";
        private const string CampoTipoContato = "cbxPessoaContatoTipo";
        private const string CampoBairro = "txtBairro";
        private const string CampoDescontoPadrao = "txtDescontoPadraoCliente";
        private const string CampoGrupo = "cbxGrupoPessoa";

        private static string ObterNomeTelaCadastro(TipoPessoa tipoPessoa) => tipoPessoa switch
        {
            TipoPessoa.Cliente => TelaCadastroCliente,
            TipoPessoa.Colaborador => TelaCadastroColaborador,
            TipoPessoa.Fornecedor => TelaCadastroFornecedor,
            _ => throw new ArgumentException("Tipo desconhecido: " + tipoPessoa)
        };

        public void AcessarItemMenu()
        {
            _manipuladorService.DarDuploCliqueNoBotaoName(BotaoMenuCadastro);
        }

        public void AcessarItemSubMenu(TipoPessoa tipoPessoa)
        {
            if(tipoPessoa == TipoPessoa.Cliente)
                _manipuladorService.ClicarNoBotaoName(BotaoSubMenuClientes);
            else if(tipoPessoa == TipoPessoa.Colaborador)
                _manipuladorService.ClicarNoBotaoName(BotaoSubMenuColaborador);
            else if (tipoPessoa == TipoPessoa.Fornecedor)
                _manipuladorService.ClicarNoBotaoName(BotaoSubMenuFornecedor);

            _manipuladorService.EsperarElementoName(ObterNomeTelaCadastro(tipoPessoa));
        }

        public void AbrirPesquisaDePessoa()
        {
            _manipuladorService.ClicarNoBotaoName(BotaoPesquisar);
        }

        public void ClicarNoBotaoNovoCadastroDePessoa()
        {
            _manipuladorService.ClicarNoBotaoName(BotaoNovo);
        }

        public void GravarCadastroDePessoa()
        {
            _manipuladorService.ClicarNoBotaoName(BotaoGravar);
            _manipuladorService.EsperarElementoName(BotaoNovo);
        }

        public void FecharTelaDeCadastroDePessoaEsc(TipoPessoa tipoPessoa)
        {
            _manipuladorService.FecharJanelaComEscName(ObterNomeTelaCadastro(tipoPessoa));
        }

        public bool PreencherCamposObrigatorios(string nome, string cidade, string estado)
        {
            try
            {
                _manipuladorService.DigitarNoCampoId(CampoNome, nome);
                _manipuladorService.DigitarNoCampoIdEApertarEnter(CampoEstado, estado);
                _manipuladorService.DigitarNoCampoIdEApertarEnter(CampoCidade, cidade);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void PreencherCadastroCompleto(CadastroDeClienteCompletoModel dados)
        {
            _manipuladorService.DigitarNoCampoId(CampoNome, dados.Nome);
            _manipuladorService.DigitarNoCampoId(CampoCpf, dados.Cpf);
            _manipuladorService.DigitarNoCampoId(CampoRg, dados.Rg);
            _manipuladorService.DigitarNoCampoId(CampoApelido, dados.Apelido);
            _manipuladorService.SelecionarItemComboBox(CampoSexo, dados.Sexo);
            _manipuladorService.DigitarNoCampoId(CampoDataDeNascimento, dados.DataNascimento);
            _manipuladorService.SelecionarItemComboBox(CampoEstadoCivil, dados.EstadoCivil);
            _manipuladorService.DigitarNoCampoIdEApertarEnter(CampoCep, dados.Cep);
            _manipuladorService.EsperarCampoPreenchidoId(CampoEndereco);
            _manipuladorService.DigitarNoCampoId(CampoNumero, dados.Numero);
            _manipuladorService.DigitarNoCampoId(CampoComplemento, dados.Complemento);
            _manipuladorService.DigitarNoCampoId(CampoContatos, dados.ContatoPessoa);
            _manipuladorService.DigitarNoCampoId(CampoDescontoPadrao, dados.DescontoPadrao);
            _manipuladorService.DigitarNoCampoId(CampoObservacao, dados.Observacao);
            _manipuladorService.SelecionarItemComboBox(CampoGrupo, dados.PosicaoGrupo);
            _manipuladorService.SelecionarItemComboBox(CampoTipoContato, dados.PosicaoTipoContato);
            _manipuladorService.DigitarNoCampoId(CampoContatoDoCliente, dados.Contato);
            _manipuladorService.DigitarNoCampoId(CampoObsContatoDoCliente, dados.ObservacaoContato);
            _manipuladorService.ClicarNoBotaoId(BotaoContato);
            _manipuladorService.DigitarNoCampoId(CampoAvisoDeVenda, dados.AvisoDeVenda);
        }

        public bool PreencherCadastroPessoaJuridica(string cnpj)
        {
            try
            {
                _manipuladorService.DigitarNoCampoIdEApertarEnter(CampoCpf, cnpj);
                _manipuladorService.EsperarCampoPreenchidoId(CampoNome);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool SelecionarClassificacao(int posicao)
        {
            try
            {
                _manipuladorService.SelecionarItemComboBox(CampoClassificacaoPessoa, posicao);
                _manipuladorService.EsperarElementoId(CampoCpf);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public string RetornarClassificacaoPessoa()
        {
            return _manipuladorService.ObterValorElementoId(CampoClassificacaoPessoa);
        }

        public bool VerificarCamposObrigatorios(string nome, string cidade, string estado) =>
            CompararValorDoCampoId(CampoNome, nome) &&
            CompararValorDoCampoId(CampoEstado, estado) &&
            CompararValorDoCampoId(CampoCidade, cidade);

        public bool CompararValorDoCampoId(string campo, string valor) =>
            _manipuladorService.ObterValorElementoId(campo).Equals(valor);
    }
}
