using Application.Services;
using AutoMapper;
using Domain;
using FrontApi.Helpers.CustomControllers;
using FrontApi.Helpers.DTOs.Car;
using Microsoft.AspNetCore.Mvc;

namespace FrontApi.Controllers
{
    public class CarController : CrudBaseController<Car, int>
    {
        IMapper mapper;
        public CarController(CarService carService, IMapper _mapper) : base(carService)
        {
            mapper = _mapper;
        }
        [HttpGet]
        public ActionResult<List<CarDto>> Get()
        {

            return mapper.Map<List<CarDto>>(GetAll());
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<CarDto> Get(int id)
        {
            return mapper.Map<CarDto>(FindById(id));
        }

        [HttpPost]
        public ActionResult<CarDto> Create([FromBody] CarCreateDto car)
        {
            var entity = mapper.Map<Car>(car);
            return mapper.Map<CarDto>(AddEntity(entity));
        }
        [HttpPut]
        public ActionResult Put(CarUpdateDto carUpdateDto)
        {
            var entity = mapper.Map<Car>(carUpdateDto);
            Edit(entity);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            Delete(id);
            return Ok();
        }
    }
}
