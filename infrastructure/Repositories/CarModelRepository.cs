using Domain.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class CarModelRepository : ICrudRepository<CarModel, int>
    {
        public CarModel AddEntity(CarModel entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(CarModel entity)
        {
            throw new NotImplementedException();
        }

        public CarModel FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
