using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;

namespace Company.Core.Models
{
    public class Customer : ModelBase
    {
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string), null);


        public string CustomerNumber
        {
            get { return GetValue<string>(CustomerNumberProperty); }
            set { SetValue(CustomerNumberProperty, value); }
        }

        public static readonly PropertyData CustomerNumberProperty = RegisterProperty(nameof(CustomerNumber), typeof(string), null);
        

        public ObservableCollection<Product> Products
        {
            get { return GetValue<ObservableCollection<Product>>(ProductProperty); }
            set { SetValue(ProductProperty, value); }
        }

        public static readonly PropertyData ProductProperty = RegisterProperty(nameof(Products), typeof(ObservableCollection<Product>), () => new ObservableCollection<Product>());

    }
}
