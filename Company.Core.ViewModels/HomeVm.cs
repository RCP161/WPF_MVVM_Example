using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.MVVM;
using Company.Core.App.Models;

namespace Company.Core.ViewModels
{
    public class HomeVm : ViewModelBase
    {
        public HomeVm(Home home)
        {
             Model = home;
            OpenCustomerCommand = new Command(OpenCustomer, CanOpenCustomer);
            AddCustomerCommand = new Command(AddCustomer, CanAddCustomer);
            OpenProductCommand = new Command(OpenProduct, CanOpenProduct);
            AddProductCommand = new Command(AddProduct, CanAddProduct);
        }

        #region Properties

        [Model]
        public Home Model
        {
            get { return GetValue<Home>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Home));

        
        [ViewModelToModel(nameof(Model))]
        public ObservableCollection<Customer> Customers
        {
            get { return GetValue<ObservableCollection<Customer>>(CustomersProperty); }
            set { SetValue(CustomersProperty, value); }
        }
        public static readonly PropertyData CustomersProperty = RegisterProperty(nameof(Customers), typeof(ObservableCollection<Customer>));


        public Customer SelectedCustomer
        {
            get { return GetValue<Customer>(SelectedCustomerProperty); }
            set { SetValue(SelectedCustomerProperty, value); }
        }
        public static readonly PropertyData SelectedCustomerProperty = RegisterProperty(nameof(SelectedCustomer), typeof(Customer));


        [ViewModelToModel(nameof(Model))]
        public ObservableCollection<Product> Products
        {
            get { return GetValue<ObservableCollection<Product>>(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }
        public static readonly PropertyData ProductsProperty = RegisterProperty(nameof(Products), typeof(ObservableCollection<Product>));


        public Product SelectedProduct
        {
            get { return GetValue<Product>(SelectedProductProperty); }
            set { SetValue(SelectedProductProperty, value); }
        }
        public static readonly PropertyData SelectedProductProperty = RegisterProperty(nameof(SelectedProduct), typeof(Product));


        public Command OpenCustomerCommand { get; private set; }
        public Command AddCustomerCommand { get; private set; }
        public Command OpenProductCommand { get; private set; }
        public Command AddProductCommand { get; private set; }

        #endregion

        #region Methods

        private bool CanOpenCustomer()
        {
            return SelectedCustomer != null;
        }

        private void OpenCustomer()
        {
            Model.OpenCustomer(SelectedCustomer.Id);
        }
        private bool CanAddCustomer()
        {
            return true;
        }

        private void AddCustomer()
        {
            Model.AddCustomer();
        }

        private bool CanOpenProduct()
        {
            return SelectedProduct != null;
        }

        private void OpenProduct()
        {
            Model.OpenProduct(SelectedProduct.Id);
        }
        private bool CanAddProduct()
        {
            return true;
        }

        private void AddProduct()
        {
            Model.AddProduct();
        }

        #endregion
    }
}
