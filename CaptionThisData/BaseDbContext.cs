using CaptionThis.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CaptionThis.Data
{
    public abstract class BaseDbContext : DbContext
    {
        public DbSet<Example> Examples { get; set; }

        protected abstract override void OnConfiguring(DbContextOptionsBuilder optionsBuilder);

        public override int SaveChanges()
        {
            BaseModel.UpdateBaseFields(ChangeTracker);
            return base.SaveChanges();
        }
    }
}
