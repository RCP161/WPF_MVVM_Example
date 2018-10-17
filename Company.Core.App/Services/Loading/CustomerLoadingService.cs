using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
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
        
        internal ModelBase GetCompleteById(int customerId)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                Customer customer = unitOfWork.CustomerRepository.GetById(customerId);
                IEnumerable<Product> products = customer.Products; // nötig, damit EF die Produkte abfrägt. Könnte man in einer eigenen RepoAbfrage optimieren
                return customer;
            }
        }

        internal IEnumerable<Customer> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.CustomerRepository.GetAll();
            }
        }

        internal void Save(Customer customer)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                // TODO : [Prio2] Noch vereinheitlichen 
                if(customer.Id < 1)
                {
                    unitOfWork.CustomerRepository.Add(customer);
                }
                else
                {
                    Customer c = unitOfWork.CustomerRepository.GetById(customer.Id);
                    c = customer;
                }

                unitOfWork.Complete();
            }
        }
    }
}
