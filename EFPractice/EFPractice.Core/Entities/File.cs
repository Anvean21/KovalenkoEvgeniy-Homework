using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFPractice.Core.Entities
{
    public class File : BaseEntity
    {
        public int DirectoryId { get; set; }
        public string Title { get; set; }
        public string Extention { get; set; }
        public double Size { get; set; }
        public string Type { get; set; }
        public virtual Directory Directory { get; set; }
        public virtual ICollection<FilePermission> FilePermissions { get; set; }
    }
}
