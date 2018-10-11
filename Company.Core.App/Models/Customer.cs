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
    public class Customer : ModelBase
    {
        private readonly ProductLoadingService productLoadingService = new ProductLoadingService();

        #region Properties

        public int Id
        {
            get { return GetValue<int>(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly PropertyData IdProperty = RegisterProperty(nameof(Id), typeof(int), null);

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


        public string CustomerNumber
        {
            get { return GetValue<string>(CustomerNumberProperty); }
            set
            {
                SetValue(CustomerNumberProperty, value);
                SetDisplayText();
            }
        }
        public static readonly PropertyData CustomerNumberProperty = RegisterProperty(nameof(CustomerNumber), typeof(string), null);


        public string DisplayText
        {
            get { return GetValue<string>(DisplayTextProperty); }
            private set { SetValue(DisplayTextProperty, value); }
        }
        public static readonly PropertyData DisplayTextProperty = RegisterProperty(nameof(DisplayText), typeof(string), null);


        public ObservableCollection<Product> Products
        {
            get
            {
                ObservableCollection<Product> products = GetValue<ObservableCollection<Product>>(ProductProperty);
                if(products == null)
                {
                    SetValue(ProductProperty, new ObservableCollection<Product>(productLoadingService.GetByCustomerId(Id)));
                    products = GetValue<ObservableCollection<Product>>(ProductProperty);
                }
                return products;
            }
            set { SetValue(ProductProperty, value); }
        }
        public static readonly PropertyData ProductProperty = RegisterProperty(nameof(Products), typeof(ObservableCollection<Product>));

        #endregion

        #region Methods

        private void SetDisplayText()
        {
            DisplayText = String.Format("{0} / {1}", CustomerNumber, Name);
        }

        #endregion
    }
}
