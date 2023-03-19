using Domain;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
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
            var cm = db.CarModels.Find(entity.carModelId);
            if (cm == null) { throw new ArgumentException("Car Model is required or does not exist"); }
            entityDb.year = entity.year;
            entityDb.carModelId = cm.id;
            entityDb.carModel = cm;
            //db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Car FindById(int id)
        {
            return db.Car.Find(id);
        }

        public List<Car> GetAll()
        {
            return db.Car.Include(c => c.carModel).ThenInclude(cm => cm.brand).ToList();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
