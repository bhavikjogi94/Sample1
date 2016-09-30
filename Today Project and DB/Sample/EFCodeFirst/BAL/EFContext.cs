using System.Data.Entity;

namespace EFCodeFirst.BAL
{
    // Steps to create Code First Entity Framework
    // (1) Right Click -> Manage NuGet Packages
    // (2) Creare Classes 
    // (3) Craete Context Class -> Inherit with DbContext -> Write DbSet<> for all classes
    // (4) Add Connection String Name in Constructor of Context Class
    // (5) Open Package Manager Console -> Run this Command "enable-migrations –EnableAutomaticMigration:$true"
    // (6) Open Package Manager Console -> Run this Command "add-migration 'First SampleDB Schema'"
    // (7) To Create Database -> Open Package Manager Console -> Run this Command "update-database -verbose"
    //  To Rollback Migration -> update-database -TargetMigration:"Migration File Name"

    public class EFContext : DbContext
    {
        public EFContext()
            : base("name=cnStr")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFContext, EFCodeFirst.Migrations.Configuration>("cnStr"));
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
    }

}