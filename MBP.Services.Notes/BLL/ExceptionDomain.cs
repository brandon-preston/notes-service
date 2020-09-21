using System;
using System.Threading.Tasks;

namespace MBP.Services.Notes.BLL
{
    public class ExceptionDomain
    {
        readonly DAL.Repositories.IExceptionRepository m_exceptionRepository;

        public ExceptionDomain()
        {
            m_exceptionRepository = DAL.Repositories.RepositoryFactory.GetExceptionRepository();
        }

        public async Task ExceptionCreate(Exception ex)
        {
            await m_exceptionRepository.ExceptionCreate(ex);
        }
    }
}