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

        //private readonly string conn = "Server = localhost; Database=CarToGoAPITest;User ID = banksystem; Password=banksystem";
        private readonly string conn = "Server=.;Database=CarToGoAPI;Integrated Security=True;";
        private static DatabaseContext instance = null;

        public DatabaseContext() : base("CarToGoAPI")
        {
            this.Database.Connection.ConnectionString = conn;
            //Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
            //Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseAlways<DatabaseContext>());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, CarToGoAPI.Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GPSCordinat>().Property(g => g.Latitude).HasPrecision(18, 6);
            modelBuilder.Entity<GPSCordinat>().Property(g => g.Longitude).HasPrecision(18, 6);

            base.OnModelCreating(modelBuilder);
            //one to one Customer -> DriversLices
            modelBuilder.Entity<Customer>().
                HasOptional<DriversLicens>(d => d.DriversLicens).
                WithRequired(s => s.Customer);
            //one to one Customer -> CreditCard
            modelBuilder.Entity<Customer>().
                HasOptional<CreditCard>(d => d.CreditCards).
                WithRequired(s => s.Customer);


            //one to many CarBrand -> CarModel
            modelBuilder.Entity<CarModel>() //many
                .HasRequired<CarBrand>(sc => sc.CarBrand)//many
                .WithMany(s => s.CarModel)//one
                .HasForeignKey<int>(sc => sc.CarBandId);//many

            //one to many CarModel -> Car
            modelBuilder.Entity<Car>() //many
                .HasRequired<CarModel>(sc => sc.CarModel)//many
                .WithMany(s => s.Car)//one
                .HasForeignKey<int>(sc => sc.CarModelId);//many

            //one to one EletricEngine -> Car
            modelBuilder.Entity<Car>().
                HasOptional<EletricEngine>(d => d.EletricEngine).
                WithRequired(s => s.Car);

            //one to one GPSCordinat -> Car
            modelBuilder.Entity<Car>().
                HasOptional<GPSCordinat>(d => d.GPSCordinat).
                WithRequired(s => s.Car);

            //modelBuilder.Entity<Customer>()
            //    .HasOne<DriversLicens>(s => s.Address)
            //    .WithOne(ad => ad.Student)
            //    .HasForeignKey<StudentAddress>(ad => ad.AddressOfStudentId);

            //one to many CarModel -> Car
            modelBuilder.Entity<Car>() //many
                .HasRequired<CarModel>(sc => sc.CarModel)//many
                .WithMany(s => s.Car)//one
                .HasForeignKey<int>(sc => sc.CarModelId);//many

            //one to many Customer -> OrderCars
            modelBuilder.Entity<OrderdCars>() //many
                .HasRequired<Customer>(sc => sc.Customer)//many
                .WithMany(s => s.OrderdCars)//one
                .HasForeignKey<int>(sc => sc.CustomerID);//many

            //one to many Car -> OrderCars
            modelBuilder.Entity<OrderdCars>() //many
                .HasRequired<Car>(sc => sc.Car)//many
                .WithMany(s => s.OrderdCars)//one
                .HasForeignKey<int>(sc => sc.CarID);//many

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
        public DbSet<CarBrand> CarBrands { get; set; }
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
