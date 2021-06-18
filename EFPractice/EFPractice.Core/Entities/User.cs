using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.Core.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<DirectoryPermission> DirectoryPermissions { get; set; }
        public virtual ICollection<FilePermission> FilePermissions { get; set; }
    }
}
