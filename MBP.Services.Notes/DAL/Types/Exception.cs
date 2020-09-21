using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBP.Services.Notes.DAL.Types
{
    public class Exception
    {
        public int ExceptionID { get; set; }

        public string Type { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; }
    }
}