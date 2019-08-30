using System;
using System.Collections.Generic;
using System.Text;
using Company.Project.DataSourceDefinition.Common;

namespace Company.Project
{
    public class Config : IDbConfigruation
    {
        public string ConnectionString
        {
            get { return @"Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=CompanyDB;Integrated Security=True;"; }
        }
    }
}
