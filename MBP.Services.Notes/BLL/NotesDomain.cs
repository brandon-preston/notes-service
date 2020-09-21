using System.Collections.Generic;
using System.Threading.Tasks;

namespace MBP.Services.Notes.BLL
{
    public class NotesDomain
    {
        readonly DAL.Repositories.INoteRepository m_noteRepository;

        public NotesDomain()
        {
            m_noteRepository = DAL.Repositories.RepositoryFactory.GetNoteRepository();
        }

        public async Task<ServiceResponse<int>> NoteCreate(DataTransferObjects.Note note)
        {
            return new ServiceResponse<int>
            {
                Data = await m_noteRepository.NoteCreate(note)
            };
        }

        public ServiceResponse<List<DAL.Types.Note>> NoteSelectAll(int userAccountID)
        {
            return new ServiceResponse<List<DAL.Types.Note>>
            {
                Data = m_noteRepository.NoteSelectAll(userAccountID)
            };
        }

        public async Task<ServiceResponse<DAL.Types.Note>> NoteSelect(int noteID)
        {
            return new ServiceResponse<DAL.Types.Note>
            {
                Data = await m_noteRepository.NoteSelect(noteID)
            };
        }

        public async Task<ServiceResponse> NoteUpdate(DataTransferObjects.Note note)
        {
            ServiceResponse serviceResponse = new ServiceResponse();

            if (await m_noteRepository.NoteSelect(note.NoteID) != null)
            {
                await m_noteRepository.NoteUpdate(note);
            }
            else
            {
                serviceResponse.ServiceResponseType = ServiceResponseType.NoteNotFound;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse> NoteDelete(int noteID)
        {
            ServiceResponse serviceResponse = new ServiceResponse();

            if (await m_noteRepository.NoteSelect(noteID) != null)
            {
                await m_noteRepository.NoteDelete(noteID);
            }
            else
            {
                serviceResponse.ServiceResponseType = ServiceResponseType.NoteNotFound;
            }

            return serviceResponse;
        }
    }
}