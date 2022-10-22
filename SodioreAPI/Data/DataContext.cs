using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    
    public class DataContext : DbContext // extends EntityFrameworkCore.DbContext
    {
        // permite querys de sql e usabilidades do EF
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            
        }*/     

        // especifica quais modelos vão utilizar funções do EF
        
        public DbSet<Pizza>? Pizzas {get; set;}
    }
}