using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.MVVM;
using Company.Core.Models;

namespace Company.Core.ViewModels
{
    public class HomeVm : ViewModelBase
    {
        [Model]
        public Home Model
        {
            get { return GetValue<Home>(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Home), null);
    }
}
