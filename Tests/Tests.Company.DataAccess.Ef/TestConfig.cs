using Company.DataAccess.If;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Company.DataAccess.Ef
{
    internal class TestConfig : IDbConfigruation
    {
        public string ConnectionString
        {
            get { return @"Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=Standard3TestDb;Integrated Security=True;"; }
        }
    }
}
