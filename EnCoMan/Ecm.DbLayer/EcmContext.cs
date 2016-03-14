using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecm.Data;

namespace Ecm.DbLayer
{
    public class EcmContext : DbContext
    {
        public EcmContext() : base("EcmDbEntities")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<EcmContext, Migrations.Configuration>("EcmDbEntities"));
        }
        
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<EnergyType> EnergyTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(e => e.Name).HasMaxLength(32).IsRequired();

            modelBuilder.Entity<EnergyType>().Property(e => e.Unit).HasMaxLength(16).IsRequired();
            modelBuilder.Entity<EnergyType>().Property(e => e.Description).HasMaxLength(256).IsRequired();

            modelBuilder.Entity<Record>().Property(e => e.Note).HasMaxLength(512);
            modelBuilder.Entity<Record>().Property(e => e.Created).HasColumnType("datetime").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            modelBuilder.Entity<Configuration>().Property(e => e.Order).HasColumnType("smallint");
            modelBuilder.Entity<Configuration>().Property(e => e.Name).HasMaxLength(64).IsRequired();
            
            base.OnModelCreating(modelBuilder);
        }


    }
}
