using OpenQA.Selenium.Appium.Windows;

namespace SigecomTestesUI2.Pages
{
    public class CadastroDeClientePage : PageBase
    {
        public CadastroDeClientePage(WindowsDriver<WindowsElement> driver) : base(driver)
        {
        }

        private const string TelaCadastroCliente = "Cadastro de clientes";
        private const string BotaoMenuCadastro = "Cadastro";
        private const string BotaoSubMenuClientes = "Clientes";
        private const string BotaoNovo = "F2 - Novo";
        private const string BotaoGravar = "F5 - Gravar";
        private const string BotaoPesquisar = "F9 - Pesquisar";
        private const string BotaoContato = "btnAddContato";
        private const string CampoTipoPessoa = "cbxPessoaClassificacao";
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
        private const string CampoTabelaDePreco = "cbxTabelaPreco";
        private const string CampoGrupo = "cbxGrupoPessoa";

        public void AcessarItemMenu()
        {
            _manipuladorService.DarDuploCliqueNoBotaoName(BotaoMenuCadastro);
        }

        public void AcessarItemSubMenu()
        {
            _manipuladorService.ClicarNoBotaoName(BotaoSubMenuClientes);
        }

        public void AbrirPesquisaDeCliente()
        {
            _manipuladorService.ClicarNoBotaoName(BotaoPesquisar);
        }

        public void ClicarNoBotaoNovoCadastroDeCliente()
        {
            _manipuladorService.ClicarNoBotaoName(BotaoNovo);
        }

        public void GravarCadastroDeCliente()
        {
            _manipuladorService.ClicarNoBotaoName(BotaoGravar);
        }

        public void FecharTelaDeCadastroDeClienteEsc()
        {
            _manipuladorService.FecharJanelaComEscName(TelaCadastroCliente);
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
            catch (Exception)
            {
                return false;
            }
        }

        public string RetornarTipoPessoa()
        {
            return _manipuladorService.ObterValorElementoId(CampoTipoPessoa);
        }

        public bool VerificarCamposObrigatorios(string nome, string cidade, string estado)
        {
            try
            {
                CompararValorDoCampoId(CampoNome, nome);
                CompararValorDoCampoId(CampoEstado, estado);
                CompararValorDoCampoId(CampoCidade, cidade);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void CompararValorDoCampoId(string campo, string valor)
        {
            Assert.AreEqual(_manipuladorService.ObterValorElementoId(campo), valor);
        }
    }
}
