using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.IoC;
using Company.Core.App.Models;
using Company.Core.App.Querries;

namespace Company.Core.App.Services.Data
{
    internal class PrdouctDataService
    {

        internal PrdouctDataService()
        {
        }

        internal Product GetById(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.ProductRepository.GetById(id);
            }
        }

        internal IEnumerable<Product> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.ProductRepository.GetAll();
            }
        }

        internal IEnumerable<Product> GetByCustomerId(int customerId)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.ProductRepository.GetByCustomerId(customerId);
            }
        }

        internal void Save(Product product)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                if(product.Id < 1)
                {
                    unitOfWork.ProductRepository.Add(product);
                }
                else
                {
                    Product p = unitOfWork.ProductRepository.GetById(product.Id);
                    p = product;
                }

                unitOfWork.Complete();
            }
        }
    }
}
