using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.MVVM;
using Company.Core.App.Models;

namespace Company.Core.ViewModels
{
    public class ProductItemVm : ViewModelBase
    {
        public ProductItemVm(Product product)
        {
            Model = product;
        }

        #region Properties

        [Model]
        public Product Model
        {
            get { return GetValue<Product>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Product));


        [ViewModelToModel(nameof(Model))]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            private set { SetValue(NameProperty, value); }
        }

        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));

        #endregion
    }
}
