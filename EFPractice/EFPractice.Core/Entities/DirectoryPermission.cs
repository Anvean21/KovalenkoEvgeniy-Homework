using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.Core.Entities
{
    public class DirectoryPermission
    {
        public int DirectoryId { get; set; }
        public virtual Directory Directory { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
    }
}
