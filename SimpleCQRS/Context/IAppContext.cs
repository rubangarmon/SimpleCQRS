using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Models;
using System.Threading.Tasks;

namespace SimpleCQRS.Context
{
    public interface IAppContext
    {
        DbSet<Employee> employees { get; set; }
        Task<int> SaveChangesAsync();
    }
}
