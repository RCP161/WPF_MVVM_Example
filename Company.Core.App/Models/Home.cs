﻿using Catel.Data;
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


        public ObservableCollection<Customer> Customers
        {
            get
            {
                ObservableCollection<Customer> customers = GetValue<ObservableCollection<Customer>>(CustomersProperty);
                if(customers == null)
                {
                    SetValue(CustomersProperty, new ObservableCollection<Customer>(customerLoadingService.GetAll()));
                    customers = GetValue<ObservableCollection<Customer>>(CustomersProperty);
                }
                return customers;
            }
            set { SetValue(CustomersProperty, value); }
        }
        public static readonly PropertyData CustomersProperty = RegisterProperty(nameof(Customers), typeof(ObservableCollection<Customer>));

        public ObservableCollection<Product> Products
        {
            get
            {
                ObservableCollection<Product> products = GetValue<ObservableCollection<Product>>(ProductsProperty);
                if(products == null)
                {
                    SetValue(ProductsProperty, new ObservableCollection<Product>(productLoadingService.GetAll()));
                    products = GetValue<ObservableCollection<Product>>(ProductsProperty);
                }
                return products;
            }
            set { SetValue(ProductsProperty, value); }
        }
        public static readonly PropertyData ProductsProperty = RegisterProperty(nameof(Products), typeof(ObservableCollection<Product>));

        public void OpenCustomer(int id)
        {
            // TODO : Bei dem Aufruf sollte Products direkt mitgeliefert werden.
            Main.Instance.ActivContent = customerLoadingService.GetById(id);
        }

        public void OpenProduct(int id)
        {
            // TODO : Bei dem Aufruf sollte Owner direkt mitgeliefert werden.
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