using Application.Services;
using AutoMapper;
using Domain;
using FrontApi.Helpers.CustomControllers;
using FrontApi.Helpers.DTOs.Brand;
using Microsoft.AspNetCore.Mvc;

namespace FrontApi.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : CrudBaseController<Brand, int>
    {
        IMapper mapper;
        public BrandController(BrandService brandService, IMapper _mapper): base(brandService)
        {
            mapper = _mapper;
        }
        [HttpGet]
        public ActionResult<List<BrandDto>> Get()
        {

            return mapper.Map<List<BrandDto>>(GetAll());
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<BrandDto> Get(int id)
        {
            return mapper.Map<BrandDto>(FindById(id));
        }

        [HttpPost]
        public ActionResult<BrandDto> Create([FromBody] BrandCreateDto brand)
        {
            var entity = mapper.Map<Brand>(brand);
            return mapper.Map<BrandDto>(AddEntity(entity));
        }
        [HttpPut]
        public ActionResult Put(BrandUpdateDto brandUpdateDto)
        {
            var entity = mapper.Map<Brand>(brandUpdateDto);
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
