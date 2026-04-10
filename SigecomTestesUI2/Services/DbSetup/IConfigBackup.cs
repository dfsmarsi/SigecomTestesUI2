namespace SigecomTestesUI2.Services.DbSetup
{
    public interface IConfigBackup
    {
        void Salvar(string coluna);
        void RestaurarTudo();
    }
}
