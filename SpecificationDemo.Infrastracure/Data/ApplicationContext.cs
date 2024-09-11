
using Microsoft.EntityFrameworkCore;
using SpecificationDemo.Core.Entities;
using SpecificationDemo.Core.Enums;

namespace SpecificationDemo.Infrastracure.Data
{
	public class ApplicationContext : DbContext
	{
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
    }
}
