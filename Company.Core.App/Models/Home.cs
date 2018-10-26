using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Company.Core.App.Common;
using Company.Core.App.Services.Data;
using Company.Core.App.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.App.Models
{
    public class Home : ModelBase1
    {
        private readonly ICustomerDataService customerDataService;
        private readonly IProductDataService productDataService;

        public Home()
        {
            customerDataService = ServiceLocator.Default.ResolveType<ICustomerDataService>();
            productDataService = ServiceLocator.Default.ResolveType<IProductDataService>();

            Customers = new ObservableCollection<Customer>(customerDataService.GetAll());
            Products = new ObservableCollection<Product>(productDataService.GetAll());
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
            Main.Instance.ActivContent = customerDataService.GetCompleteById(id);
        }

        public void OpenProduct(int id)
        {
            Main.Instance.ActivContent = productDataService.GetCompleteById(id);
        }

        public void AddCustomer()
        {
            Main.Instance.ActivContent = new Customer(true);
        }

        public void AddProduct()
        {
            Main.Instance.ActivContent = new Product(true);
        }

        public void DeleteCustomer(Customer customer)
        {
            IMessageBoxService messageBoxService = ServiceLocator.Default.ResolveType<IMessageBoxService>();
            if(InputResult.Yes != messageBoxService.Ask("Wirklich löschen?", "Benutzerbestätigung", InputOption.YesNo))
                return;

            Customers.Remove(customer);
            customer.MarkAsDeleted();
            customerDataService.SaveOrUpdate(customer);
        }

        public void DeleteProduct(Product product)
        {
            IMessageBoxService messageBoxService = ServiceLocator.Default.ResolveType<IMessageBoxService>();
            if(InputResult.Yes != messageBoxService.Ask("Wirklich löschen?", "Benutzerbestätigung", InputOption.YesNo))
                return;

            Products.Remove(product);
            product.MarkAsDeleted();
            productDataService.SaveOrUpdate(product);
        }
    }
}
