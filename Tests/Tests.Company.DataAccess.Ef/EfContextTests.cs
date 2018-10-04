using System;
using System.Collections.Generic;
using Company.Data.Enities;
using Company.DataAccess.Ef;
using Company.DataAccess.If;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Company.DataAccess.Ef
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContextTests_CreateInstance()
        {
            EfContext context = new EfContext(new TestConfig());
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void EfContextTests_Can_Drop_Instance()
        {
            using (EfContext con = new EfContext(new TestConfig()))
            {
                if (con.Database.Exists())
                {
                    con.Database.Delete();
                    Assert.IsFalse(con.Database.Exists());
                }

                con.Database.Create();
                Assert.IsTrue(con.Database.Exists());


                con.Database.Delete();
                Assert.IsFalse(con.Database.Exists());
            }
        }

        [TestMethod]
        public void EfContextTests_CRUD_Customer()
        {
            using (TestData td = new TestData())
            {
                Customer c1 = new Customer()
                {
                    Name = "GmbH Test"
                };

                string newName = "Tested";

                using (EfContext con = new EfContext(new TestConfig()))
                {
                    con.Set<Customer>().Add(c1);
                    con.SaveChanges();
                }


                using (EfContext con = new EfContext(new TestConfig()))
                {
                    Customer loaded = con.Set<Customer>().Find(c1.Id);

                    Assert.IsNotNull(loaded);
                    Assert.AreEqual(c1.Name, loaded.Name);

                    loaded.Name = newName;
                    con.SaveChanges();
                }


                using (EfContext con = new EfContext(new TestConfig()))
                {
                    Customer loaded = con.Set<Customer>().Find(c1.Id);
                    Assert.AreEqual(loaded.Name, newName);

                    con.Set<Customer>().Remove(loaded);
                    con.SaveChanges();
                }


                using (EfContext con = new EfContext(new TestConfig()))
                {
                    Customer loaded = con.Set<Customer>().Find(c1.Id);
                    Assert.IsNull(loaded);
                }
            }


            using(EfContext con = new EfContext(new TestConfig()))
            {
                if(con.Database.Exists())
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

                Customer c1 = new Customer();
                c1.Name = "GmbH 1";
                c1.Products = new List<Product>() { p2, p3 };

                Customer c2 = new Customer();
                c2.Name = "GmbH 2";

                Customer c3 = new Customer();
                c3.Name = "GmbH 3";
                c3.Products = new List<Product>() { p4 };

                Customer c4 = new Customer();
                c4.Name = "GmbH 4";

                Customer c5 = new Customer();
                c5.Name = "Intern";
                c5.Products = new List<Product>() { p1 };
                

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
    }
}
