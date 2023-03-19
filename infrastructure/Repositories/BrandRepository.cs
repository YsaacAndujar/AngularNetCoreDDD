using Domain.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class BrandRepository : ICrudRepository<Brand, int>
    {
        CarsContext db;
        public BrandRepository(CarsContext _db)
        {
            db = _db;
        }
        public Brand AddEntity(Brand entity)
        {
            db.Brands.Add(entity);
            return entity;
        }

        public void Edit(Brand entity)
        {
            var entityDb = db.Brands.Find(entity.id);
            if(entityDb == null)
            {
                return;
            }
            entityDb.name = entity.name;
            //db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }

        public Brand FindById(int id)
        {
            return db.Brands.Find(id);
        }

        public List<Brand> GetAll()
        {
            return db.Brands.OrderBy(b => b.id).ToList();
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
