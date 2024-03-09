using Microsoft.EntityFrameworkCore;
using StudentCrudWebApi.Models;

namespace StudentCrudWebApi.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
             
        }

        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }
    }
}
