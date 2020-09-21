using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBP.Services.Notes.DAL.Types
{
    public class Note
    {
        public int NoteID { get; set; }

        public int UserAccountID { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public UserAccount UserAccount { get; set; }
    }
}