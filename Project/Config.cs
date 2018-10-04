using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DataAccess.If;

namespace Project
{
    public class Config : IDbConfigruation
    {
        public string ConnectionString
        {
            get { return @"Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=Standard3DevDb;Integrated Security=True;"; }
        }
    }
}
