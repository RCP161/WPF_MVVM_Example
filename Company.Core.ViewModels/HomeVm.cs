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
            OpenCustomerCommand = new TaskCommand(OpenCustomer, CanOpenCustomer);
        }

        #region Propertis

        [Model]
        public Home Model
        {
            get { return GetValue<Home>(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Home), null);


        // TODO : Hier gehts weiter. Fehlt OnPropertyChanged am Model? Es wird nicht aktualisiert
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


        public TaskCommand OpenCustomerCommand { get; private set; }

        #endregion

        #region Methods

        private bool CanOpenCustomer()
        {
            return SelectedCustomer != null;
        }

        private async Task OpenCustomer()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
