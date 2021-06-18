using System;
using System.Collections.Generic;
using System.Text;

namespace DapperPractice.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public Users User { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OrderJson { get; set; }
    }
}
