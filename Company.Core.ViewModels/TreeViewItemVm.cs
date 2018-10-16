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
    public class TreeViewItemVm : ViewModelBase
    {
        public TreeViewItemVm(ModelBase model)
        {
            Model = model;

            if(model is Group)
            {
                OpenItemCommand = new Command(null, () => false);
                ChildCollection = new ObservableCollection<ModelBase>(((Group)model).Customers);
            }
            else if(model is Customer)
            {
                Customer customer = model as Customer;
                OpenItemCommand = new Command(() => customer.OpenCustomer(customer.Id), () => false); // Muss so sein. Es könnten ja noch rechte etc. abgefragt werden
                ChildCollection = new ObservableCollection<ModelBase>(customer.Products);
            }
            else if(model is Product)
            {
                Product product = model as Product;
                OpenItemCommand = new Command(() => product.OpenProduct(product.Id), () => false);
                ChildCollection = new ObservableCollection<ModelBase>(((Group)model).Customers);
            }

        }

        [Model]
        public ModelBase Model
        {
            get { return GetValue<ModelBase>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(ModelBase));

        #region Properties

        public string DisplayText
        {
            get { return GetValue<string>(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }

        public static readonly PropertyData DisplayTextProperty = RegisterProperty(nameof(DisplayText), typeof(string));


        public ObservableCollection<ModelBase> ChildCollection
        {
            get { return GetValue<ObservableCollection<ModelBase>>(ChildCollectionProperty); }
            set { SetValue(ChildCollectionProperty, value); }
        }

        public static readonly PropertyData ChildCollectionProperty = RegisterProperty(nameof(ChildCollection), typeof(ObservableCollection<ModelBase>));


        public Command OpenItemCommand { get; private set; }

        #endregion
    }
}
