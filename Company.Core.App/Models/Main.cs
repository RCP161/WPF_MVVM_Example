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
    public class Main : ModelBase
    {
        private static Main _instance;
        private readonly CustomerLoadingService cusomterLoadingService = new CustomerLoadingService();

        private Main()
        {
            ActivContent = new Home();
            Customers = new ObservableCollection<Customer>(cusomterLoadingService.GetAll());
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


        public ModelBase ActivContent
        {
            get { return GetValue<ModelBase>(ActivContentProperty); }
            set { SetValue(ActivContentProperty, value); }
        }
        public static readonly PropertyData ActivContentProperty = RegisterProperty(nameof(ActivContent), typeof(ModelBase));


        public ObservableCollection<Customer> Customers
        {
            get { return GetValue<ObservableCollection<Customer>>(CustomerProperty); }
            set { SetValue(CustomerProperty, value); }
        }
        public static readonly PropertyData CustomerProperty = RegisterProperty(nameof(Customers), typeof(ObservableCollection<Customer>));
    }
}
