using Microsoft.AspNetCore.Mvc;
using Sybd_lab5.Storages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersStorage _storage;
        private readonly IBuyerStorage _buyerStorage;
        private readonly IEmployeeStorage _employeeStorage;
        public OrdersController(IOrdersStorage storage, IBuyerStorage buyerStorage, IEmployeeStorage employeeStorage)
        {
            _storage = storage;
            _buyerStorage = buyerStorage;
            _employeeStorage = employeeStorage;
        }

        public IActionResult List()
        {
            var model = _storage.GetFullList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Buyers = _buyerStorage.GetFullList();
            ViewBag.Employees = _employeeStorage.GetFullList();
            return View();
        }

        [HttpPost]
        public void Create(Orders model)
        {
            _storage.Insert(model);
            Response.Redirect("List");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _storage.GetElement(id);
            ViewBag.Buyers = _buyerStorage.GetFullList();
            ViewBag.Employees = _employeeStorage.GetFullList();
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Update(Orders model)
        {
            _storage.Update(model);
            return RedirectToAction("List", "Orders");
        }

        public RedirectToActionResult Delete(int id)
        {
            _storage.Delete(id);
            return RedirectToAction("List", "Orders");
        }
    }
}
