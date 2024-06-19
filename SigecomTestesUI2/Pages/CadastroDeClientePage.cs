using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using SigecomTestesUI2.Sigecom.Cadastros;

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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool PreencherCadastroCompleto(CadastroDeClienteCompletoDados dados)
        {
            try
            {
                _manipuladorService.DigitarNoCampoId(CampoNome, dados.nome);
                _manipuladorService.DigitarNoCampoId(CampoCpf, dados.cpf);
                _manipuladorService.DigitarNoCampoId(CampoRg, dados.rg);
                _manipuladorService.DigitarNoCampoId(CampoApelido, dados.apelido);
                _manipuladorService.SelecionarItemComboBox(CampoSexo, dados.sexo);
                _manipuladorService.DigitarNoCampoId(CampoDataDeNascimento, dados.dataNascimento);
                _manipuladorService.SelecionarItemComboBox(CampoEstadoCivil, dados.estadoCivil);
                _manipuladorService.DigitarNoCampoIdEApertarEnter(CampoCep, dados.cep);
                _manipuladorService.EsperarAcaoEmSegundos(2);
                _manipuladorService.DigitarNoCampoId(CampoNumero, dados.numero);
                _manipuladorService.DigitarNoCampoId(CampoComplemento, dados.complemento);
                _manipuladorService.DigitarNoCampoId(CampoContatos, dados.contatoPessoa);
                _manipuladorService.DigitarNoCampoId(CampoDescontoPadrao, dados.descontoPadrao);
                _manipuladorService.DigitarNoCampoId(CampoObservacao, dados.observacao);
                CadastrarGrupoDeDesconto(dados.sqlCadastroDeGrupoDeDesconto);
                _manipuladorService.SelecionarItemComboBox(CampoGrupo, dados.posicaoGrupo);
                _manipuladorService.SelecionarItemComboBox(CampoTipoContato, dados.posicaoTipoContato);
                _manipuladorService.DigitarNoCampoId(CampoContatoDoCliente, dados.contato);
                _manipuladorService.DigitarNoCampoId(CampoObsContatoDoCliente, dados.observacaoContato);
                _manipuladorService.ClicarBotaoId(BotaoContato);
                _manipuladorService.DigitarNoCampoId(CampoAvisoDeVenda, dados.avisoDeVenda);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool PreencherCadastroPessoaJuridica(string cnpj)
        {
            try
            {
                _manipuladorService.DigitarNoCampoIdEApertarEnter(CampoCpf, cnpj);
                _manipuladorService.EsperarAcaoEmSegundos(2);
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
                _manipuladorService.SelecionarItemComboBox(CampoTipoPessoa, posicao);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void CompararValorDoCampoId(string campo, string valor)
        {
            Assert.AreEqual(_manipuladorService.ObterValorElementoId(campo), valor);
        }

        public bool CadastrarGrupoDeDesconto(string script)
        {
            try
            {
                var db = new AcessoDB();
                var consulta = db.RealizarConsulta("select * from pessoa_grupo where nomegrupo = 'grupo teste' and desconto_maximo = 15.00");
                if (consulta.Rows.Count == 0)
                {
                    db.ExecutarScript(script);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
