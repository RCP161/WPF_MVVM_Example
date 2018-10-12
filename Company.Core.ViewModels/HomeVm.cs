﻿using System;
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
            AddCustomerCommand = new Command(AddCustomer, () => true);
        }

        #region Propertis

        [Model]
        public Home Model
        {
            get { return GetValue<Home>(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Home), null);

        
        [ViewModelToModel(nameof(Model))]
        public ObservableCollection<Customer> Customers
        {
            get { return GetValue<ObservableCollection<Customer>>(CustomersProperty); }
            set { SetValue(CustomersProperty, value); }
        }
        public static readonly PropertyData CustomersProperty = RegisterProperty(nameof(Customers), typeof(ObservableCollection<Customer>), null);


        public Customer SelectedCustomer
        {
            get { return GetValue<Customer>(SelectedCustomerProperty); }
            set { SetValue(SelectedCustomerProperty, value); }
        }
        public static readonly PropertyData SelectedCustomerProperty = RegisterProperty(nameof(SelectedCustomer), typeof(Customer), null);


        public Command OpenCustomerCommand { get; private set; }
        public Command AddCustomerCommand { get; private set; }

        #endregion

        #region Methods

        private bool CanOpenCustomer()
        {
            return SelectedCustomer != null;
        }

        private void OpenCustomer()
        {
            Model.OpenCustomer(SelectedCustomer);
        }

        private void AddCustomer()
        {
            Model.AddCustomer();
        }

        #endregion
    }
}
