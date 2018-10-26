using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.MVVM;
using Company.Core.App.Common;
using Company.Core.App.Models;

namespace Company.Core.ViewModels
{
    public class ProductVm : ViewModelBase
    {
        public ProductVm(Product product)
        {
            Model = product;
            OpenCustomerCommand = new Command(OpenCustomer, CanOpenCustomer);
            CancelEditCommand = new Command(CancelEdit, CanCancelEdit);
            SaveEditCommand = new Command(SaveEdit, CanSaveEdit);
            HomeCommand = new Command(OpenHome, CanOpenHome);
        }

        #region Properties

        [Model]
        public Product Model
        {
            get { return GetValue<Product>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Product));


        [ViewModelToModel]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        [ViewModelToModel]
        public Customer Owner
        {
            get { return GetValue<Customer>(OwnerProperty); }
            set { SetValue(OwnerProperty, value); }
        }

        public static readonly PropertyData OwnerProperty = RegisterProperty(nameof(Owner), typeof(Customer));


        public Command OpenCustomerCommand { get; private set; }
        public Command CancelEditCommand { get; private set; }
        public Command SaveEditCommand { get; private set; }
        public Command HomeCommand { get; private set; }

        #endregion

        #region Methods
        private bool CanOpenCustomer()
        {
            return Owner != null;
        }

        private void OpenCustomer()
        {
            Model.OpenCustomer(Owner.Id);
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
