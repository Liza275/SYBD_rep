using Microsoft.AspNetCore.Mvc;
using Sybd_lab5.Storages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Controllers
{
    public class BuyerController : Controller
    {
        private readonly IBuyerStorage _storage;
        public BuyerController(IBuyerStorage storage)
        {
            _storage = storage;
        }

        public IActionResult List()
        {
            var model = _storage.GetFullList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public void Create(Buyer buyer)
        {
            _storage.Insert(buyer);
            Response.Redirect("List");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _storage.GetElement(id);
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Update(Buyer model)
        {
            _storage.Update(model);
            return RedirectToAction("List", "Buyer");
        }

        public RedirectToActionResult Delete(int id)
        {
            _storage.Delete(id);
            return RedirectToAction("List", "Buyer");
        }
    }
}
