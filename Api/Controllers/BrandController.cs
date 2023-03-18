using Application.Services;
using AutoMapper;
using Domain;
using Api.Helpers.CustomControllers;
using Api.Helpers.DTOs.Brand;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Api.Controllers
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
        [EnableCors("corsapp")]
        public ActionResult<List<BrandDto>> Get()
        {

            return mapper.Map<List<BrandDto>>(GetAll());
        }
        [HttpGet]
        [EnableCors("corsapp")]
        [Route("{id}")]
        public ActionResult<BrandDto> Get(int id)
        {
            return mapper.Map<BrandDto>(FindById(id));
        }

        [HttpPost]
        [EnableCors("corsapp")]
        public ActionResult<BrandDto> Create([FromBody] BrandCreateDto brand)
        {
            var entity = mapper.Map<Brand>(brand);
            return mapper.Map<BrandDto>(AddEntity(entity));
        }
        [HttpPut]
        [EnableCors("corsapp")]
        public ActionResult Put(BrandUpdateDto brandUpdateDto)
        {
            var entity = mapper.Map<Brand>(brandUpdateDto);
            Edit(entity);
            return Ok();
        }
        [HttpDelete]
        [EnableCors("corsapp")]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            Delete(id);
            return Ok();
        }

    }
}
