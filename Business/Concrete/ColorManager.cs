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
    public class ColorManager : IColorService
    {
        private IColorsRepository  _repository;

        public ColorManager(IColorsRepository repository)
        {
            _repository = repository;
        }

        public void Create(Colors entity)
        {
            _repository.Create(entity);
        }

        public void Delete(Colors entity)
        {
            _repository.Delete(entity);
        }

        public List<Colors> GetAll()
        {
            return _repository.GetAll();
        }

        public Colors GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Colors entity)
        {
            _repository.Update(entity);
        }
    }
}
