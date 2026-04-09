using Microsoft.Extensions.Configuration;

namespace SigecomTestesUI2
{
    public static class Configuracao
    {
        public static IConfiguration Instancia { get; } = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
    }
}
