using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHungry.EF.Model
{
    public class CollectRequest
    {
        public int CollectRequestId { get; set; }
        public string FoodItem { get; set; }
        public string Status { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }


    }
}
