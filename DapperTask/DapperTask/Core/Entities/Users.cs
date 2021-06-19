using DapperTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperTask.Entities
{
    public class Users : BasicEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string DateOfBirthday { get; set; }
        public string CountryCode { get; set; }
        public string CreatedAt { get; set; }
    }
}
