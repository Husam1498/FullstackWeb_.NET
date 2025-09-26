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
    public class PhotoManager : IPhotoService
    {
        private IPhotoRepository _repository;

        public PhotoManager(IPhotoRepository repository)
        {
            _repository = repository;
        }

        public void Create(Photo entity)
        {
            _repository.Create(entity);
        }

        public void Delete(Photo entity)
        {
            _repository.Delete(entity);
        }

        public List<Photo> GetAll()
        {
            return _repository.GetAll();
        }

        public Photo GetByGuid(Guid id)
        {
            return _repository.GetByGuid(id);
        }

        public Photo GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Photo entity)
        {
            _repository.Update(entity);
        }
    }
}
