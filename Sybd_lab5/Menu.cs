using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Sybd_lab5
{
    public partial class Menu
    {
        public Menu()
        {
            OrdersMeni = new HashSet<OrdersMeni>();
        }

        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public decimal? Volume { get; set; }
        public decimal? Gram { get; set; }

        public virtual ICollection<OrdersMeni> OrdersMeni { get; set; }
    }
}
