using DapperTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperTask.Entities
{
    public class Products : BasicEntity
    {
        public Merchants Merchant { get; set; }
        public int MerchantId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
    }
}
