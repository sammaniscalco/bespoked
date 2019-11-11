using System;
using System.Collections.Generic;
using System.Text;

namespace BeSpoked.Repo.Models
{
    public class SaleDto: Entity
    {
        public long ProductId { get; set; }
        public string Product { get; set; }
        public long SalespersonId { get; set; }
        public string Salesperson { get; set; }
        public long CustomerId { get; set; }
        public string Customer { get; set; }
        public DateTime SalesDate { get; set; }
        public double Price { get; set; }
        public double Commission { get; set; }
    }
}
