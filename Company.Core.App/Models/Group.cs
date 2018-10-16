using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Company.Core.App.Services.Loading;

namespace Company.Core.App.Models
{
    public class Group : ModelBase
    {
        // TODO : Services per ServiceLocator?

        private readonly ProductLoadingService productLoadingService = new ProductLoadingService();
        private readonly CustomerLoadingService cusomterLoadingService = new CustomerLoadingService();

        public Group()
        {
            Customers = new ObservableCollection<Customer>(cusomterLoadingService.GetAll());
        }

        public string DisplayText
        {
            get { return GetValue<string>(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }

        public static readonly PropertyData DisplayTextProperty = RegisterProperty(nameof(DisplayText), typeof(string));

        
        public ObservableCollection<Customer> Customers
        {
            get { return GetValue<ObservableCollection<Customer>>(CustomerProperty); }
            set { SetValue(CustomerProperty, value); }
        }
        public static readonly PropertyData CustomerProperty = RegisterProperty(nameof(Customers), typeof(ObservableCollection<Customer>));
        
    }
}
