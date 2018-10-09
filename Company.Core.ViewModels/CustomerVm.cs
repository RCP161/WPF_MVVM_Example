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
    public class CustomerVm : ViewModelBase
    {
        public CustomerVm(Customer customer)
        {
            Model = customer;
        }

        #region Propertis

        [Model]
        public Customer Model
        {
            get { return GetValue<Customer>(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Customer), null);


        [ViewModelToModel(nameof(Model))]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string), null);


        [ViewModelToModel(nameof(Model))]
        public string CustomerNumber
        {
            get { return GetValue<string>(CustomerNumberProperty); }
            set { SetValue(CustomerNumberProperty, value); }
        }

        public static readonly PropertyData CustomerNumberProperty = RegisterProperty(nameof(CustomerNumber), typeof(string), null);


        [ViewModelToModel(nameof(Model))]
        public ObservableCollection<Product> Products
        {
            get { return GetValue<ObservableCollection<Product>>(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }
        public static readonly PropertyData ProductsProperty = RegisterProperty(nameof(Products), typeof(ObservableCollection<Product>), null);


        public Product SelectedProduct
        {
            get { return GetValue<Product>(SelectedProductProperty); }
            set { SetValue(SelectedProductProperty, value); }
        }
        public static readonly PropertyData SelectedProductProperty = RegisterProperty(nameof(SelectedProduct), typeof(Product), null);
        
        #endregion
    }
}
