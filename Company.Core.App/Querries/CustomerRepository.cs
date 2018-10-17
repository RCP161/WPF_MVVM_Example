using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.App.Models;

namespace Company.Core.App.Querries
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDataAccess dataAccess) : base(dataAccess)
        { }

        public Customer GetByProductId(int id)
        {
            return DataAccess.Query<Customer>().Where(c => c.Products.Any(t => t.Id == id)).FirstOrDefault();
        }
    }
}
