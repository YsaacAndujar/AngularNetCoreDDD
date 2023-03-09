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
            var entityDb = db.Car.Find(entity.id);
            if (entityDb == null)
            {
                return;
            }
            db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Car FindById(int id)
        {
            return db.Car.Find(id);
        }

        public List<Car> GetAll()
        {
            return db.Car.ToList();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
