using Domain.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class BrandRepository : ICrudRepository<Brand, int>
    {
        public Brand AddEntity(Brand entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Brand entity)
        {
            throw new NotImplementedException();
        }

        public Brand FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
