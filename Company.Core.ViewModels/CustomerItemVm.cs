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
    public class CustomerItemVm : ViewModelBase
    {
        public CustomerItemVm(Customer customer)
        {
            Model = customer;
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
        public string DisplayText
        {
            get { return GetValue<string>(DisplayTextProperty); }
            private set { SetValue(DisplayTextProperty, value); }
        }
        public static readonly PropertyData DisplayTextProperty = RegisterProperty(nameof(DisplayText), typeof(string));

        #endregion
    }
}
