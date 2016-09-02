using System.Data.Entity;

using VkazoMaterial.Models;

namespace VkazoMaterial.Models
{
    public class VkazoMaterialDbContext : DbContext
    {
        public DbSet<Rank> Grades { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserHasMaterial> UserHasMaterials { get; set; }

        public VkazoMaterialDbContext() : base("MS_TableConnectionString") {}
    }
}