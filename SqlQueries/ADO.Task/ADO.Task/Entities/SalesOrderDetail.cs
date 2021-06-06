using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Task.Entities
{
    public class SalesOrderDetail
    {
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
    }
}
