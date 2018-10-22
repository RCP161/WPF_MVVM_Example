using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;

namespace Company.Core.App.Models
{
    public class Main : ModelBase1
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


        public ModelBase1 ActivContent
        {
            get { return GetValue<ModelBase1>(ActivContentProperty); }
            set { SetValue(ActivContentProperty, value); }
        }

        public static readonly PropertyData ActivContentProperty = RegisterProperty(nameof(ActivContent), typeof(ModelBase1));
    }
}
