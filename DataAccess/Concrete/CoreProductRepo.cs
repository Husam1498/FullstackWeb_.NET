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
        MsSqlContext _servis = new MsSqlContext();

        public void DeletePhoto(int photoId)
        {
            var photo = _servis.Photo.FirstOrDefault(p => p.PhotoId == photoId);
            if (photo != null)
            {
                // 1. Veritabanından sil
                _servis.Photo.Remove(photo);
                _servis.SaveChanges();

                // 2. Fiziksel dosyayı da sil
                var filePath = Path.Combine("wwwroot/uploads/ProductsPhoto", photo.url);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        public IEnumerable<Product> GetWithIncludes()
        {
            return _servis.Product
                  .Include(p => p.ProductCategories)
                        .ThenInclude(pc => pc.Category)
                  .Include(p => p.ProductSizes)
                        .ThenInclude(ps => ps.Size)
                  .Include(p => p.ProductColors)
                        .ThenInclude(ps => ps.Color)
                  .Include(p => p.Photos)

                  .ToList();
        }

        public Product GetWithIncludesProduct(Guid id)
        {
            return _servis.Product
                  .Include(p => p.ProductCategories)
                        .ThenInclude(pc => pc.Category)
                  .Include(p => p.ProductSizes)
                        .ThenInclude(ps => ps.Size)
                  .Include(p => p.ProductColors)
                        .ThenInclude(ps => ps.Color)
                  .Include(p => p.Photos)

                  .FirstOrDefault(p => p.ProductId == id);

        }

        public void UpdateProduct(Product updatedProduct)
        {


            var existingProduct = GetWithIncludesProduct(updatedProduct.ProductId);
            if (existingProduct == null) return;

            existingProduct.ProductName = updatedProduct.ProductName;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;

            //// Eski ilişkileri sil
            _servis.ProductCategory.RemoveRange(_servis.ProductCategory.Where(pc => pc.ProductId == updatedProduct.ProductId));
            _servis.ProductColor.RemoveRange(_servis.ProductColor.Where(pc => pc.ProductId == updatedProduct.ProductId));
            _servis.ProductSize.RemoveRange(_servis.ProductSize.Where(ps => ps.ProductId == updatedProduct.ProductId));
            //_servis.Photo.RemoveRange(_servis.Photo.Where(p => p.ProductId == updatedProduct.ProductId));

            // Yeni ilişkileri ekle
            foreach (var pc in updatedProduct.ProductCategories)
                pc.ProductId = updatedProduct.ProductId;
            _servis.ProductCategory.AddRange(updatedProduct.ProductCategories);

            foreach (var pc in updatedProduct.ProductColors)
                pc.ProductId = updatedProduct.ProductId;
            _servis.ProductColor.AddRange(updatedProduct.ProductColors);

            foreach (var ps in updatedProduct.ProductSizes)
                ps.ProductId = updatedProduct.ProductId;
            _servis.ProductSize.AddRange(updatedProduct.ProductSizes);

            // Fotoğraflar için güvenli ekleme
            //var newPhotos = new List<Photo>();
            //foreach (var photo in updatedProduct.Photos)
            //{
            //    newPhotos.Add(new Photo
            //    {
            //        url = photo.url,
            //        ProductId = updatedProduct.ProductId
            //        // PhotoId yok!
            //    });
            //}
            //_servis.Photo.AddRange(newPhotos);
            _servis.SaveChanges();
        }
    }
}
