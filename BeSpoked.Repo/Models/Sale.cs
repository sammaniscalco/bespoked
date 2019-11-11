using System;
using System.Collections.Generic;
using System.Text;

namespace BeSpoked.Repo.Models
{
    public class Sale: Entity
    {
        public long ProductId { get; set; }
        public long SalespersonId { get; set; }
        public long CustomerId { get; set; }
        public DateTime SalesDate { get; set; }
    }
}
