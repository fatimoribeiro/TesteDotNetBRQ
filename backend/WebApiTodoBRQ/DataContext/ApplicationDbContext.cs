using WebApiTodoBRQ.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiTodoBRQ.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TarefaModel> Tarefas { get; set; }
    }
}
