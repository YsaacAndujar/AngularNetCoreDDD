using Application.Services;
using Domain;
using FrontApi.DTOs;
using FrontApi.Helpers.CustomControllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontApi.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : CrudBaseController<Brand, int>
    {
        public BrandController(BrandService brandService): base(brandService)
        {

        }
        [HttpGet]
        public ActionResult<Brand> Index()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult Create([FromBody] BrandCreateDto brand)
        {
            return Ok();
        }

    }
}
