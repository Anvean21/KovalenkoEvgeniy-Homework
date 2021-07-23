using System;
using System.Collections.Generic;
using System.Text;

namespace DapperPractice.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public virtual Countries Country { get; set; }
        public string CountryCode { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
