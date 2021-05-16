using Microsoft.AspNetCore.Mvc;
using SYBD.Db.MongoDb;
using System.Threading.Tasks;

namespace SYBD.Controllers
{
    public class MongoController : Controller
    {
        private readonly DbService db;
        public MongoController(DbService context)
        {
            db = context;
        }

        public async Task<IActionResult> StartTransfer()
        {
            await db.StartTransferData();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Buyers()
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            var data = await db.GetBuyers();
            startTime.Stop();
            return View((startTime.Elapsed.ToString(), data));
        }

        public async Task<IActionResult> Employees()
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            var data = await db.GetEmployees();
            startTime.Stop();
            return View((startTime.Elapsed.ToString(), data));
        }

        public async Task<IActionResult> Orders()
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            var data = await db.GetOrders();
            startTime.Stop();
            return View((startTime.Elapsed.ToString(), data));
        }

        public async Task<IActionResult> Menus()
        {
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            var data = await db.GetMenus();
            startTime.Stop();
            return View((startTime.Elapsed.ToString(), data));
        }
    }
}