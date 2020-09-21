using MBP.Services.Notes.Helpers;
using Microsoft.Extensions.Configuration;

namespace MBP.Services.Notes.DAL.Repositories
{
    public static class RepositoryFactory
    {
        public static IAuthenticationRepository GetAuthenticationRepository()
        {
            IConfigurationRoot configurationRoot = ConfigurationHelper.ConfigurationRoot();
            string repositoryType = configurationRoot["RepositoryType"];

            switch (repositoryType)
            {
                case "EF":
                    return new EFAuthenticationRepository();
                default:
                    return new EFAuthenticationRepository();
            }
        }

        public static INoteRepository GetNoteRepository()
        {
            IConfigurationRoot configurationRoot = ConfigurationHelper.ConfigurationRoot();
            string repositoryType = configurationRoot["RepositoryType"];

            switch (repositoryType)
            {
                case "EF":
                    return new EFNoteRepository();
                default:
                    return new EFNoteRepository();
            }
        }

        public static IExceptionRepository GetExceptionRepository()
        {
            IConfigurationRoot configurationRoot = ConfigurationHelper.ConfigurationRoot();
            string repositoryType = configurationRoot["RepositoryType"];

            switch (repositoryType)
            {
                case "EF":
                    return new EFExceptionRepository();
                default:
                    return new EFExceptionRepository();
            }
        }
    }
}