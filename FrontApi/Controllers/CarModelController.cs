using Application.Services;
using AutoMapper;
using Domain;
using FrontApi.Helpers.CustomControllers;
using FrontApi.Helpers.DTOs.CarModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontApi.Controllers
{
    public class CarModelController : CrudBaseController<CarModel, int>
    {
        IMapper mapper;
        public CarModelController(CarModelService carModelService, IMapper _mapper) : base(carModelService)
        {
            mapper = _mapper;
        }
        [HttpGet]
        public ActionResult<List<CarModelDto>> Get()
        {

            return mapper.Map<List<CarModelDto>>(GetAll());
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<CarModelDto> Get(int id)
        {
            return mapper.Map<CarModelDto>(FindById(id));
        }

        [HttpPost]
        public ActionResult<CarModelDto> Create([FromBody] CarModelCreateDto carModel)
        {
            var entity = mapper.Map<CarModel>(carModel);
            return mapper.Map<CarModelDto>(AddEntity(entity));
        }
        [HttpPut]
        public ActionResult Put(CarModelUpdateDto carModelUpdateDto)
        {
            var entity = mapper.Map<CarModel>(carModelUpdateDto);
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
