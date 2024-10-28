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
    public class CoreKullanicilarRepo : GenericRepository<Kullanicilar, MsSqlContext>, IKullaniciRepository
    {
        private MsSqlContext _context =new MsSqlContext();  
        public Kullanicilar GetFindusername(string username)
        {
           
             //Using kullanmamın sebebi işlem bittikten sonra hafızadan silsin
              var user= _context.Kullanicilar
                    .FirstOrDefault(u=>u.Username.ToLower() == username);

            return user ?? null;
        }
        //Uername isimli kullanıcı varsa
        
        public bool BoolFindusername(string username)
        {
           
             //Using kullanmamın sebebi işlem bittikten sonra hafızadan silsin
               return _context.Kullanicilar
                    .Any(u=>u.Username.ToLower() == username.ToLower());            

        }

    }
}
