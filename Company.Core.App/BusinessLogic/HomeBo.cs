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
    internal class HomeBo
    {
        private IMapper mapper;

        internal HomeBo()
        {
            mapper = ServiceLocator.Default.ResolveType<IMapper>();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return mapper.Map<IEnumerable<Data.Enities.Customer>, List<Customer>>(unitOfWork.CustomerRepository.GetAll());
            }
        }
    }
}
