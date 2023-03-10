using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces.Repositories;
using Application.Interfaces;

namespace Application.Services
{
    public class BrandService : IBaseService<Brand, int>
    {
        private readonly ICrudRepository<Brand, int> _repository;
        public BrandService(ICrudRepository<Brand, int> repository) { _repository = repository; }
        public Brand AddEntity(Brand entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Brand is required");
            var result = _repository.AddEntity(entity);
            _repository.SaveChanges();
            return result;
        }

        public void Edit(Brand entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Brand is required");
            _repository.Edit(entity);
            _repository.SaveChanges();
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
        public Brand FindById(int id)
        {
            return _repository.FindById(id);
        }

        public List<Brand> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
