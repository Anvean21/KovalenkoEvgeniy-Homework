using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFPractice.Core.Entities
{
    public class Directory: BaseEntity
    {
        public int? ParentDirectoryId { get; set; }
        public virtual Directory ParentDirectory { get; set; }
        public string Title { get; set; }
        public virtual ICollection<DirectoryPermission> DirectoryPermissions { get; set; }
        public virtual ICollection<Directory> Directories { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
