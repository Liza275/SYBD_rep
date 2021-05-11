using Microsoft.AspNetCore.Mvc;
using Sybd_lab5.Storages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestStorage _testStorage;

        public TestController(ITestStorage testStorage)
        {
            _testStorage = testStorage;
        }

        public IActionResult First()
        {
            var model = _testStorage.FirstTest();
            return View(model);
        }

        public IActionResult Second()
        {
            var model = _testStorage.SecondTest();
            return View(model);
        }

        public IActionResult Third()
        {
            var model = _testStorage.ThirdTest();
            return View(model);
        }
    }
}
