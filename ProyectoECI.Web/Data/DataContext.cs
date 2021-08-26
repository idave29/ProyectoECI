namespace ProyectoECI.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ProyectoECI.Web.Data.Entities;
    using System.Linq;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Status> Statuses { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //Habilitar mi comportamiento de eliminado en cascada. 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var cascadeFKs = builder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);
        }
    }
}
