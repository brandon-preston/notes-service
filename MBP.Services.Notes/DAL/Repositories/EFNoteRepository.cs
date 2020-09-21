using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBP.Services.Notes.DAL.Repositories
{
    public class EFNoteRepository : INoteRepository
    {
        private readonly Data.NoteContext m_noteContext;

        public EFNoteRepository()
        {
            m_noteContext = new Data.NoteContext();
        }

        public async Task<int> NoteCreate(DataTransferObjects.Note note)
        {
            Types.Note newNote = new Types.Note
            {
                Name = note.Name,
                UserAccountID = note.UserAccountID,
                Type = note.Type,
                Text = note.Text
            };

            await m_noteContext.Note.AddAsync(newNote);
            await m_noteContext.SaveChangesAsync();

            return newNote.NoteID;
        }

        public List<Types.Note> NoteSelectAll(int userAccountID)
        {
            return m_noteContext.Note.Where(x => x.UserAccountID == userAccountID).ToList();
        }

        public async Task<Types.Note> NoteSelect(int noteID)
        {
            return await m_noteContext.Note.FirstOrDefaultAsync(x => x.NoteID == noteID);
        }        

        public async Task NoteUpdate(DataTransferObjects.Note note)
        {
            Types.Note noteToUpdate = await m_noteContext.Note.FirstOrDefaultAsync(x => x.NoteID == note.NoteID);

            noteToUpdate.Name = note.Name;
            noteToUpdate.Type = note.Type;
            noteToUpdate.Text = note.Text;
            noteToUpdate.UpdateDate = DateTime.Now;

            m_noteContext.Update(noteToUpdate);
            await m_noteContext.SaveChangesAsync();
        }

        public async Task NoteDelete(int noteID)
        {
            Types.Note noteToDelete = await m_noteContext.Note.FirstOrDefaultAsync(x => x.NoteID == noteID);
            
            m_noteContext.Note.Remove(noteToDelete);
            await m_noteContext.SaveChangesAsync();
        }
    }
}