using System.Threading.Tasks;

namespace MBP.Services.Notes.DAL.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<int> UserAccountCreate(DataTransferObjects.User user, byte[] passwordHash, byte[] passwordSalt);

        Task<bool> UserExists(string userName);

        Task<Types.UserAccount> UserAccountSelect(string userName);
    }
}