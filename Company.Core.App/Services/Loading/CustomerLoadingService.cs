using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.IoC;
using Company.Core.App.Models;
using Company.Core.App.Querries;

namespace Company.Core.App.Services.Loading
{
    internal class CustomerLoadingService
    {

        internal CustomerLoadingService()
        {
        }

        internal Customer GetById(int customerId)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.CustomerRepository.GetById(customerId);
            }
        }

        internal IEnumerable<Customer> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.CustomerRepository.GetAll();
            }
        }
    }
}
