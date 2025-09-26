using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _repository;

        public ProductManager(IProductRepository repository)
        {
            _repository = repository;
        }

        public void Create(Product entity)
        {
            _repository.Create(entity);
        }

        public void Delete(Product entity)
        {
            _repository.Delete(entity);
        }

        public void DeletePhoto(int photoId)
        {
            _repository.DeletePhoto(photoId);
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Product GetByGuid(Guid id)
        {
            return _repository.GetByGuid(id);
        }

        public Product GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Product> GetWithIncludes()
        {
            return _repository.GetWithIncludes();
        }

        public Product GetWithIncludesProduct(Guid id)
        {
           return _repository.GetWithIncludesProduct(id);
        }

        public void Update(Product entity)
        {
            _repository.Update(entity);
        }

        public void UpdateProduct(Product product)
        {
            _repository.UpdateProduct(product);
        }
    }
}
