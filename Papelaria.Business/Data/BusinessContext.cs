using Papelaria.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Papelaria.Business.Data
{
    public class BusinessContext : DbContext, IBusinessContext
    {
        public BusinessContext(DbContextOptions<BusinessContext> options) : base(options) { }


        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<TypeMovement> TypeMovement { get; set; }
        public DbSet<Image> Images { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=SQL6033.site4now.net;Initial Catalog=db_abaef1_papelaria;User Id=db_abaef1_papelaria_admin;Password=)23ix%5]a~[0}0*#f@OU");
        }


        //public BusinessContext CreateDbContext(string[] args)
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<BusinessContext>();
        //    optionsBuilder.UseSqlServer("Data Source=SQL6033.site4now.net;Initial Catalog=db_abaef1_papelaria;User Id=db_abaef1_papelaria_admin;Password=)23ix%5]a~[0}0*#f@OU");

        //    return new BusinessContext(optionsBuilder.Options);
        //}




        public async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess)
        {
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

    }
}


//da aula do Fernando


//namespace ProjectStructure.Business
//{
//    public class BusinessContext : DbContext, IBusinessContext
//    {
//        public DbSet<Patient> Patients { get; set; }

//        public async Task<int> SaveChangesAsync()
//        {
//            return await base.SaveChangesAsync();
//        }

//        public async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess)
//        {
//            return await base.SaveChangesAsync(acceptAllChangesOnSuccess);
//        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            base.OnConfiguring(optionsBuilder);

//            optionsBuilder.UseSqlServer("Data Source=SQL6032.site4now.net;Initial Catalog=db_abaa2a_dotnet003;User Id=db_abaa2a_dotnet003_admin;Password=3]V,YE2c.(6#7KR%!&H");
//        }
//    }
//}
