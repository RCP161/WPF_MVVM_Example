using System;
using Catel.Data;
using Catel.MVVM;
using Company.App.Core.Models.App;

namespace Company.App.Presentation
{
    public class MainWindowVm : ViewModelBase
    {
        public MainWindowVm()
        {
            Model = Main.Instance;
        }


        [Model]
        public Main Model
        {
            get { return GetValue<Main>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Main));
    }
}
