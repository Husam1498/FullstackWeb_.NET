using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CoreCategoryRepo:GenericRepository<Category,MsSqlContext>,ICategoryRepository
    {
    }
}
