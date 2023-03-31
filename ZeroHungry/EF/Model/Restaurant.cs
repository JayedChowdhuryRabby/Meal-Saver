using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHungry.EF.Model
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }
        public virtual ICollection<CollectRequest> CollectRequests { get; set; }
    }
}