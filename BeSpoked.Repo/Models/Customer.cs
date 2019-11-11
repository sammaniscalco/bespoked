using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeSpoked.Repo.Models
{
    public class Customer:Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone{ get; set; }
        public DateTime StartDate { get; set; }
    }
}
