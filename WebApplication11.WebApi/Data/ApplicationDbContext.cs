using Microsoft.EntityFrameworkCore;
using WebApplication11.WebApi.Models.Entities;

namespace WebApplication11.WebApi.Data
{

    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        //{

        //}
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
