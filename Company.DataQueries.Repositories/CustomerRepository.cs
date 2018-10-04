using Company.Data.Enities;
using Company.DataAccess.If;
using Company.DataQueries.If;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataQueries.Repositories
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
