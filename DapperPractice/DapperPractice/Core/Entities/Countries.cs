using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DapperPractice.Entities
{
   public class Countries
    {
        [Key]
        public string CountryCode { get; set; }
        public string Name { get; set; }
    }
}
