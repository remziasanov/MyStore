using StoreExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoreExample.DataBaseManager
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext() : base("ConnectionDefault") { }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PhoneItem> Phones { get; set; }
    }
}