using BeSpoked.Repo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BeSpoked.Repo
{
    public class SaleRepository : BaseRepository<Sale>
    {
        private readonly BeSpokedContext _context;
        public SaleRepository(BeSpokedContext context)
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<SaleDto> Filter(Func<SaleDto, bool> predicate)
        {
            var items = (from s in _context.Sales
                         join p in _context.Products
                         on s.ProductId equals p.Id
                         join c in _context.Customers
                         on s.CustomerId equals c.Id
                         join sp in _context.Salespersons
                         on s.SalespersonId equals sp.Id
                         select new SaleDto
                         {
                             Id = s.Id,
                             SalesDate = s.SalesDate,
                             ProductId = s.ProductId,
                             Product = p.Name,
                             SalespersonId = s.SalespersonId,
                             Salesperson = $"{sp.FirstName} {sp.LastName}",
                             CustomerId = s.CustomerId,
                             Customer = $"{c.FirstName} {c.LastName}",
                             Price=p.SalePrice,
                             Commission= p.SalePrice*p.CommissionPercentage
                         }).Where(predicate);

            return items;
        }

    }
}
