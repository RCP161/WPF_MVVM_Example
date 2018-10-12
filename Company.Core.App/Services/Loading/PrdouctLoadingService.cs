using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Catel.IoC;
using Company.Core.App.Models;
using Company.DataQueries.If;

namespace Company.Core.App.Services.Loading
{
    internal class ProductLoadingService
    {
        private IMapper mapper;

        internal ProductLoadingService()
        {
            mapper = ServiceLocator.Default.ResolveType<IMapper>();
        }

        internal Product GetById(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return mapper.Map<Data.Enities.Product, Product>(unitOfWork.ProductRepository.GetById(id));
            }
        }

        internal IEnumerable<Product> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return mapper.Map<IEnumerable<Data.Enities.Product>, List<Product>>(unitOfWork.ProductRepository.GetAll());
            }
        }

        internal IEnumerable<Product> GetByCustomerId(int customerId)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return mapper.Map<IEnumerable<Data.Enities.Product>, List<Product>>(unitOfWork.ProductRepository.GetByCustomerId(customerId));
            }
        }
    }
}
