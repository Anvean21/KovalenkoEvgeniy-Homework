using DapperTask.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperTask.BLL
{
    public interface IHidingService
    {
        public void GetByEmail(string email);
    }
}
