using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZeroHungry.EF.Model
{
    public class ZhDb :DbContext
    {
        public DbSet<CollectRequest> CollectRequests { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}