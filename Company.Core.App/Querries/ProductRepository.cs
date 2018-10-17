using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.App.Models;

namespace Company.Core.App.Querries
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IDataAccess dataAccess) : base(dataAccess)
        { }

        public List<Product> GetByCustomerId(int id)
        {
            return DataAccess.Query<Product>().Where(p => p.Owner != null && p.Owner.Id == id).ToList();
        }
    }
}
