using Microsoft.EntityFrameworkCore;
using server.code.Entity;

namespace server.code.ApplicationContext
{
    public class IdentityContext: DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options): base(options){
            
        }

        public DbSet<DataTables> DataTables { get; set; }

    }
}