﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Company.Core.App.Models;

namespace Company.Core.ViewModels
{
    public class MainVm : ViewModelBase
    {
        public MainVm()
        {
            Model = Main.Instance;
            RefreshCommand = new Command(Refresh, CanRefresh);
        }

        [Model]
        public Main Model
        {
            get { return GetValue<Main>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }

        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Main));

        [ViewModelToModel]
        public ModelBase ActivContent
        {
            get
            {
                ModelBase modelBase = GetValue<ModelBase>(ActivContentProperty);
                if(modelBase is Home)
                    return modelBase as Home;
                if(modelBase is Customer)
                    return modelBase as Customer;
                if(modelBase is Product)
                    return modelBase as Product;

                return null;
            }
            set { SetValue(ActivContentProperty, value as ModelBase); }
        }

        public static readonly PropertyData ActivContentProperty = RegisterProperty(nameof(ActivContent), typeof(ModelBase));


        [ViewModelToModel]
        public ObservableCollection<Customer> Customers
        {
            get { return GetValue<ObservableCollection<Customer>>(CustomersProperty); }
            set { SetValue(CustomersProperty, value); }
        }
        public static readonly PropertyData CustomersProperty = RegisterProperty(nameof(Customers), typeof(ObservableCollection<Customer>));


        public Command RefreshCommand { get; private set; }


        private bool CanRefresh()
        {
            return true;
        }

        private void Refresh()
        {
            Model.LoadData();
        }
    }
}
