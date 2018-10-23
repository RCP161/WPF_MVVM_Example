using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.MVVM;
using Company.Core.App.Models;

namespace Company.Core.ViewModels
{
    public class ProductVm : ViewModelBase
    {
        public ProductVm(Product product)
        {
            Model = product;
            OpenCustomerCommand = new Command(OpenCustomer, CanOpenProduct);
            CancelEditCommand = new Command(CancelEdit, CanCancelEdit);
            SaveEditCommand = new Command(SaveEdit, CanSaveEdit);
        }

        #region Properties

        [Model]
        public Product Model
        {
            get { return GetValue<Product>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Product));


        [ViewModelToModel(nameof(Model))]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        [ViewModelToModel(nameof(Model))]
        public Customer Owner
        {
            get { return GetValue<Customer>(OwnerProperty); }
            set { SetValue(OwnerProperty, value); }
        }

        public static readonly PropertyData OwnerProperty = RegisterProperty(nameof(Owner), typeof(Customer));


        public Command OpenCustomerCommand { get; private set; }
        public Command CancelEditCommand { get; private set; }
        public Command SaveEditCommand { get; private set; }

        #endregion

        #region Methods
        private bool CanOpenProduct()
        {
            return Owner != null;
        }

        private void OpenCustomer()
        {
            Model.OpenCustomer(Owner.Id);
        }

        private bool CanSaveEdit()
        {
            return IsDirty;
        }

        private void SaveEdit()
        {
            Model.Save();
        }

        private bool CanCancelEdit()
        {
            return IsDirty;
        }

        private void CancelEdit()
        {
            CancelViewModelAsync();
        }

        #endregion
    }
}
