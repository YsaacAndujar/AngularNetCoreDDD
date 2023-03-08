using Domain;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CarRepository : ICrudRepository<Car, int>
    {
        CarsContext db;
        public CarRepository(CarsContext _db)
        {
            db = _db;
        }
        public Car AddEntity(Car entity)
        {
            db.Car.Add(entity);
            return entity;
        }

        public void Edit(Car entity)
        {
            var entitySelected = db.Car.Where(c => c.id == entity.id).FirstOrDefault();
            if(entitySelected == null)
            {
                return;
            }

        }

        public Car FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
