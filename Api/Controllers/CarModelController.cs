using Application.Services;
using AutoMapper;
using Domain;
using Api.Helpers.CustomControllers;
using Api.Helpers.DTOs.CarModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/carmodels")]
    public class CarModelController : CrudBaseController<CarModel, int>
    {
        IMapper mapper;
        CarModelService carModelService;
        public CarModelController(CarModelService _carModelService, IMapper _mapper) : base(_carModelService)
        {
            mapper = _mapper;
            carModelService = _carModelService;
        }
        [HttpGet]
        [EnableCors("corsapp")]
        public ActionResult<List<CarModelDto>> Get()
        {

            return mapper.Map<List<CarModelDto>>(GetAll());
        }
        [HttpGet]
        [Route("{id}")]
        [EnableCors("corsapp")]
        public ActionResult<CarModelDto> Get(int id)
        {
            return mapper.Map<CarModelDto>(FindById(id));
        }
        [HttpGet]
        [Route("{id}")]
        [EnableCors("corsapp")]
        public ActionResult<List<CarModelDto>> GetForBrand(int id)
        {
            return mapper.Map<List<CarModelDto>>(GetAll().Where(cm=>cm.brandId ==id));
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
