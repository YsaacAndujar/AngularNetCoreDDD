using Application.Services;
using AutoMapper;
using Domain;
using Api.Helpers.CustomControllers;
using Api.Helpers.DTOs.CarModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/carmodels")]
    [EnableCors("corsapp")]
    public class CarModelController : CrudBaseController<CarModel, int>
    {
        IMapper mapper;
        public CarModelController(CarModelService _carModelService, IMapper _mapper) : base(_carModelService)
        {
            mapper = _mapper;
        }
        [HttpGet]
        [EnableCors("corsapp")]
        public ActionResult<List<CarModelDto>> Get()
        {

            return mapper.Map<List<CarModelDto>>(GetAll());
        }
        [HttpGet]
        [EnableCors("corsapp")]
        [Route("{id}")]
        public ActionResult<CarModelDto> Get(int id)
        {
            return mapper.Map<CarModelDto>(FindById(id));
        }


        [HttpPost]
        [EnableCors("corsapp")]
        public ActionResult<CarModelDto> Create([FromBody] CarModelCreateDto carModel)
        {
            var entity = mapper.Map<CarModel>(carModel);
            return mapper.Map<CarModelDto>(AddEntity(entity));
        }
        [HttpPut]
        [EnableCors("corsapp")]
        public ActionResult Put(CarModelUpdateDto carModelUpdateDto)
        {
            var entity = mapper.Map<CarModel>(carModelUpdateDto);
            Edit(entity);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        [EnableCors("corsapp")]
        public ActionResult Delete(int id)
        {
            DeleteEntity(id);
            return Ok();
        }
    }
}
