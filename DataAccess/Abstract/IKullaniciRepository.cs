using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IKullaniciRepository:IRepository<Kullanicilar>
    {
        public Kullanicilar GetFindusername(string username);
        public bool BoolFindusername(string username);
    }
}
