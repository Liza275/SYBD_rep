using Microsoft.EntityFrameworkCore;
using Sybd_lab5.Storages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Storages
{
    public class TestStorage : ITestStorage
    {
        public (string defTime, string indexTime) FirstTest()
        {
            string def = "";
            string index = "";
            Random rnd = new Random();
            using (var context = new Sushi_barContext())
            {
                for (int i = 0; i < 500; i++)
                {
                    var model = new Menu();
                    model.Name = "Test name" + i;
                    model.Price = rnd.Next(600);
                    model.Gram = rnd.Next(600);
                    model.Volume = rnd.Next(600);
                    context.Add(model);
                }
                //context.SaveChanges();
                //default
                var startTime = System.Diagnostics.Stopwatch.StartNew();
                var testResult = context.Menu.FromSqlRaw("select name, price from menu");
                startTime.Stop();
                def = startTime.Elapsed.ToString();

                //index
                context.Menu.FromSqlRaw("CREATE UNIQUE INDEX index_test ON menu(name, price)");
                startTime = System.Diagnostics.Stopwatch.StartNew();
                var newResult = context.Menu.FromSqlRaw("select name, price from menu");
                startTime.Stop();
                index = startTime.Elapsed.ToString();
                //context.Menu.RemoveRange(context.Menu.Where(rec => rec.Name.Contains("Test")));
                context.Menu.FromSqlRaw("DROP INDEX index_test");
                //context.SaveChanges();
            }
            return (def, index);
        }

        public (string defTime, string indexTime) SecondTest()
        {
            string def = "";
            string index = "";
            Random rnd = new Random();
            using (var context = new Sushi_barContext())
            {
                for (int i = 0; i < 500; i++)
                {
                    var model = new Menu();
                    model.Name = "Test name" + i;
                    model.Price = rnd.Next(600);
                    model.Gram = rnd.Next(600);
                    model.Volume = rnd.Next(600);
                    context.Add(model);
                }

                for (int i = 0; i < 500; i++)
                {
                    var model = new Orders();
                    model.Buyerid = context.Buyer.Skip(rnd.Next(0, context.Buyer.Count())).FirstOrDefault().Id;
                    model.Employeeid = context.Employee.Skip(rnd.Next(0, context.Employee.Count())).FirstOrDefault().Id;
                    model.DataOrders = DateTime.Now;
                    context.Add(model);
                }

                for (int i = 0; i < 500; i++)
                {
                    var model = new Buyer();
                    model.NameBuyer = "Test name" + i;
                    model.NumberBuyer = "Test number" + i;
                    context.Add(model);
                }
                //context.SaveChanges();

                //default
                var startTime = System.Diagnostics.Stopwatch.StartNew();
                var testResult = context.Menu.FromSqlRaw("select m.name," +
                    " m.price, b.name_buyer from menu m full join orders_meni om on m.id = om.menu_id full join orders o on om.orders_id = o.id full join buyer b on o.buyerid = b.id;");
                startTime.Stop();
                def = startTime.Elapsed.ToString();

                //index
                context.Menu.FromSqlRaw("CREATE UNIQUE INDEX index_test1 ON menu(name, price); CREATE UNIQUE INDEX index_test2 ON orders(buyerid, employeeid, data_orders); CREATE UNIQUE INDEX index_test3 ON buyer(number_buyer, name_buyer);");
                startTime = System.Diagnostics.Stopwatch.StartNew();
                var newResult = context.Menu.FromSqlRaw("select m.name," +
                    " m.price, b.name_buyer from menu m full join orders_meni om on m.id = om.menu_id full join orders o on om.orders_id = o.id full join buyer b on o.buyerid = b.id;");
                startTime.Stop();
                index = startTime.Elapsed.ToString();
                context.Menu.FromSqlRaw("DROP INDEX index_test1");
                context.Menu.FromSqlRaw("DROP INDEX index_test2");
                context.Menu.FromSqlRaw("DROP INDEX index_test3");
                //context.SaveChanges();
            }
            return (def, index);
        }

        public (string defTime, string indexTime) ThirdTest()
        {
            string def = "";
            string index = "";
            Random rnd = new Random();
            using (var context = new Sushi_barContext())
            {
                for (int i = 0; i < 500; i++)
                {
                    var model = new Menu();
                    model.Name = "Test name" + i;
                    model.Price = rnd.Next(600);
                    model.Gram = rnd.Next(600);
                    model.Volume = rnd.Next(600);
                    context.Add(model);
                }

                for (int i = 0; i < 500; i++)
                {
                    var model = new Orders();
                    model.Buyerid = context.Buyer.Skip(rnd.Next(0, context.Buyer.Count())).FirstOrDefault().Id;
                    model.Employeeid = context.Employee.Skip(rnd.Next(0, context.Employee.Count())).FirstOrDefault().Id;
                    model.DataOrders = DateTime.Now;
                    context.Add(model);
                }
                //context.SaveChanges();

                //default
                var startTime = System.Diagnostics.Stopwatch.StartNew();
                var testResult = context.Menu.FromSqlRaw("select m.name, m.price, o.data_orders from menu m" +
                    " full join orders_meni om on m.id = om.menu_id full join orders o on om.orders_id = o.id full join");
                startTime.Stop();
                def = startTime.Elapsed.ToString();

                //index
                context.Menu.FromSqlRaw("CREATE UNIQUE INDEX index_test1 ON menu(name, price); CREATE UNIQUE INDEX index_test2 ON orders(buyerid, employeeid, data_orders);");
                startTime = System.Diagnostics.Stopwatch.StartNew();
                var newResult = context.Menu.FromSqlRaw("select m.name, m.price, o.data_orders from menu m" +
                    " full join orders_meni om on m.id = om.menu_id full join orders o on om.orders_id = o.id full join");
                startTime.Stop();
                index = startTime.Elapsed.ToString();
                context.Menu.FromSqlRaw("DROP INDEX index_test1");
                context.Menu.FromSqlRaw("DROP INDEX index_test2");
                //context.SaveChanges();
            }
            return (def, index);
        }
    }
}
