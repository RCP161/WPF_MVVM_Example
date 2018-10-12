using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Company.Core.App.Services.Loading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.App.Models
{
    public class Home : ModelBase
    {
        private static readonly CustomerLoadingService customerLoadingService = new CustomerLoadingService();
        private readonly Main main;

        public Home(Main main)
        {
            this.main = main;
        }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                ObservableCollection<Customer> customers = GetValue<ObservableCollection<Customer>>(CustomersProperty);
                if(customers == null)
                {
                    SetValue(CustomersProperty, new ObservableCollection<Customer>(customerLoadingService.GetAllCustomers()));
                    customers = GetValue<ObservableCollection<Customer>>(CustomersProperty);
                }
                return customers;
            }
            set { SetValue(CustomersProperty, value); }
        }
        public static readonly PropertyData CustomersProperty = RegisterProperty(nameof(Customers), typeof(ObservableCollection<Customer>));


        public void OpenCustomer(Customer customer)
        {
            main.ActivContent = customer;
        }

        public void AddCustomer()
        {
            throw new NotImplementedException();
        }
    }
}
