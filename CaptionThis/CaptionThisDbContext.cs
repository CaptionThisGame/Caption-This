using CaptionThis.Data;
using Microsoft.EntityFrameworkCore;

namespace CaptionThis
{
    public class CaptionThisDbContext : BaseDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL($"server={"localhost"};port={"3306"};database={"captionthis"};uid={"captionthis"};pwd={"captionthis"};"); // Todo: fill dynamically
            }
        }
    }
}
