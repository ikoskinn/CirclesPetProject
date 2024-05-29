using DotByDot.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace DotByDot.Data
{
    public class DotByDotContext : DbContext
    {
        public DbSet<CircleSet> CircleSets { get; set; } = null!;
        public DbSet<Circle> Circles { get; set; } = null!;

        public DotByDotContext(DbContextOptions<DotByDotContext> options)
    : base(options)
        {

        }
    }
}
