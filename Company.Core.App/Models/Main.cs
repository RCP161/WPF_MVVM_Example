using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.IoC;
using Company.Core.App.Services.Data.Interfaces;

namespace Company.Core.App.Models
{
    public class Main : ModelBase1
    {
        private readonly ICustomerDataService customerDataService;
        private static Main _instance;

        private Main()
        {
            ActivContent = new Home();
            customerDataService = ServiceLocator.Default.ResolveType<ICustomerDataService>();

            LoadData();
        }

        public static Main Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new Main();
                return _instance;
            }
        }


        public ModelBase1 ActivContent
        {
            get { return GetValue<ModelBase1>(ActivContentProperty); }
            set { SetValue(ActivContentProperty, value); }
        }

        public static readonly PropertyData ActivContentProperty = RegisterProperty(nameof(ActivContent), typeof(ModelBase1));


        public ObservableCollection<Customer> Customers
        {
            get { return GetValue<ObservableCollection<Customer>>(CustomersProperty); }
            set { SetValue(CustomersProperty, value); }
        }
        public static readonly PropertyData CustomersProperty = RegisterProperty(nameof(Customers), typeof(ObservableCollection<Customer>));


        public void LoadData()
        {
            Customers = new ObservableCollection<Customer>(customerDataService.GetAllHierarchical());
        }
    }
}
