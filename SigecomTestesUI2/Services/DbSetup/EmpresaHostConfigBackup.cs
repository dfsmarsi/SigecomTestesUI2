namespace SigecomTestesUI2.Services.DbSetup
{
    public class EmpresaHostConfigBackup : ConfigBackup
    {
        public EmpresaHostConfigBackup(AcessoDB acessoDB) : base(acessoDB) { }

        protected override string Tabela => "empresa_host_config";
    }
}
