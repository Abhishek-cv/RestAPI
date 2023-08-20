using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Data
{
    public class APIdbcontext : DbContext
    {
        public APIdbcontext(DbContextOptions<APIdbcontext> options):base (options)
        {
            
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<Emplolyee> Emplolyee { get; set; }


    }
}
