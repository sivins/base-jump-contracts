using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BaseJumpContracts.Models;

namespace BaseJumpContracts.DAL
{
    public class ContractInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ContractContext>
    {
        protected override void Seed(ContractContext context)
        {
            var customers = new List<Customer>
            {
                new Customer {Name="McDonalds"},
                new Customer {Name="Microsoft"},
                new Customer {Name="Cox"},
                new Customer {Name="DigiTech"},
                new Customer {Name="Initech"},
                new Customer {Name="Ibanez"},
                new Customer {Name="John\'s Pet Shop"},
                new Customer {Name="Walmart"},
                new Customer {Name="Earlywine Elementary"},
                new Customer {Name="Pallet Princess"},
                new Customer {Name="Disney"},
                new Customer {Name="Crate Amplifiers"}
            };

            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();

            var services = new List<Service>
            {
                new Service { ID=2000, Name="Basic Cable", Description="Channels 1-100" },
                new Service { ID=2001, Name="Extended Cable", Description="Channels 101-150" },
                new Service { ID=2002, Name="Movie Pack", Description="HBO, Showtime, and Cinemax" },
                new Service { ID=2003, Name="International Pack", Description="International News, Entertainment, and Sports" },
                new Service { ID=3000, Name="Internet 50", Description="50mbps Download Speed, 10mbps Upload Speed" },
                new Service { ID=3001, Name="Internet 100", Description="100mbps Download Speed, 20mbps Upload Speed" },
                new Service { ID=3003, Name="Giganet", Description="Gigabit (1000mbps) Upload and Download Speed" },
                new Service { ID=4000, Name="Flat Line", Description="Flat monthly rate telephone line" },
                new Service { ID=4010, Name="VoiceTech Basic", Description="Basic feature package" },
                new Service { ID=4020, Name="VoiceTech Advanced", Description="Advanced feature pack including hunt groups" },
                new Service { ID=4030, Name="VoiceTech Pro", Description="Expanded features like Call Transfer and Music on Hold" },
                new Service { ID=4040, Name="VoiceTech Ultimate", Description="Selective call rejection, scheduled call forwarding, and automated attendant" }
            };

            services.ForEach(s => context.Services.Add(s));
            context.SaveChanges();

            var subscriptions = new List<Subscription>
            {
                new Subscription { CustomerID=1, ServiceID=2000, Price=50.00m, Term=36 },
                new Subscription { CustomerID=1, ServiceID=3000, Price=50.00m, Term=36 },
                new Subscription { CustomerID=1, ServiceID=4000, Price=50.00m, Term=36 },
                new Subscription { CustomerID=1, ServiceID=4000, Price=50.00m, Term=36 },
                new Subscription { CustomerID=0, ServiceID=3001, Price=50.00m, Term=36 },
                new Subscription { CustomerID=2, ServiceID=3003, Price=50.00m, Term=36 },
                new Subscription { CustomerID=2, ServiceID=4000, Price=50.00m, Term=36 },
                new Subscription { CustomerID=2, ServiceID=4040, Price=50.00m, Term=36 },
                new Subscription { CustomerID=3, ServiceID=3000, Price=50.00m, Term=36 }
            };

            subscriptions.ForEach(s => context.Subscriptions.Add(s));
            context.SaveChanges();
        }
    }
}