using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.App.Models;

namespace Company.Core.App.Querries
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Customer GetByProductId(int id);
    }
}
