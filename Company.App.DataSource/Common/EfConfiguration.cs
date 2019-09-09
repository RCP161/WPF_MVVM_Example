using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Text;

namespace Company.App.DataSource.Common
{
    public class EfConfiguration : DbMigrationsConfiguration<EfContext>
    {
        public EfConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            // CommandTimeout = 30;
        }
    }
}
