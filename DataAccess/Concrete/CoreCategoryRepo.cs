using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete
{
    public class CoreCategoryRepo : GenericRepository<Category, MsSqlContext>, ICategoryRepository
    {
        MsSqlContext _context =new MsSqlContext();
        CoreProductRepo _productRepo = new CoreProductRepo();

        public void CategoryDeleteProduct(int id)
        {
           // ilişkili product categorileri silme
           var productCategories= _context.ProductCategory
                .Where(pc => pc.CategoryId == id)
                .ToList();
            _context.RemoveRange(productCategories);

            //Bu kategoriye bağlı productları bul
            var productIds= productCategories
                .Select(pc =>pc.ProductId)
                .ToList();
            //tek bir catgeoriye sahip olan ürünler silinir
            var productDelete=_context.Product
                .Where(p=> productIds.Contains(p.ProductId))
                .Where(p => _context.ProductCategory.Count(pc => pc.ProductId == p.ProductId) == 1)
                .ToList();

            if (productDelete != null) {
                foreach (var product in productDelete) {
                    var incudesProduct=_productRepo.GetWithIncludesProduct(product.ProductId);
                    _context.ProductColor.RemoveRange(_context.ProductColor.Where(pc => pc.ProductId == incudesProduct.ProductId));
                    _context.ProductSize.RemoveRange(_context.ProductSize.Where(ps => ps.ProductId == incudesProduct.ProductId));                   
                    foreach (var p in incudesProduct.Photos)
                    {
                        //_context.Photo.Remove(p);                                          
                        var filePath = Path.Combine("wwwroot/uploads/ProductsPhoto", p.url);
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                    }
                    _context.Product.Remove(incudesProduct);
                }
            }

            // catgoriyi sil
            var catgory = _context.Category.Find(id);
            if(catgory != null)
            {
                _context.Category.Remove(catgory);
                _context.SaveChanges();
            }

           
        }
    }
}
