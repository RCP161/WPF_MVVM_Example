using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Company.Core.App.Models;

namespace Company.Core.ViewModels
{
    public class MainVm : ViewModelBase
    {
        public MainVm()
        { }

        [Model]
        public Main Model
        {
            get { return GetValue<Main>(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Main), () => new Main());

        [ViewModelToModel(nameof(Model))]
        public ModelBase ActivContent
        {
            get
            {
                if(Model.ActivContent is Home)
                    return Model.ActivContent as Home;
                if(Model.ActivContent is Customer)
                    return Model.ActivContent as Customer;
                if(Model.ActivContent is Product)
                    return Model.ActivContent as Product;

                return null;
            }
            set { SetValue(ActivContentProperty, value as ModelBase); }
        }

        public static readonly PropertyData ActivContentProperty = RegisterProperty(nameof(ActivContent), typeof(ModelBase), null);
    }
}
