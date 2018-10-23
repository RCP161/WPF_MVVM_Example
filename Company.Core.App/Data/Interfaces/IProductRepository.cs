using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.App.Models;

namespace Company.Core.App.Data.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        IEnumerable<Product> GetByCustomerId(int id);
    }
}
