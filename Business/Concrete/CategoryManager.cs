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
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _repository;

        public CategoryManager(ICategoryRepository categoryService)
        {
            _repository = categoryService;
        }

        public void CategoryDeleteProduct(int id)
        {
           _repository.CategoryDeleteProduct(id);
        }

        public void Create(Category entity)
        {
           _repository.Create(entity);
        }

        public void Delete(Category entity)
        {
            _repository.Delete(entity);
        }

        public List<Category> GetAll()
        {
           return _repository.GetAll();
        }

        public Category GetByGuid(Guid id)
        {
           return _repository.GetByGuid(id);
        }

        public Category GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Category entity)
        {
            _repository.Update(entity);
        }
    }
}
