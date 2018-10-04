using Company.Data.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataQueries.If
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        List<Product> GetByCustomerId(int id);
    }
}
