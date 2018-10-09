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
    // TODO : Sollte nur ReadOnly sein.
    // TODO : Erben für selbes verhalten innerhalb eines ViewModelStamms (Customer, PRoduct, ...)?
    // TODO : BaseVm für Id, DisplayName, ...?

    public class CustomerItemVm : ViewModelBase
    {
        public CustomerItemVm(Customer customer)
        {
            Model = customer;
            SetDisplayText();
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
            set
            {
                SetValue(NameProperty, value);
                SetDisplayText();
            }
        }

        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string), null);


        [ViewModelToModel(nameof(Model))]
        public string CustomerNumber
        {
            get { return GetValue<string>(CustomerNumberProperty); }
            set { SetValue(CustomerNumberProperty, value); }
        }

        public static readonly PropertyData CustomerNumberProperty = RegisterProperty(nameof(CustomerNumber), typeof(string), null);


        public string DisplayText
        {
            get { return GetValue<string>(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }
        public static readonly PropertyData DisplayTextProperty = RegisterProperty(nameof(DisplayText), typeof(string), null);

        #endregion

        #region Methods

        private void SetDisplayText()
        {
            DisplayText = String.Format("{0} / {1}", CustomerNumber, Name);
        }

        #endregion
    }
}
