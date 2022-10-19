using System;
using System.ComponentModel.DataAnnotations;

namespace Alliance_API.Models
{
    public class HRUser
    {

        [Key]
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}

