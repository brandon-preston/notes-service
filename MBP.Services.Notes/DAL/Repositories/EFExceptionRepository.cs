using System;
using System.Threading.Tasks;

namespace MBP.Services.Notes.DAL.Repositories
{
    public class EFExceptionRepository : IExceptionRepository
    {
        private readonly Data.NoteContext m_noteContext;

        public EFExceptionRepository()
        {
            m_noteContext = new Data.NoteContext();
        }

        public async Task ExceptionCreate(Exception ex)
        {
            Types.Exception exception = new Types.Exception
            {
                Type = ex.GetType().Name,
                Message = ex.Message,
                StackTrace = ex.ToString()
            };

            await m_noteContext.Exception.AddAsync(exception);
            await m_noteContext.SaveChangesAsync();
        }
    }
}