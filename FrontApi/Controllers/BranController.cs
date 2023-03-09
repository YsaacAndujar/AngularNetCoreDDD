using FrontApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontApi.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BranController : Controller
    {
        // GET: BranController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BranController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BranController/Create
        public ActionResult Create()
        {
            return View();
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
            return View();
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
                return View();
            }
        }

        // GET: BranController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
                return View();
            }
        }
    }
}
