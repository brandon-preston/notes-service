using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MBP.Services.Notes.DAL.Repositories
{
    public class EFAuthenticationRepository : IAuthenticationRepository
    {
        private readonly Data.NoteContext m_noteContext;

        public EFAuthenticationRepository()
        {
            m_noteContext = new Data.NoteContext();
        }

        public async Task<int> UserAccountCreate(DataTransferObjects.User user, byte[] passwordHash, byte[] passwordSalt)
        {
            Types.UserAccount userAccount = new Types.UserAccount
            {
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await m_noteContext.UserAccount.AddAsync(userAccount);
            await m_noteContext.SaveChangesAsync();

            return userAccount.UserAccountID;
        }

        public async Task<bool> UserExists(string userName)
        {
            if (await m_noteContext.UserAccount.AnyAsync(x => x.UserName.ToLower() == userName.ToLower()))
            {
                return true;
            }

            return false;
        }

        public async Task<Types.UserAccount> UserAccountSelect(string userName)
        {
            return await m_noteContext.UserAccount.FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(userName.ToLower()));
        }        
    }
}