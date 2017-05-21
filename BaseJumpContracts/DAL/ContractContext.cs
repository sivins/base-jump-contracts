using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseJumpContracts.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BaseJumpContracts.DAL
{
    public class ContractContext : DbContext
    {
        public ContractContext() : base("ContractContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}