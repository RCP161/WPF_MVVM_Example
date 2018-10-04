using Catel.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Models
{
    public class Home : ModelBase
    {
        public ObservableCollection<Customer> Customers
        {
            get { return GetValue<ObservableCollection<Customer>>(CustomersProperty); }
            set { SetValue(CustomersProperty, value); }
        }

        public static readonly PropertyData CustomersProperty = RegisterProperty(nameof(Customers), typeof(ObservableCollection<Customer>), () => new ObservableCollection<Customer>());

    }
}
