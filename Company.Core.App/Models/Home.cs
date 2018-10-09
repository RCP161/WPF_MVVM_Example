using Catel.Data;
using Company.Core.App.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.App.Models
{
    public class Home : ModelBase
    {
        private static readonly HomeBl bl = new HomeBl();

        public Home()
        {
            //Customers = new ObservableCollection<Customer>(bl.GetAllCustomers());
        }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                ObservableCollection<Customer> customers = GetValue<ObservableCollection<Customer>>(CustomersProperty);
                if(customers == null)
                    SetValue(CustomersProperty, new ObservableCollection<Customer>(bl.GetAllCustomers()));
                return customers;
            }
            set { SetValue(CustomersProperty, value); }
        }
        public static readonly PropertyData CustomersProperty = RegisterProperty(nameof(Customers), typeof(ObservableCollection<Customer>));

    }
}
