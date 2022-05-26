using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Models;
using System.Threading.Tasks;

namespace SimpleCQRS.Context
{
    public class AppContext : DbContext, IAppContext
    {
        public DbSet<Employee> employees { get; set; }

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {

        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
