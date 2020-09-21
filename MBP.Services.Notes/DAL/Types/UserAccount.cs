using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBP.Services.Notes.DAL.Types
{
    public class UserAccount
    {
        public int UserAccountID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; }
    }
}