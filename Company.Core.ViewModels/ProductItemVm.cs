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


        [ViewModelToModel]
        public string DisplayText
        {
            get { return GetValue<string>(DisplayTextProperty); }
            private set { SetValue(DisplayTextProperty, value); }
        }

        public static readonly PropertyData DisplayTextProperty = RegisterProperty(nameof(DisplayText), typeof(string));

        #endregion

        protected override Task<bool> SaveAsync()
        {
            Model.Save();
            return base.SaveAsync();
        }
    }
}
