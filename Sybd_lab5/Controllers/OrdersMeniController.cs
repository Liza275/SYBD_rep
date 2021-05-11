using Microsoft.AspNetCore.Mvc;
using Sybd_lab5.Storages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Controllers
{
    public class OrdersMeniController : Controller
    {
        private readonly IOrdersMeniStorage _storage;
        private readonly IMenuStorage _menuStorage;
        private readonly IOrdersStorage _ordersStorage;
        public OrdersMeniController(IOrdersMeniStorage storage, IMenuStorage menuStorage, IOrdersStorage ordersStorage)
        {
            _storage = storage;
            _menuStorage = menuStorage;
            _ordersStorage = ordersStorage;
        }

        public IActionResult List()
        {
            var model = _storage.GetFullList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Menus = _menuStorage.GetFullList();
            ViewBag.Orders = _ordersStorage.GetFullList();
            return View();
        }

        [HttpPost]
        public void Create(OrdersMeni model)
        {
            _storage.Insert(model);
            Response.Redirect("List");
        }


        public RedirectToActionResult Delete(int menuid, int orderid)
        {
            _storage.Delete(menuid, orderid);
            return RedirectToAction("List", "OrdersMeni");
        }
    }
}
