using Business.Abstract;
using DataAccess.Abstract;
using Entities;


namespace Business.Concrete
{
    public class KullaniciManager : IKullaniciService
    {

        private IKullaniciRepository _kullaniciRepository;

        public KullaniciManager(IKullaniciRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }

        public bool BoolFindusername(string username)
        {
            return _kullaniciRepository.BoolFindusername(username);
        }

        public void Create(Kullanicilar entity)
        {
           _kullaniciRepository.Create(entity);
        }

        public void Delete(Kullanicilar entity)
        {
            _kullaniciRepository.Delete(entity);
        }

        public List<Kullanicilar> GetAll()
        {
            return _kullaniciRepository.GetAll();
        }

        public Kullanicilar GetById(int id)
        {
           return _kullaniciRepository.GetById(id);
        }

        public Kullanicilar GetFindusername(string username)
        {
            return _kullaniciRepository.GetFindusername(username);
        }

        public void Update(Kullanicilar entity)
        {
           _kullaniciRepository.Update(entity);
        }
    }
}
