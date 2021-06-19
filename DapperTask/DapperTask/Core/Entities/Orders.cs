using DapperTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperTask.Entities
{
    public class Orders : BasicEntity
    {
        public Users User { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        public string OrderJson { get; set; }
    }
}
