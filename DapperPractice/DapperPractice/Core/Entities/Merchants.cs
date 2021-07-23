using System;
using System.Collections.Generic;
using System.Text;

namespace DapperPractice.Entities
{
    public class Merchants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Countries Country { get; set; }
        public string CountryCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Users User { get; set; }
        public int? UserId { get; set; }
    }
}
