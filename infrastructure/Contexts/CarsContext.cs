using Domain;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    public class CarsContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Car> Car { get; set; }
        public CarsContext(DbContextOptions<CarsContext> dbContextOptions) : base(dbContextOptions) {
            try
            {
                var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if(dbCreator != null )
                {
                    if (!dbCreator.CanConnect()) dbCreator.Create();
                    if (!dbCreator.HasTables()) dbCreator.CreateTables();
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer(@"Data Source=(localdb)\SQLEXPRESS; Initial Catalog = Cars; Integrated Security = true;");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BrandConfig());
            builder.ApplyConfiguration(new CarModelConfig());
            builder.ApplyConfiguration(new CarConfig());
        }
    }
}
