using Domain.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Services
{
    public class CarModelService : IBaseService<CarModel, int>
    {
        private readonly ICrudRepository<CarModel, int> _carModelRepository;
        private readonly ICrudRepository<Brand, int> _brandRepository;
        public CarModelService(ICrudRepository<CarModel, int> repository, ICrudRepository<Brand, int> brandRepository) { 
            _carModelRepository = repository;
            _brandRepository = brandRepository;
        }
        public CarModel AddEntity(CarModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException("CarModel is required"); 
            if (_brandRepository.FindById(entity.brandId) == null)
                throw new ArgumentNullException("Brand is required");
            var result = _carModelRepository.AddEntity(entity);
            _carModelRepository.SaveChanges();
            return result;
        }

        public void Edit(CarModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException("CarModel is required");
            if (_brandRepository.FindById(entity.brandId) == null)
                throw new ArgumentNullException("Brand is required");
            _carModelRepository.Edit(entity);
            _carModelRepository.SaveChanges();
        }
        public void Delete(int id)
        {
            _carModelRepository.Delete(id);
            _carModelRepository.SaveChanges();
        }
        public CarModel FindById(int id)
        {
            return _carModelRepository.FindById(id);
        }

        public List<CarModel> GetAll()
        {
            return _carModelRepository.GetAll();
        }
    }
}
