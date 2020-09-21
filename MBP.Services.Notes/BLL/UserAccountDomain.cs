using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MBP.Services.Notes.BLL
{
    public class UserAccountDomain
    {
        readonly DAL.Repositories.IAuthenticationRepository m_authenticationRepository;

        public UserAccountDomain()
        {
            m_authenticationRepository = DAL.Repositories.RepositoryFactory.GetAuthenticationRepository();
        }

        public async Task<ServiceResponse<int>> UserAccountCreate(DataTransferObjects.User user)
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();

            if (await m_authenticationRepository.UserExists(user.UserName))
            {
                serviceResponse.ServiceResponseType = ServiceResponseType.UserAccountAlreadyExists;

                return serviceResponse;
            }

            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            int userAccountID = await m_authenticationRepository.UserAccountCreate(user, passwordHash, passwordSalt);
            serviceResponse.Data = userAccountID;

            return serviceResponse;
        }

        public async Task<ServiceResponse<int>> Login(DataTransferObjects.User user)
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();

            DAL.Types.UserAccount userAccount = await m_authenticationRepository.UserAccountSelect(user.UserName);
            if (userAccount == null)
            {
                serviceResponse.ServiceResponseType = ServiceResponseType.UserAccountNotFound;

                return serviceResponse;
            }
            else if (!VerifyPasswordHash(user.Password, userAccount.PasswordHash, userAccount.PasswordSalt))
            {
                serviceResponse.ServiceResponseType = ServiceResponseType.UserAccountIncorrectPassword;

                return serviceResponse;
            }
            else
            {
                serviceResponse.Data = userAccount.UserAccountID;
            }

            serviceResponse.Data = userAccount.UserAccountID;

            return serviceResponse;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            HMACSHA512 hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            HMACSHA512 hmac = new HMACSHA512(passwordSalt);
            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}