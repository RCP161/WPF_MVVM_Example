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
    public abstract class TreeViewItemVm : ViewModelBase
    {
        public TreeViewItemVm()
        {
            string a = "";
        }

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


        public Command OpenItemCommand { get; protected set; }

        #endregion
    }
    public abstract class TreeViewItem<T> : TreeViewItemVm where T : ModelBase
    {
        public TreeViewItem(T model)
        {
            Model = model;
        }

        [Model]
        public T Model
        {
            get { return GetValue<T>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(T));
    }

    public class CustomerTreeViewItemVm : TreeViewItem<Customer>
    {
        public CustomerTreeViewItemVm(Customer customer) : base(customer)
        {
            OpenItemCommand = new Command(() => customer.OpenCustomer(customer.Id), () => false); // Muss so sein. Es könnten ja noch rechte etc. abgefragt werden
            ChildCollection = new ObservableCollection<ModelBase>(customer.Products);
        }
    }

    public class ProductTreeViewItemVm : TreeViewItem<Product>
    {
        public ProductTreeViewItemVm(Product product) : base(product)
        {
            OpenItemCommand = new Command(() => product.OpenProduct(product.Id), () => false);
            ChildCollection = new ObservableCollection<ModelBase>();
        }
    }
}
