using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.MVVM;
using Company.Core.App.Common;
using Company.Core.App.Models;

namespace Company.Core.ViewModels
{
    public class CustomerVm : ViewModelBase
    {
        public CustomerVm(Customer customer) : base(true)
        {
            Model = customer;
            AddProductCommand = new Command(AddProduct, CanAddProduct);
            OpenProductCommand = new Command(OpenProduct, CanOpenProduct);
            DeleteProductCommand = new Command(DeleteProduct, CanDeleteProduct);
            CancelEditCommand = new Command(CancelEdit, CanCancelEdit);
            SaveEditCommand = new Command(SaveEdit, CanSaveEdit);
            HomeCommand = new Command(OpenHome, CanOpenHome);
        }

        #region Properties

        [Model]
        public Customer Model
        {
            get { return GetValue<Customer>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Customer));


        [ViewModelToModel]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        [ViewModelToModel]
        public string CustomerNumber
        {
            get { return GetValue<string>(CustomerNumberProperty); }
            set { SetValue(CustomerNumberProperty, value); }
        }

        public static readonly PropertyData CustomerNumberProperty = RegisterProperty(nameof(CustomerNumber), typeof(string));


        [ViewModelToModel]
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


        [ViewModelToModel]
        public string DisplayText
        {
            get { return GetValue<string>(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }
        public static readonly PropertyData DisplayTextProperty = RegisterProperty(nameof(DisplayText), typeof(string));


        public Command OpenProductCommand { get; private set; }
        public Command AddProductCommand { get; private set; }
        public Command DeleteProductCommand { get; private set; }
        public Command CancelEditCommand { get; private set; }
        public Command SaveEditCommand { get; private set; }
        public Command HomeCommand { get; private set; }

        #endregion

        #region Methods
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
            Model.CreateProduct();
        }

        private void DeleteProduct()
        {
            Model.DeleteProduct(SelectedProduct);
        }

        private bool CanDeleteProduct()
        {
            return SelectedProduct != null;
        }

        private bool CanSaveEdit()
        {
            return Model.State.HasFlag(StateEnum.Modified) || Model.State.HasFlag(StateEnum.Created);
        }

        private void SaveEdit()
        {
            // Danach hängt sich ja da VM ab ...
            // SaveViewModelAsync();
            Model.Save();
        }

        private bool CanCancelEdit()
        {
            return Model.State.HasFlag(StateEnum.Modified) || Model.State.HasFlag(StateEnum.Created);
        }

        private void CancelEdit()
        {
            CancelViewModelAsync();
        }

        private bool CanOpenHome()
        {
            return true;
        }

        private void OpenHome()
        {
            Model.OpenHome();
        }

        #endregion
    }
}
