namespace SigecomTestesUI2.Services.DbSetup
{
    public class ConfigGeralBackup : ConfigBackup
    {
        public ConfigGeralBackup(AcessoDB acessoDB) : base(acessoDB) { }

        protected override string Tabela => "config";
    }
}
