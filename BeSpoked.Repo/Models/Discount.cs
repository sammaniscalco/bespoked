using System;
using System.Collections.Generic;
using System.Text;

namespace BeSpoked.Repo.Models
{
    public class Discount : Entity
    {
        public long ProductId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
