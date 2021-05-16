using System;
using System.Collections.Generic;
using System.Text;

namespace LinqClassPractice
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public double Balance { get; set; }
        public Customer(int id, string name, DateTime registrationDate, double balance)
        {
            this.Id = id;
            this.Name = name;
            this.RegistrationDate = registrationDate;
            this.Balance = balance;
        }
    }
}
