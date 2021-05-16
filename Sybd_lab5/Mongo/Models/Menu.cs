using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sybd_lab5.Mongo.Models
{
    public class Menu
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public decimal Volume { get; set; }
        public decimal Gram { get; set; }
        public List<string> Orders { get; set; }
    }
}
