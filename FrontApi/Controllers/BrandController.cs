using FrontApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontApi.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        // GET: BranController
        public ActionResult Index()
        {
            return Ok();
        }

        // GET: BranController/Details/5
        public ActionResult Details(int id)
        {
            return Ok();
        }

        // GET: BranController/Create
        public ActionResult Create()
        {
            return Ok();
        }

        // POST: BranController/Create
        [HttpPost]
        public ActionResult Create(BrandCreateDto brand)
        {
            return Ok();
        }

        // GET: BranController/Edit/5
        public ActionResult Edit(int id)
        {
            return Ok();
        }

        // POST: BranController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        // GET: BranController/Delete/5
        public ActionResult Delete(int id)
        {
            return Ok();
        }

        // POST: BranController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }
    }
}
