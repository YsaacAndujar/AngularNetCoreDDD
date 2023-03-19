using Domain.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CarModelRepository : ICrudRepository<CarModel, int>
    {
        CarsContext db;
        public CarModelRepository(CarsContext _db)
        {
            db = _db;
        }
        public CarModel AddEntity(CarModel entity)
        {
            db.CarModels.Add(entity);
            return entity;
        }

        public void Edit(CarModel entity)
        {
            var entityDb = db.CarModels.Find(entity.id);
            if (entityDb == null)
            {
                return;
            }
            var brand = db.Brands.Find(entity.brandId);
            if(brand == null)
            {
                throw new ArgumentException("Brand is required or does not exist");
            }
            entityDb.name = entity.name;
            entityDb.brandId = brand.id;
            entityDb.brand = brand;
            //db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public CarModel FindById(int id)
        {
            return db.CarModels.Find(id);
        }

        public List<CarModel> GetAll()
        {
            return db.CarModels.Include(cm => cm.brand).OrderBy(cm => cm.id).ToList();
        }
        public void Delete(int id)
        {
            var entity = FindById(id);
            if (entity == null) { return; }
            db.Remove(entity);
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
