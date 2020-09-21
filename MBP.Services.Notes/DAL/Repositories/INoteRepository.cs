using System.Collections.Generic;
using System.Threading.Tasks;

namespace MBP.Services.Notes.DAL.Repositories
{
    public interface INoteRepository
    {
        Task<int> NoteCreate(DataTransferObjects.Note note);

        List<Types.Note> NoteSelectAll(int userAccountID);

        Task<Types.Note> NoteSelect(int noteID);

        Task NoteUpdate(DataTransferObjects.Note note);

        Task NoteDelete(int noteID);
    }
}