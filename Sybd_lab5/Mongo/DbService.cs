using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Sybd_lab5.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYBD.Db.MongoDb
{
    public class DbService
    {
        IMongoCollection<Buyer> Buyers;
        IMongoCollection<Employee> Employees;
        IMongoCollection<Order> Orders;
        IMongoCollection<Menu> Menus;

        public DbService(IConfiguration conf)
        {
            var connectionString = conf["MongoDb"];
            var connection = new MongoUrlBuilder(connectionString);
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase(connection.DatabaseName);
            Buyers = database.GetCollection<Buyer>("Buyers");
            Employees = database.GetCollection<Employee>("Employees");
            Orders = database.GetCollection<Order>("Orders");
            Menus = database.GetCollection<Menu>("Menus");
        }

        public async Task<IEnumerable<Buyer>> GetBuyers()
        {
            var builder = new FilterDefinitionBuilder<Buyer>();
            return await Buyers.Find(builder.Empty).ToListAsync();
        }

        private void Create(IEnumerable<Buyer> photographers)
        {
            Buyers.InsertManyAsync(photographers);
        }

        private async Task RemoveBuyers()
        {
            var builder = new FilterDefinitionBuilder<Buyer>();
            await Buyers.DeleteManyAsync(builder.Empty);
        }

        private Buyer CreateMongoModel(Sybd_lab5.Buyer buyer)
        {
            return new Buyer
            {
                Id = buyer.Id.ToString(),
                Name = buyer.NameBuyer,
                Number = buyer.NumberBuyer
            };
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var builder = new FilterDefinitionBuilder<Employee>();
            return await Employees.Find(builder.Empty).ToListAsync();
        }

        private void Create(IEnumerable<Employee> employees)
        {
            Employees.InsertManyAsync(employees);
        }

        private async Task RemoveEmployees()
        {
            var builder = new FilterDefinitionBuilder<Employee>();
            await Employees.DeleteManyAsync(builder.Empty);
        }

        private Employee CreateMongoModel(Sybd_lab5.Employee employee)
        {
            return new Employee
            {
                Id = employee.Id.ToString(),
                Fio = employee.Fio,
                Post = employee.Post
            };
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var builder = new FilterDefinitionBuilder<Order>();
            return await Orders.Find(builder.Empty).ToListAsync();
        }

        private void Create(IEnumerable<Order> orders)
        {
            Orders.InsertManyAsync(orders);
        }

        private async Task RemoveOrders()
        {
            var builder = new FilterDefinitionBuilder<Order>();
            await Orders.DeleteManyAsync(builder.Empty);
        }

        private Order CreateMongoModel(Sybd_lab5.Orders order)
        {
            return new Order
            {
                Id = order.Id.ToString(),
                BuyerId = order.Buyerid?.ToString(),
                EmployeeId = order.Employeeid?.ToString()
            };
        }

        public async Task<IEnumerable<Menu>> GetMenus()
        {
            var builder = new FilterDefinitionBuilder<Menu>();
            return await Menus.Find(builder.Empty).ToListAsync();
        }

        private void Create(IEnumerable<Menu> menus)
        {
            Menus.InsertManyAsync(menus);
        }

        private async Task RemoveMenus()
        {
            var builder = new FilterDefinitionBuilder<Menu>();
            await Menus.DeleteManyAsync(builder.Empty);
        }

        private Menu CreateMongoModel(Sybd_lab5.Menu menu)
        {
            var result = new Menu
            {
                Id = menu.Id.ToString(),
                Price = menu.Price,
                Name = menu.Name,
                Volume = menu.Volume ?? 0,
                Gram = menu.Gram ?? 0,
            };
            result.Orders = new List<string>();
            result.Orders.AddRange(menu.OrdersMeni.Select(rec => rec.OrdersId.ToString()));
            return result;
        }

        public async Task StartTransferData()
        {
            await RemoveBuyers();
            await RemoveEmployees();
            await RemoveOrders();
            await RemoveMenus();
            using (var context = new Sybd_lab5.Sushi_barContext())
            {
                Create(context.Buyer.Select(CreateMongoModel));
                Create(context.Employee.Select(CreateMongoModel));
                Create(context.Orders.Select(CreateMongoModel));
                Create(context.Menu.Include(rec => rec.OrdersMeni).Select(CreateMongoModel));
            }
        }
    }
}
