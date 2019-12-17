using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CarToGoAPI.Model
{
    class DatabaseContext : DbContext
    {
        //private readonly string conn = "Server = 192.168.1.10; Database=CarToGoAPI;User ID = sa; Password=Pa$$w0rd";
        private static DatabaseContext instance = null;

        public DatabaseContext() : base("CarToGoAPI")
        {
            //this.Database.Connection.ConnectionString = conn;
            Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

        // test of arduinos
        public DbSet<Arduino> Arduinos { get; set; }
        public DbSet<ArduinoMessage> ArduinoMessages { get; set; }

        // data object lists
        public DbSet<Car> Cars { get; set; }
        public DbSet<DriversLicens> DirversLicenes { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<GPSCordinat> GPSCordinats { get; set; }
        public DbSet<OrderdCars> OrderdCars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarBand> CarBands { get; set; }
        public DbSet<EletricEngine> EletricEngines { get; set; }
        public DbSet<Customer> Customers { get; set; }
        // singleton
        public static DatabaseContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseContext();
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
    }
}
