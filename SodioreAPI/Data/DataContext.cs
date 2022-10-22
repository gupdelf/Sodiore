using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    
    public class DataContext : DbContext // extends EntityFrameworkCore.DbContext
    {
        // permite querys de sql e usabilidades do EF
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        // especifica quais modelos vão utilizar funções do EF
        
        public DbSet<Pizza> Pizzas {get; set;}
    }
}