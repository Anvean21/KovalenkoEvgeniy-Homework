using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Task.Entities
{
   public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string  ProductNumber { get; set; }
        public string Color { get; set; }
        public int Weight { get; set; }
        public DateTime SellEndDate { get; set; }

        public Category Category { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
