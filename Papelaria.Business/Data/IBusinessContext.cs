using Papelaria.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Papelaria.Business.Data
{
    public interface IBusinessContext
    {

        public DbSet<Item> Items { get; }
        public DbSet<Category> Categories { get; }
        public DbSet<Brand> Brands { get; }
        public DbSet<Supplier> Suppliers { get; }
        public DbSet<StockMovement> StockMovements { get; }
        public DbSet<TypeMovement> TypeMovement { get; }
        public DbSet<Image> Images { get; }



        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

    }
}