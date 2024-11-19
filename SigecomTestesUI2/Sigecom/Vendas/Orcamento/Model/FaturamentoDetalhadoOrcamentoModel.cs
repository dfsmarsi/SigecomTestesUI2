using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigecomTestesUI2.Sigecom.Vendas.Orcamento.Model
{
    public class FaturamentoDetalhadoOrcamentoModel
    {
        public string ScriptHabilitarFaturamentoDetalhado = "update empresa_host_config set geral_impressao = '{\"ImpressaoDeColunasEmOsOrcamentoPedido\":0,\"ConfiguracaoDeColunasNaImpressaoTermica\":0,\"ImpressoraTermicaPadrao\":\"\",\"EtiquetadoraPadrao\":\"\",\"ExibirNomeInteiroDoProdutoNaImpressao\":false,\"FaturamentoRapido\":true}'";
        public string ScriptDesabilitarFaturamentoDetalhado = "update empresa_host_config set geral_impressao = '{\"ImpressaoDeColunasEmOsOrcamentoPedido\":0,\"ConfiguracaoDeColunasNaImpressaoTermica\":0,\"ImpressoraTermicaPadrao\":\"\",\"EtiquetadoraPadrao\":\"\",\"ExibirNomeInteiroDoProdutoNaImpressao\":false,\"FaturamentoRapido\":false}'";
    }
}
