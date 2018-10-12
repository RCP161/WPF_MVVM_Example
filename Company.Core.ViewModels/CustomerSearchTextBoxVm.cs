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
    // TODO : [Prio3] Mit CustomerItemVm zusammen legen? Erben?

    public class CustomerSearchTextBoxVm : ViewModelBase
    {
        public CustomerSearchTextBoxVm(Customer customer)
        {
            Model = customer;
            OpenCustomerCommand = new Command(OpenCustomer, CanOpenCustomer);
            EditCustomerCommand = new Command(EditCusomer, CanEditCusomer);
        }

        #region Properties

        [Model]
        public Customer Model
        {
            get { return GetValue<Customer>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Customer));


        [ViewModelToModel(nameof(Model))]
        public string DisplayText
        {
            get { return GetValue<string>(DisplayTextProperty); }
            private set { SetValue(DisplayTextProperty, value); }
        }
        public static readonly PropertyData DisplayTextProperty = RegisterProperty(nameof(DisplayText), typeof(string));

        public Command OpenCustomerCommand { get; private set; }
        public Command EditCustomerCommand { get; private set; }

        #endregion

        #region Methods
        private bool CanOpenCustomer()
        {
            // Gibt ja noch keine Rechte
            return true;
        }

        private void OpenCustomer()
        {
            Model.OpenCustomer(Model.Id);
        }

        private bool CanEditCusomer()
        {
            // Gibt ja noch keine Rechte
            return true;
        }

        private void EditCusomer()
        {
            throw new NotImplementedException("Hier würde der SearchDialog kommen.");
        }

        #endregion
    }
}
