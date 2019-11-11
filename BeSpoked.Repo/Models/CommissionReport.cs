using System;
using System.Collections.Generic;
using System.Text;

namespace BeSpoked.Repo.Models
{
    public class CommissionReport
    {
        public string Salesperson { get; set; }
        public int Quarter { get; set; }
        public double Commission { get; set; }
    }
}
