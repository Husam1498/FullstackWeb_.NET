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
    public class SizesManager : ISizesService
    {
        private ISizesRepository _repository;

        public SizesManager(ISizesRepository sizesRepository)
        {
            _repository = sizesRepository;
        }

        public void Create(Sizes entity)
        {
            _repository.Create(entity);
        }

        public void Delete(Sizes entity)
        {
            _repository.Delete(entity);
        }

        public List<Sizes> GetAll()
        {
            return _repository.GetAll();
        }

        public Sizes GetByGuid(Guid id)
        {
            return _repository.GetByGuid(id);
        }

        public Sizes GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Sizes entity)
        {
            _repository.Update(entity);
        }
    }
}
