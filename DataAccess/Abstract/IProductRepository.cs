using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        IEnumerable<Product> GetWithIncludes();
        Product GetWithIncludesProduct(Guid id);
        void UpdateProduct(Product product);
        void DeletePhoto(int photoId);
    }
}
