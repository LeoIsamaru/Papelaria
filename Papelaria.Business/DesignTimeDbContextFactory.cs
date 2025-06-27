using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Papelaria.Business
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BusinessContext>
    {
        public BusinessContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BusinessContext>();
            optionsBuilder.UseSqlServer("Data Source=SQL6033.site4now.net;Initial Catalog=db_abaef1_papelaria;User Id=db_abaef1_papelaria_admin;Password=)23ix%5]a~[0}0*#f@OU");

            return new BusinessContext(optionsBuilder.Options);
        }
    }
}
