using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;

namespace Company.Core.App.Models
{
    public class Main : ModelBase
    {
        public Main()
        {
            ActivContent = new Home();
        }

        public ModelBase ActivContent
        {
            get { return GetValue<ModelBase>(ActivContentProperty); }
            set { SetValue(ActivContentProperty, value); }
        }

        public static readonly PropertyData ActivContentProperty = RegisterProperty(nameof(ActivContent), typeof(ModelBase), null);
    }
}
