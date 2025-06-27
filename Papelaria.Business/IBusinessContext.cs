using Papelaria.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Papelaria.Business
{
    public interface IBusinessContext
    {

        DbSet<Item> Items { get; }
        DbSet<Category> Categories { get; }
        DbSet<Brand> Brands { get; }
        DbSet<Supplier> Suppliers { get; }
        DbSet<StockMovement> StockMovements { get; }
        DbSet<TypeMovement> TypeMovement { get; }
        DbSet<Image> Images { get; }





    }
}





////da aula do Fernando

//namespace ProjectStructure.Business
//{
//    public interface IBusinessContext
//    {

//        public DbSet<Patient> Patients { get; set; }


//        //Task<int> SaveChangesAsync();

//        Task<int> SaveChangesAsync(bool acceptAllChangesOnSucess, CancellationToken cancellationToken = default);
//    }
//}




