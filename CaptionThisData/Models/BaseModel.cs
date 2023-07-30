using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CaptionThis.Data.Models
{
    public abstract class BaseModel
    {
        [JsonIgnore]
        [Column("id")]
        public int Id { get; set; }

        [JsonIgnore]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        [Column("last_modified_at")]
        public DateTime LastModifiedAt { get; set; }


        public static void UpdateBaseFields(ChangeTracker changeTracker)
        {
            var changes = changeTracker.Entries().Where(
                e => e.Entity is BaseModel
                && (e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach (var change in changes)
            {
                if (change.State == EntityState.Added)
                {
                    ((BaseModel)change.Entity).CreatedAt = DateTime.UtcNow;
                }
                ((BaseModel)change.Entity).LastModifiedAt = DateTime.UtcNow;
            }
        }
    }
}
