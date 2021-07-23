using System;
using System.Collections.Generic;
using System.Text;

namespace DapperPractice.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public Merchants Merchant { get; set; }
        public int MerchantId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
