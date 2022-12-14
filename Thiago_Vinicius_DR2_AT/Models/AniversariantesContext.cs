using Microsoft.EntityFrameworkCore;

namespace Thiago_Vinicius_DR2_AT.Models 
{
    public class AniversariantesContext : DbContext
    {
        public DbSet<Aniversariante> pessoas { get; set; }

        public AniversariantesContext(DbContextOptions<AniversariantesContext> options) : base(options)
        {

        }

    }
}
