using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Catel.IoC;
using Company.Core.App.Models;
using Company.DataQueries.If;

namespace Company.Core.App.BusinessLogic
{
    internal class ProductBo
    {
        private IMapper mapper;

        internal ProductBo()
        {
            mapper = ServiceLocator.Default.ResolveType<IMapper>();
        }

        public IEnumerable<Product> GetByCustomerId(int customerId)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return mapper.Map<IEnumerable<Data.Enities.Product>, List<Product>>(unitOfWork.ProductRepository.GetByCustomerId(customerId));
            }
        }
        
        //public IEnumerable<Product> GetByCustomerId(int customerId)
        //{
        //    IEnumerable<Data.Enities.Product> products = new List<Data.Enities.Product>();

        //    using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
        //    {
        //        products = unitOfWork.ProductRepository.GetByCustomerId(customerId);
        //    }

        //    return mapper.Map<IEnumerable<Data.Enities.Product>, List<Product>>(products);
        //}
    }
}
