using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontApi.Controllers
{
    public class CarModelController : Controller
    {
        // GET: CarModelController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CarModelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CarModelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarModelController/Edit/5
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

        // GET: CarModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarModelController/Delete/5
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
