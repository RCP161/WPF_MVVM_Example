using System;
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
    public abstract class TreeViewItemVm : ViewModelBase
    {
        public TreeViewItemVm()
        {
            ChildCollection = new ObservableCollection<TreeViewItemVm>();
        }

        #region Properties

        public string DisplayText
        {
            get { return GetValue<string>(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }

        public static readonly PropertyData DisplayTextProperty = RegisterProperty(nameof(DisplayText), typeof(string));


        public ObservableCollection<TreeViewItemVm> ChildCollection
        {
            get { return GetValue<ObservableCollection<TreeViewItemVm>>(ChildCollectionProperty); }
            set { SetValue(ChildCollectionProperty, value); }
        }

        public static readonly PropertyData ChildCollectionProperty = RegisterProperty(nameof(ChildCollection), typeof(ObservableCollection<TreeViewItemVm>));


        public Command OpenItemCommand { get; protected set; }

        #endregion
    }

    public class MainTreeViewItemVm : TreeViewItemVm
    {
        public MainTreeViewItemVm(Main main)
        { 
            IViewModelFactory factory = ServiceLocator.Default.ResolveType<IViewModelFactory>();

            foreach(Customer c in main.Customers)
                ChildCollection.Add(factory.CreateViewModel<CustomerTreeViewItemVm>(c));
        }
    }

    public class CustomerTreeViewItemVm : TreeViewItemVm
    {
        public CustomerTreeViewItemVm(Customer customer)
        {
            DisplayText = customer.DisplayText;
            OpenItemCommand = new Command(() => customer.OpenCustomer(customer.Id), () => false); 
            IViewModelFactory factory = ServiceLocator.Default.ResolveType<IViewModelFactory>();

            foreach(Product p in customer.Products)
                ChildCollection.Add(factory.CreateViewModel<ProductTreeViewItemVm>(p));
        }
    }

    public class ProductTreeViewItemVm : TreeViewItemVm
    {
        public ProductTreeViewItemVm(Product product)
        {
            DisplayText = product.Name;
            OpenItemCommand = new Command(() => product.OpenProduct(product.Id), () => false);
        }
    }
}
