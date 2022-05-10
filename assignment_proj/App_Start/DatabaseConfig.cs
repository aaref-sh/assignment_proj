using assignment_proj.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace assignment_proj
{
    public static class DatabaseConfig
    {
        public static void RegisterDbInitilizer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DB, MyConfig>());

            using (var context = new DB())
            {
                context.Database.CreateIfNotExists();
            }
        }
    }
    internal class MyConfig : DbMigrationsConfiguration<DB>
    {

        public MyConfig()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DB context)
        {
            context.SaveChanges();
            //SettingsManager.Initilize();
        }
    }
}