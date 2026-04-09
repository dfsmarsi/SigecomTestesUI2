namespace SigecomTestesUI2.Services.DbSetup
{
    public static class CadastroDbSetup
    {
        public static void GarantirClienteExistePorNome(AcessoDB acessoDB, string nome)
        {
            var consulta = acessoDB.RealizarConsulta($"SELECT * FROM pessoa WHERE nome = '{nome}' AND codigotipo = 1");
            if (consulta.Rows.Count == 0)
                acessoDB.ExecutarScript($"INSERT INTO Pessoa (CodigoClassificacao, CodigoTipo, Nome, CodigoNacionalidade, CodigoCidade, Desativado, BloquearLimite, ManterValorLimitePadrao, Bloquear_Cliente, LimiteVendas, ManterBloqueioPadrao, BloquearInadimplente, Mora, Multa, Carencia, Isenta_Juros, Juros_Automaticos_Padrao, Permitir_Venda_Prazo, Desconto_Padrao_Cliente, Enderecos) VALUES (1, 1, '{nome}', 35, 1, 'N', 'N', 'S', 'N', 0, 'S', 'N', 0, 0, 0, 'N', 'S', 'S', 0, '')");
        }

        public static void GarantirGrupoDeDescontoExiste(AcessoDB acessoDB, string nomeGrupo, decimal descontoMaximo)
        {
            var consulta = acessoDB.RealizarConsulta($"SELECT * FROM pessoa_grupo WHERE nomegrupo = '{nomeGrupo}' AND desconto_maximo = {descontoMaximo.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            if (consulta.Rows.Count == 0)
                acessoDB.ExecutarScript($"INSERT INTO pessoa_grupo (nomegrupo, desconto_maximo) VALUES ('{nomeGrupo}', {descontoMaximo.ToString(System.Globalization.CultureInfo.InvariantCulture)})");
        }

        public static void LimparCategoriaPorNome(AcessoDB acessoDB, string nome)
        {
            acessoDB.ExecutarScript($"DELETE FROM GRUPO_PRODUTO WHERE DESCRICAO = '{nome}'");
        }

        public static void DesativarPessoaComCpfSeExistir(AcessoDB acessoDB, string cpfFormatado)
        {
            var consulta = acessoDB.RealizarConsulta($"SELECT * FROM pessoa WHERE cpf = '{cpfFormatado}'");
            if (consulta.Rows.Count > 0)
                acessoDB.ExecutarScript($"UPDATE pessoa SET cpf = '', desativado = 'S' WHERE cpf = '{cpfFormatado}'");
        }
    }
}
