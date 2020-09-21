using System;
using System.Threading.Tasks;

namespace MBP.Services.Notes.DAL.Repositories
{
    public interface IExceptionRepository
    {
        Task ExceptionCreate(Exception ex);
    }
}