using Microsoft.Extensions.Configuration;

namespace MBP.Services.Notes.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot ConfigurationRoot()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            return configurationBuilder.Build();
        }

        public static string ConnectionString(string name)
        {            
            return ConfigurationRoot().GetConnectionString(name);
        }
    }
}