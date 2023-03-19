using Application.Services;
using AutoMapper;
using Domain;
using Api.Helpers.CustomControllers;
using Api.Helpers.DTOs.Car;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : CrudBaseController<Car, int>
    {
        IMapper mapper;
        public CarController(CarService carService, IMapper _mapper) : base(carService)
        {
            mapper = _mapper;
        }
        [HttpGet]
        [EnableCors("corsapp")]
        public ActionResult<List<CarDto>> Get()
        {

            return mapper.Map<List<CarDto>>(GetAll());
        }
        [HttpGet]
        [Route("{id}")]
        [EnableCors("corsapp")]
        public ActionResult<CarDto> Get(int id)
        {
            return mapper.Map<CarDto>(FindById(id));
        }

        [HttpPost]
        [EnableCors("corsapp")]
        public ActionResult<CarDto> Create([FromBody] CarCreateDto car)
        {
            var entity = mapper.Map<Car>(car);
            return mapper.Map<CarDto>(AddEntity(entity));
        }
        [HttpPut]
        [EnableCors("corsapp")]
        public ActionResult Put(CarUpdateDto carUpdateDto)
        {
            var entity = mapper.Map<Car>(carUpdateDto);
            Edit(entity);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        [EnableCors("corsapp")]
        public ActionResult Delete(int id)
        {
            Delete(id);
            return Ok();
        }
    }
}
