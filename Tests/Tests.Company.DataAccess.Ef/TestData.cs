using Company.Data.Enities;
using Company.DataAccess.Ef;
using Company.DataAccess.If;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Company.DataAccess.Ef
{
    internal class TestData : IDisposable
    {
        private static IDbConfigruation _conf = new TestConfig();

        internal IDbConfigruation Config
        {
            get { return _conf; }
        }

        internal TestData()
        {
            using (EfContext con = new EfContext(_conf))
            {
                if (con.Database.Exists())
                    con.Database.Delete();

                con.Database.Create();

                Product p1 = new Product() { Name = "Testanlage" };
                Product p2 = new Product() { Name = "A2017-0000" };
                Product p3 = new Product() { Name = "A2017-0001" };
                Product p4 = new Product() { Name = "A2017-0002" };
                Product p5 = new Product() { Name = "A2090-0000" };

                con.Add(p1);
                con.Add(p2);
                con.Add(p3);
                con.Add(p4);
                con.Add(p5);

                con.Complete();

                Customer c1 = new Customer() { Name = "GmbH 1", Products = new List<Product>() { p2, p3 } };

                Customer c2 = new Customer();
                c2.Name = "GmbH 2";
                
                Customer c3 = new Customer()
                {
                    Name = "GmbH 3",
                    Products = new List<Product>() { p4 }
                };
                Customer c4 = new Customer()
                {
                    Name = "GmbH 4"
                };
                Customer c5 = new Customer()
                {
                    Name = "Intern",
                    Products = new List<Product>() { p1 }
                };

                p2.Owner = c1;
                p3.Owner = c1;
                p4.Owner = c3;
                p1.Owner = c5;

                con.Add(c1);
                con.Add(c2);
                con.Add(c3);
                con.Add(c4);
                con.Add(c5);

                con.Complete();
            }
        }

        public void Dispose()
        {
            using (EfContext con = new EfContext(_conf))
            {
                if (con.Database.Exists())
                    con.Database.Delete();
            }
        }
    }
}
