using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetaModelCoreApp.Models;

namespace MetaModelCoreApp.Models
{
    public class MetaModelDbContext : DbContext
    {
        public MetaModelDbContext(DbContextOptions<MetaModelDbContext> options) : base(options)
        {

        }
        public DbSet<CropType> CropType { get; set; }

        //public DbSet<tblSkill> tblSkills { get; set; }
        //public DbSet<tblEmployee> tblEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CropType>().ToTable("crop_types");
        }
    }

}
