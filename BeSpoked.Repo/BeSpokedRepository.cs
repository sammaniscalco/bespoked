using BeSpoked.Repo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BeSpoked.Repo
{
    public class BeSpokedRepository
    {
        private readonly BeSpokedContext _context;

        public BeSpokedRepository(BeSpokedContext context)
        {
            _context = context;
        }

        public IEnumerable<CommissionReport> GetCommissionReport()
        {
            var items = (from s in _context.Sales
                         join p in _context.Products
                         on s.ProductId equals p.Id
                         join sp in _context.Salespersons
                         on s.SalespersonId equals sp.Id
                         group new { s.Id, p.SalePrice, p.CommissionPercentage } by
                         new Tuple<string, int>($"{sp.FirstName} {sp.LastName}", s.SalesDate.Month < 4 ? 1 : s.SalesDate.Month < 7 ? 2 : s.SalesDate.Month < 10 ? 3 : 4) into spGroup
                         select new CommissionReport
                         {
                             Salesperson = spGroup.Key.Item1,
                             Quarter = spGroup.Key.Item2,
                             Commission = spGroup.Sum(x => (x.SalePrice * x.CommissionPercentage))
                         });

            return items;
        }
    }
}
