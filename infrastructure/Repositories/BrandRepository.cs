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
    internal class BrandRepository : ICrudRepository<Brand, int>
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
            db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        }

        public Brand FindById(int id)
        {
            return db.Brands.Find(id);
        }

        public List<Brand> GetAll()
        {
            return db.Brands.ToList();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
