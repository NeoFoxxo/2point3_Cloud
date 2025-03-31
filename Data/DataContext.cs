using _2point3_Cloud.Models;
using Microsoft.EntityFrameworkCore;

namespace _2point3_Cloud.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<Book> Books { get; set; }
}