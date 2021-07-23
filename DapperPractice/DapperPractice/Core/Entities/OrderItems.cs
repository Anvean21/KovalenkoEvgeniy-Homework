using System;
using System.Collections.Generic;
using System.Text;

namespace DapperPractice.Entities
{
    public class OrderItems
    {
        public virtual ICollection<Products> Products { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public int Quantity { get; set; }
    }
}
