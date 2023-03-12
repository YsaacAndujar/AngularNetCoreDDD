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
    public class CarService : IBaseService<Car, int>
    {
        private readonly ICrudRepository<CarModel, int> _carModelRepository;
        private readonly ICrudRepository<Car, int> _carRepository;
        public CarService(ICrudRepository<CarModel, int> carModelRepository, ICrudRepository<Car, int> carRepository)
        {
            _carRepository = carRepository;
            _carModelRepository = carModelRepository;
        }
        public Car AddEntity(Car entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Car is required");
            if (_carModelRepository.FindById(entity.carModelId) == null)
                throw new ArgumentNullException("Model is required");
            var result = _carRepository.AddEntity(entity);
            _carRepository.SaveChanges();
            return result;
        }

        public void Edit(Car entity)
        {
            if (entity == null)
                throw new ArgumentNullException("CarModel is required");
            if (_carModelRepository.FindById(entity.carModelId) == null)
                throw new ArgumentNullException("CarModel is required");
            _carRepository.Edit(entity);
            _carRepository.SaveChanges();
        }
        public void Delete(int id)
        {
            _carRepository.Delete(id);
            _carRepository.SaveChanges();
        }
        public Car FindById(int id)
        {
            return _carRepository.FindById(id);
        }

        public List<Car> GetAll()
        {
            return _carRepository.GetAll();
        }
    }
}
