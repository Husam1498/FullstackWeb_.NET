using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CoreProductRepo : GenericRepository<Product, MsSqlContext>, IProductRepository
    {
        MsSqlContext _servis=new MsSqlContext();
        public IEnumerable<Product> GetWithIncludes()
        {
            return _servis.Product
                  .Include(p => p.ProductCategories)
                        .ThenInclude(pc=> pc.Category)
                  .Include(p => p.ProductSizes)
                        .ThenInclude(ps => ps.Size)
                  .Include(p => p.ProductColors)
                        .ThenInclude(ps => ps.Color)
                  .Include(p => p.Photos)
                        
                  .ToList();
        }
    }
}
