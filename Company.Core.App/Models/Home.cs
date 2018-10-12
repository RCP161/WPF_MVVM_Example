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
        private static readonly ProductLoadingService productLoadingService = new ProductLoadingService();

        public Home()
        {
            Customers = new ObservableCollection<Customer>(customerLoadingService.GetAll());
            Products = new ObservableCollection<Product>(productLoadingService.GetAll());
        }

        public ObservableCollection<Customer> Customers
        {
            get { return GetValue<ObservableCollection<Customer>>(CustomersProperty); }
            set { SetValue(CustomersProperty, value); }
        }
        public static readonly PropertyData CustomersProperty = RegisterProperty(nameof(Customers), typeof(ObservableCollection<Customer>));

        public ObservableCollection<Product> Products
        {
            get { return GetValue<ObservableCollection<Product>>(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }
        public static readonly PropertyData ProductsProperty = RegisterProperty(nameof(Products), typeof(ObservableCollection<Product>));

        public void OpenCustomer(int id)
        {
            Main.Instance.ActivContent = customerLoadingService.GetById(id);
        }

        public void OpenProduct(int id)
        {
            Main.Instance.ActivContent = productLoadingService.GetById(id);
        }

        // TODO : Add implementieren

        public void AddCustomer()
        {
            throw new NotImplementedException();
        }

        public void AddProduct()
        {
            throw new NotImplementedException();
        }
    }
}
