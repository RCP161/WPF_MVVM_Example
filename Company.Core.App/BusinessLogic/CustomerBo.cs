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
    internal class CustomerBo
    {
        private IMapper mapper;

        internal CustomerBo()
        {
            mapper = ServiceLocator.Default.ResolveType<IMapper>();
        }

        public Customer GetById(int customerId)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return mapper.Map<Data.Enities.Customer, Customer>(unitOfWork.CustomerRepository.GetById(customerId));
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return mapper.Map<IEnumerable<Data.Enities.Customer>, List<Customer>>(unitOfWork.CustomerRepository.GetAll());
            }
        }

        // TODO : Automapper möchte alle gleichnamigen Properties mappen, auch die Collection, obwohl er das nicht soll


        //public Customer GetById(int customerId)
        //{
        //    Data.Enities.Customer customer = null;

        //    using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
        //    {
        //        customer = unitOfWork.CustomerRepository.GetById(customerId);
        //    }

        //    return mapper.Map<Data.Enities.Customer, Customer>(customer);
        //}

        //public IEnumerable<Customer> GetAllCustomers()
        //{
        //    IEnumerable<Data.Enities.Customer> customers = new List<Data.Enities.Customer>();

        //    using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
        //    {
        //        customers = unitOfWork.CustomerRepository.GetAll();
        //    }

        //    return mapper.Map<IEnumerable<Data.Enities.Customer>, List<Customer>>(customers);
        //}
    }
}
