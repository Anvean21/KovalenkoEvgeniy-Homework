using DapperTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperTask.Entities
{
    public class Merchants: BasicEntity
    {
        public string Name { get; set; }
        public virtual Countries Country { get; set; }
        public string CountryCode { get; set; }
        public string CreatedAt { get; set; }
        public virtual Users User { get; set; }
        public int? UserId { get; set; }
    }
}
