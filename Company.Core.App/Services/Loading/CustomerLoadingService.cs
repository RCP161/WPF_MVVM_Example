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
    internal class CustomerLoadingService
    {
        private IMapper mapper;

        internal CustomerLoadingService()
        {
            mapper = ServiceLocator.Default.ResolveType<IMapper>();
        }

        internal Customer GetById(int customerId)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return mapper.Map<Data.Enities.Customer, Customer>(unitOfWork.CustomerRepository.GetById(customerId));
            }
        }

        internal IEnumerable<Customer> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return mapper.Map<IEnumerable<Data.Enities.Customer>, List<Customer>>(unitOfWork.CustomerRepository.GetAll());
            }
        }
    }
}
