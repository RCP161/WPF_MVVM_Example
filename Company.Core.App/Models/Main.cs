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
        private static Main _instance;

        private Main()
        {
            ActivContent = new Home();
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


        public Group Root
        {
            get { return GetValue<Group>(RootProperty); }
            set { SetValue(RootProperty, value); }
        }

        public static readonly PropertyData RootProperty = RegisterProperty(nameof(Root), typeof(Group));
    }
}
