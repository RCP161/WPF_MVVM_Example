using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.IoC;
using Company.Core.App.Models;
using Company.Core.App.Data;
using Company.Core.App.Data.Interfaces;
using Company.Core.App.Services.Data.Interfaces;

namespace Company.Core.App.Services.Data
{
    public class CustomerDataService : ICustomerDataService
    {

        public Customer GetById(int customerId)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                Customer c = unitOfWork.CustomerRepository.GetById(customerId);
                c.AfterLoad();
                return c;
            }
        }

        public Customer GetCompleteById(int customerId)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                Customer customer = unitOfWork.CustomerRepository.GetCompleteById(customerId);
                customer.AfterLoad();
                return customer;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.CustomerRepository.GetAll();
            }
        }

        public Customer SaveOrUpdate(Customer model)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                model = unitOfWork.CustomerRepository.SaveOrUpdate(model);
                unitOfWork.Complete(); // AfterLoad?
            }

            return model;
        }
    }
}
