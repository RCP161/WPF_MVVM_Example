using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.App.Models;
using Company.Core.App.Data.Interfaces;
using Company.Core.App.Data.DataBase.Interfaces;
using System.Data.Entity;

namespace Company.Core.App.Data.DataBase.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDataAccess dataAccess) : base(dataAccess)
        { }

        public override Customer GetCompleteById(int id)
        {
            return DataAccess.Query<Customer>().Include("Products").Where(c => c.Products.Any(t => t.Id == id)).FirstOrDefault();
        }

        public Customer GetByProductId(int id)
        {
            return DataAccess.Query<Customer>().Where(c => c.Products.Any(t => t.Id == id)).FirstOrDefault();
        }
    }
}
