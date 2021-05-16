using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Mongo.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string BuyerId { get; set; }
        public string EmployeeId { get; set; }
    }
}
