namespace MBP.Services.Notes.BLL
{
    public enum ServiceResponseType
    {
        Success = 1,
        UserAccountAlreadyExists = 2,
        UserAccountNotFound = 3,
        UserAccountIncorrectPassword = 4,
        NoteNotFound = 5
    }
}