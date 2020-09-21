namespace MBP.Services.Notes.DataTransferObjects
{
    public class Note
    {
        public int NoteID { get; set; }

        public int UserAccountID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }
    }
}
